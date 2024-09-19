using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Model;
using StudentPerformanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentPerformanceTracker.Services
{
    public class PredictionHandlerService
    {
        static Dictionary<Grade, (double minPercentage, double maxPercentage, double requiredHours)> gradeDetails = new Dictionary<Grade, (double, double, double)>
        {
            { Grade.A_Plus, (95, 100, 28) },
            { Grade.A, (85, 94, 24.5) },
            { Grade.A_Minus, (75, 84, 21) },
            { Grade.B_Plus, (65, 74, 17.5) },
            { Grade.B, (55, 64, 14) },
            { Grade.B_Minus, (50, 54, 10.5) },
            { Grade.C_Plus, (45, 49, 7) },
            { Grade.C, (40, 44, 5.25) },
            { Grade.C_Minus, (35, 39, 3.5) },
            { Grade.E, (0, 34, 0) }
        };

        public static List<Prediction> PredictPerformance(Grade currentGrade, List<StudySessionDTO> studySessions)
        {
            List<(DateTime date, double hours)> dateAndDurationList = ConvertStudySessionsToDateAndDuration(studySessions);
            List<Prediction> predictions = new List<Prediction>();
            double currentPercentage = Math.Round(GetMedianPercentage(currentGrade), 2);

            if (dateAndDurationList.Count == 0)
                return predictions;

            DateTime startDate = dateAndDurationList.First().date;
            DateTime endDate = dateAndDurationList.Last().date;
            DateTime weekStart = startDate;
            DateTime weekEnd = weekStart.AddDays(6);
            int weekNumber = 1;

            while (weekStart <= endDate)
            {
                double weeklyStudyHours = Math.Round(dateAndDurationList
                    .Where(session => session.date >= weekStart && session.date <= weekEnd)
                    .Sum(session => session.hours), 2);

                if (weeklyStudyHours == 0)
                {
                    // Decrease the grade and set percentage to the median of the new grade
                    currentGrade = GetPreviousGrade(currentGrade);
                    currentPercentage = Math.Round(GetMedianPercentage(currentGrade), 2);
                }
                else
                {
                    // Calculate the grade at the end of the week
                    (currentGrade, currentPercentage) = CalculateWeeklyGrade(currentGrade, currentPercentage, weeklyStudyHours, true);
                }

                // Add prediction for the week
                predictions.Add(new Prediction
                {
                    Week = "Week " + weekNumber,
                    DateRange = $"{weekStart.ToShortDateString()} - {weekEnd.ToShortDateString()}",
                    StudyHours = weeklyStudyHours,
                    Grade = currentGrade,
                    Percentage = currentPercentage
                });

                // Move to the next week
                weekNumber++;
                weekStart = weekStart.AddDays(7);
                weekEnd = weekStart.AddDays(6);
            }

            return predictions;
        }

        static List<(DateTime date, double hours)> ConvertStudySessionsToDateAndDuration(List<StudySessionDTO> studySessions)
        {
            return studySessions.Select(session => (
                session.Date,
                Math.Round(session.TotalDuration / 60, 2)
            )).ToList();
        }

        static (Grade, double) CalculateWeeklyGrade(Grade currentGrade, double currentPercentage, double weeklyStudyHours, bool isNewWeek)
        {
            double requiredHours = gradeDetails[currentGrade].requiredHours;
            double additionalHours = Math.Round(weeklyStudyHours - requiredHours, 2);

            if (additionalHours > 0)
            {
                if (isNewWeek)
                {
                    currentPercentage = Math.Round(GetMedianPercentage(currentGrade), 2);
                }

                while (additionalHours > 0)
                {
                    var nextGrade = GetNextGrade(currentGrade);
                    double nextGradeMinPercentage = gradeDetails[nextGrade].minPercentage;

                    // Calculate how much percentage can be increased within the current grade
                    double percentageIncrease = Math.Round(Math.Min(additionalHours, nextGradeMinPercentage - currentPercentage), 2);
                    currentPercentage = Math.Round(currentPercentage + percentageIncrease, 2);
                    additionalHours = Math.Round(additionalHours - percentageIncrease, 2);

                    if (currentPercentage >= nextGradeMinPercentage)
                    {
                        currentGrade = nextGrade;
                        currentPercentage = nextGradeMinPercentage;
                    }

                    // If moving to the next grade, subtract the required hours for the new grade
                    if (additionalHours > 0)
                    {
                        requiredHours = gradeDetails[currentGrade].requiredHours;
                        additionalHours = Math.Round(additionalHours - requiredHours, 2);
                    }
                }
            }
            else
            {
                if (weeklyStudyHours < requiredHours)
                {
                    double missingHours = Math.Round(requiredHours - weeklyStudyHours, 2);

                    if (isNewWeek)
                    {
                        currentPercentage = gradeDetails[currentGrade].minPercentage;
                    }

                    if ((missingHours / requiredHours) * 100 > 25)
                    {
                        var previousGrade = GetPreviousGrade(currentGrade);
                        currentGrade = previousGrade;
                        currentPercentage = Math.Round(GetMedianPercentage(currentGrade), 2);
                    }
                }
            }

            Console.WriteLine($"Week ending -> New Grade: {currentGrade}, New Percentage: {currentPercentage}");
            return (currentGrade, currentPercentage);
        }

        static double GetMedianPercentage(Grade grade)
        {
            return Math.Round((gradeDetails[grade].minPercentage + gradeDetails[grade].maxPercentage) / 2, 2);
        }

        static Grade GetNextGrade(Grade currentGrade)
        {
            switch (currentGrade)
            {
                case Grade.E: return Grade.C_Minus;
                case Grade.C_Minus: return Grade.C;
                case Grade.C: return Grade.C_Plus;
                case Grade.C_Plus: return Grade.B_Minus;
                case Grade.B_Minus: return Grade.B;
                case Grade.B: return Grade.B_Plus;
                case Grade.B_Plus: return Grade.A_Minus;
                case Grade.A_Minus: return Grade.A;
                case Grade.A: return Grade.A_Plus;
                default: return Grade.A_Plus;
            }
        }

        static Grade GetPreviousGrade(Grade currentGrade)
        {
            switch (currentGrade)
            {
                case Grade.A_Plus: return Grade.A;
                case Grade.A: return Grade.A_Minus;
                case Grade.A_Minus: return Grade.B_Plus;
                case Grade.B_Plus: return Grade.B;
                case Grade.B: return Grade.B_Minus;
                case Grade.B_Minus: return Grade.C_Plus;
                case Grade.C_Plus: return Grade.C;
                case Grade.C: return Grade.C_Minus;
                case Grade.C_Minus: return Grade.E;
                default: return Grade.E;
            }
        }
    }
}
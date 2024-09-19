using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPTKnowledgeService.DTO;
using SPTUserService.DTO;
using StudentPerformanceTracker.API_Service;

namespace StudentPerformanceTracker.Services
{
    public static class LoadDataService
    {
        private static readonly UserServiceClient _userServiceClient = new UserServiceClient();
        private static readonly SubjectServiceClient _subjectServiceClient = new SubjectServiceClient();
        private static readonly KnowledgeServiceClient _knowledgeServiceClient = new KnowledgeServiceClient();

        public static async Task<List<StudySessionDTO>> LoadStudySessions()
        {
            var studySessions = await _knowledgeServiceClient.GetStudySessionsAsync();
            return studySessions.OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<BreakDTO>> LoadBreaks()
        {
            var breaks = await _knowledgeServiceClient.GetBreaksAsync();
            return breaks.OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<SubjectDTO>> LoadStudySubjects()
        {
            var subjects = await _subjectServiceClient.GetSubjectsAsync();
            return subjects.OrderBy(k => k.SubjectCode).ToList();
        }

        public static async Task<string> CurrentKnowledge(string subjectCode)
        {
            var knowledgeList = await _knowledgeServiceClient.GetKnowledgeByCriteriaAsync(subjectCode, EventService.CurrentUser.Username, null, null);
            var subjectKnowledge = knowledgeList.OrderByDescending(obj => obj.Id).ToList();

            if (subjectKnowledge.Any())
            {
                return ToDisplayGradeValue(subjectKnowledge.First().CurrentGrade);
            }
            throw new InvalidOperationException("No knowledge records found for the given subject code.");
        }

        public static string ToDisplayGradeValue(GradeDTO grade)
        {
            switch (grade.GradeCode)
            {
                case "A_Plus":
                    return "A+";
                case "A":
                    return "A";
                case "A_Minus":
                    return "A-";
                case "B_Plus":
                    return "B+";
                case "B":
                    return "B";
                case "B_Minus":
                    return "B-";
                case "C_Plus":
                    return "C+";
                case "C":
                    return "C";
                case "C_Minus":
                    return "C-";
                case "E":
                    return "E";
                default:
                    return "N/A";
            }
        }

        public static async Task<List<KnowledgeDTO>> GetKnowledgeList()
        {
            return (await _knowledgeServiceClient.GetKnowledgeAsync()).OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<KnowledgeDTO>> GetKnowledgeListByCriteria(string subjectCode, DateTime? fromDate, DateTime? toDate)
        {
            var knowledgeList = await _knowledgeServiceClient.GetKnowledgeByCriteriaAsync(subjectCode, EventService.CurrentUser.Username, fromDate, toDate);
            return knowledgeList.OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<BreakDTO>> GetBreakListByCriteria(string subjectCode, string username, DateTime? fromDate, DateTime? toDate)
        {
            var breakList = await _knowledgeServiceClient.GetBreaksByCriteriaAsync(subjectCode, username, fromDate, toDate);
            return breakList.OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<StudySessionDTO>> GetStudySessionListByCriteria(string subjectCode, DateTime? fromDate, DateTime? toDate)
        {
            var studySessionList = await _knowledgeServiceClient.GetStudySessionsByCriteriaAsync(subjectCode, EventService.CurrentUser.Username, fromDate, toDate);
            return studySessionList.OrderBy(k => k.Id).ToList();
        }

        public static async Task<List<UserDTO>> GetUsers()
        {
            return (await _userServiceClient.GetUsersAsync()).ToList();
        }

        public static async Task<GradeDTO> CurrentGradeKnowledge(string subjectCode, DateTime date)
        {
            var subjectKnowledge = (await _knowledgeServiceClient.GetKnowledgeByCriteriaAsync(subjectCode, EventService.CurrentUser.Username, null, date))
                .Where(obj => obj.Date <= date)
                .OrderByDescending(obj => obj.Date)
                .ToList();

            if (subjectKnowledge.Any())
            {
                return subjectKnowledge.First().CurrentGrade;
            }

            subjectKnowledge = (await _knowledgeServiceClient.GetKnowledgeByCriteriaAsync(subjectCode, EventService.CurrentUser.Username, date, null))
                .Where(obj => obj.Date > date)
                .OrderBy(obj => obj.Date)
                .ToList();

            if (subjectKnowledge.Any())
            {
                return subjectKnowledge.First().CurrentGrade;
            }

            throw new InvalidOperationException("No knowledge data available for the given subject code and date.");
        }
    }
}

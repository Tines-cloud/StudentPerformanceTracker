using System;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class RulesAssumptionsForm : Form
    {
        public RulesAssumptionsForm()
        {
            InitializeComponent();
        }

        private void RulesAssumptions_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowserRules1.DocumentText = GetRulesAndAssumptionsHtml();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An unexpected error occurred while loading the document: {ex.Message}");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while closing the form: {ex.Message}");
            }
        }

        private string GetRulesAndAssumptionsHtml()
        {
            try
            {
                return @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Rules and Assumptions for Grade Prediction Logic</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            line-height: 1.6;
        }
        h1 {
            color: #004d99;
            font-size: 24px;
            margin-bottom: 20px;
        }
        h2 {
            color: #0066cc;
            font-size: 20px;
            margin-top: 20px;
        }
        h3 {
            color: #0073e6;
            font-size: 18px;
            margin-top: 15px;
        }
        ul, ol {
            margin-top: 10px;
            padding-left: 20px;
        }
        .example {
            background-color: #f9f9f9;
            border: 1px solid #ccc;
            padding: 10px;
            margin-top: 20px;
        }
        .highlight {
            color: #cc0000;
            font-weight: bold;
        }
        .note {
            font-style: italic;
            color: #555;
        }
    </style>
</head>
<body>
    <h1>Rules and Assumptions for Grade Prediction Logic</h1>
    <h2>Overview</h2>
    <p>This document outlines the rules and assumptions used to calculate and predict the grade improvements for a subject based on daily study durations. The prediction logic uses predefined grade requirements and calculates weekly grade improvements or decreases.</p>

    <h2>Inputs</h2>
    <ul>
        <li><strong>Subject Current Grade:</strong> The initial grade of the student in the subject.</li>
        <li><strong>Daily Study Duration:</strong> The number of hours spent studying the subject each day, recorded over any number of days.</li>
    </ul>

    <h2>Assumptions</h2>
    <h3>Weekly Calculation:</h3>
    <ul>
        <li>Grades are calculated weekly. The start of the week is the start of the date range.</li>
        <li>If the study duration for a week exceeds the required hours to maintain the current grade, the excess hours contribute to increasing the percentage within the current grade or moving to the next grade.</li>
        <li>If the study duration for a week is less than the required hours, but within 25% of the required hours, the grade remains the same.</li>
        <li>If the study duration for a week is less than 75% of the required hours, the grade decreases to the previous grade, with the percentage set to the median of the new grade's range.</li>
        <li>If no study hours are recorded in a week, the grade decreases to the previous grade, and the percentage is set to the median of the new grade's range.</li>
    </ul>
    <h3>Percentage Increase:</h3>
    <ul>
        <li>It is assumed that 1 hour of study time translates to a 1% increase in the grade percentage.</li>
        <li>Maximum percentage is 100% and minimum percentage is 0%.</li>
    </ul>
    <h3>Percentage Decrease:</h3>
    <ul>
        <li>If the weekly study hours are less than 75% of the required hours, the percentage decreases, and the grade may decrease to the previous grade.</li>
        <li>The new percentage after grade decrease is set to the median of the previous grade's range.</li>
    </ul>

    <h2>Grade Requirements</h2>
    <h3>Required Weekly Study Hours</h3>
    <ul>
        <li><strong>A+:</strong> 28 hours</li>
        <li><strong>A:</strong> 24.5 hours</li>
        <li><strong>A-:</strong> 21 hours</li>
        <li><strong>B+:</strong> 17.5 hours</li>
        <li><strong>B:</strong> 14 hours</li>
        <li><strong>B-:</strong> 10.5 hours</li>
        <li><strong>C+:</strong> 7 hours</li>
        <li><strong>C:</strong> 5.25 hours</li>
        <li><strong>C-:</strong> 3.5 hours</li>
        <li><strong>E:</strong> 0 hours</li>
    </ul>

    <h3>Percentage Ranges</h3>
    <ul>
        <li><strong>A+:</strong> 95-100%</li>
        <li><strong>A:</strong> 85-94%</li>
        <li><strong>A-:</strong> 75-84%</li>
        <li><strong>B+:</strong> 65-74%</li>
        <li><strong>B:</strong> 55-64%</li>
        <li><strong>B-:</strong> 50-54%</li>
        <li><strong>C+:</strong> 45-49%</li>
        <li><strong>C:</strong> 40-44%</li>
        <li><strong>C-:</strong> 35-39%</li>
        <li><strong>E:</strong> 0-34%</li>
    </ul>

    <h2>Logic for Grade Calculation</h2>
    <h3>Initial Setup:</h3>
    <ul>
        <li>The current grade and a list of study sessions (date and hours) are provided.</li>
        <li>The initial percentage is set to the median of the current grade's percentage range.</li>
    </ul>
    <h3>Weekly Study Hours Calculation:</h3>
    <ul>
        <li>For each week, sum the study hours.</li>
    </ul>
    <h3>Determine Additional Hours:</h3>
    <ul>
        <li>Calculate the additional hours by subtracting the required hours to maintain the current grade from the total weekly study hours.</li>
        <li>Use additional hours to increase the grade percentage.</li>
    </ul>
    <h3>Percentage Increase Calculation:</h3>
    <ul>
        <li>If the additional hours exceed the required hours, the percentage increases.</li>
        <li>If the percentage reaches or exceeds the next grade's minimum percentage, transition to the next grade.</li>
    </ul>
    <h3>Percentage Decrease Calculation:</h3>
    <ul>
        <li>If the weekly study hours are less than the required hours, calculate the missing hours.</li>
        <li>If the shortfall exceeds 25% of the required hours, transition to the previous grade with the median percentage of the new grade.</li>
        <li>If no study hours are recorded in a week, the grade decreases to the previous grade, and the percentage is set to the median of the new grade's range.</li>
    </ul>

    <h2>Performance Prediction</h2>
    <p>The performance of a student is predicted based on the final grade and the percentage change from the start grade.</p>
    <ul>
        <li><strong>Excellent:</strong> If the percentage increase is positive.</li>
        <li><strong>Good:</strong> If the percentage remains the same.</li>
        <li><strong>Poor:</strong> If the percentage decreases.</li>
    </ul>

    <h2>Visualization</h2>
    <p>The results of the predictions are visualized using the following charts:</p>
    <ul>
        <li><strong>Weekly Study Hours Chart:</strong> Displays the total study hours per week.</li>
        <li><strong>Grade Variations Chart:</strong> Displays the grade changes over weeks as numeric values.</li>
        <li><strong>Weekly Percentage Chart:</strong> Displays the percentage changes over weeks.</li>
    </ul>

    <div class='example'>
        <h3>Example Calculation for Increasing Grade:</h3>
        <p><strong>Current Grade:</strong> B-</p>
        
        <p><strong>Study Sessions:</strong></p>
        <ul>
            <li>2024/07/07 - 3h</li>
            <li>2024/07/08 - 2h</li>
            <li>2024/07/09 - 2h</li>
            <li>2024/07/10 - 5h</li>
            <li>2024/07/11 - 2h</li>
            <li>2024/07/12 - 3h</li>
            <li>2024/07/13 - 2h</li>
        </ul>
        <p><strong>Week 1 (2024/07/07 to 2024/07/13):</strong></p>
        <ul>
            <li>Total study hours: 3 + 2 + 2 + 5 + 2 + 3 + 2 = 19 hours</li>
            <li>Required hours for B-: 10.5 hours</li>
            <li>Additional hours: 19 - 10.5 = 8.5 hours</li>
            <li>Starting percentage: Median of B- range = 52%</li>
            <li>Percentage increase: From 52% to 55% (next grade B)</li>
            <li>Used 3 hours to increase from 52% to 55%</li>
            <li>Balance hours: 8.5 - 3 = 5.5 hours</li>
            <li>Required hours for B: 14 hours</li>
            <li>Not enough balance hours to increase further; next week's starting grade is B.</li>
        </ul>
    </div>

    <div class='example'>
        <h3>Example Calculation for Decreasing Grade:</h3>
        <p><strong>Current Grade:</strong> B</p>
        
        <p><strong>Study Sessions:</strong></p>
        <ul>
            <li>2024/07/14 - 3h</li>
            <li>2024/07/15 - 2h</li>
            <li>2024/07/16 - 2h</li>
            <li>2024/07/17 - 1h</li>
            <li>2024/07/18 - 2h</li>
            <li>2024/07/19 - 1h</li>
            <li>2024/07/20 - 2h</li>
        </ul>
        <p><strong>Week 2 (2024/07/14 to 2024/07/20):</strong></p>
        <ul>
            <li>Total study hours: 3 + 2 + 2 + 1 + 2 + 1 + 2 = 13 hours</li>
            <li>Required hours for B: 14 hours</li>
            <li>Missing hours: 14 - 13 = 1 hour</li>
            <li>Starting percentage: Median of B range = 59.5%</li>
            <li>Percentage decrease: No decrease since missing hours is within 25%</li>
            <li>Grade remains B.</li>
        </ul>
    </div>

    <div class='example'>
        <h3>Example Calculation for Significant Decrease:</h3>
        <p><strong>Current Grade:</strong> B</p>
        
        <p><strong>Study Sessions:</strong></p>
        <ul>
            <li>2024/07/21 - 1h</li>
            <li>2024/07/22 - 1h</li>
            <li>2024/07/23 - 1h</li>
            <li>2024/07/24 - 1h</li>
            <li>2024/07/25 - 1h</li>
            <li>2024/07/26 - 1h</li>
            <li>2024/07/27 - 1h</li>
        </ul>
        <p><strong>Week 3 (2024/07/21 to 2024/07/27):</strong></p>
        <ul>
            <li>Total study hours: 1 + 1 + 1 + 1 + 1 + 1 + 1 = 7 hours</li>
            <li>Required hours for B: 14 hours</li>
            <li>Missing hours: 14 - 7 = 7 hours</li>
            <li>Starting percentage: Min of B range = 55%</li>
            <li>Percentage decrease: Missing hours exceed 25%</li>
            <li>Grade decreases to B- with median percentage of B- range.</li>
        </ul>
    </div>

    <div class='example'>
        <h3>Example Calculation for Maintaining Grade:</h3>
        <p><strong>Current Grade:</strong> C</p>
        
        <p><strong>Study Sessions:</strong></p>
        <ul>
            <li>2024/07/07 - 2h</li>
            <li>2024/07/08 - 1h</li>
            <li>2024/07/09 - 1h</li>
            <li>2024/07/10 - 1h</li>
            <li>2024/07/11 - 1h</li>
            <li>2024/07/12 - 1h</li>
            <li>2024/07/13 - 1h</li>
        </ul>
        <p><strong>Week 1 (2024/07/07 to 2024/07/13):</strong></p>
        <ul>
            <li>Total study hours: 2 + 1 + 1 + 1 + 1 + 1 + 1 = 8 hours</li>
            <li>Required hours for C: 5.25 hours</li>
            <li>Additional hours: 8 - 5.25 = 2.75 hours</li>
            <li>Starting percentage: Median of C range = 42%</li>
            <li>Percentage increase: From 42% to 44.75% (still within C range)</li>
            <li>Balance hours: 2.75 - 2.75 = 0 hours</li>
            <li>Grade remains C.</li>
        </ul>
    </div>

    <div class='example'>
        <h3>Example Calculation for Next Week's Grade:</h3>
        <p><strong>Current Grade:</strong> A</p>
        
        <p><strong>Study Sessions:</strong></p>
        <ul>
            <li>2024/07/28 - 5h</li>
            <li>2024/07/29 - 5h</li>
            <li>2024/07/30 - 5h</li>
            <li>2024/07/31 - 5h</li>
            <li>2024/08/01 - 5h</li>
            <li>2024/08/02 - 5h</li>
            <li>2024/08/03 - 5h</li>
        </ul>
        <p><strong>Week 4 (2024/07/28 to 2024/08/03):</strong></p>
        <ul>
            <li>Total study hours: 5 * 7 = 35 hours</li>
            <li>Required hours for A: 24.5 hours</li>
            <li>Additional hours: 35 - 24.5 = 10.5 hours</li>
            <li>Starting percentage: Median of A range = 89.5%</li>
            <li>Percentage increase: From 89.5% to 95% (next grade A+)</li>
            <li>Used 5.5 hours to increase from 89.5% to 95%</li>
            <li>Balance hours: 10.5 - 5.5 = 5 hours</li>
            <li>Next week's starting grade is A+ with a new percentage of 95%.</li>
        </ul>
    </div>

    <p class='note'>Note: This logic assumes that each hour of study directly translates to a percentage increase or decrease. Real-world scenarios may require more complex calculations based on various factors.</p>
</body>
</html>";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generating HTML content: {ex.Message}");
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

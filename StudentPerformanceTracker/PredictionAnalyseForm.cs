using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Model;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentPerformanceTracker
{
    public partial class PredictionAnalyseForm : Form
    {
        public PredictionAnalyseForm()
        {
            InitializeComponent();
            InitializeFormContents();
        }

        private void InitializeFormContents()
        {
            try
            {
                subjectList.DataSource = LoadDataService.LoadStudySubjects();
                subjectList.DisplayMember = "SubjectName";
                subjectList.ValueMember = "SubjectCode";

                DefaultValue();
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing form contents: {ex.Message}");
            }
        }

        private void InitializeDataGridView()
        {
            try
            {
                dataRangeDgv.AutoGenerateColumns = false;
                dataRangeDgv.AllowUserToAddRows = false;
                AddColumnsToDataGridView();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing DataGridView: {ex.Message}");
            }
        }

        private void AddColumnsToDataGridView()
        {
            dataRangeDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Prediction.Week),
                HeaderText = "Week"
            });

            dataRangeDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Prediction.DateRange),
                HeaderText = "Date Range"
            });

            dataRangeDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Prediction.StudyHours),
                HeaderText = "Study Hours"
            });

            dataRangeDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Prediction.Percentage),
                HeaderText = "Percentage"
            });

            dataRangeDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Prediction.GradeDisplayName),
                HeaderText = "Grade"
            });
        }

        private void DefaultValue()
        {
            try
            {
                subjectList.SelectedValue = "";
                fromDateTimePicker.CustomFormat = " ";
                toDateTimePicker.CustomFormat = " ";
                dataRangeDgv.DataSource = null;
                predictedGrade.Text = "--";
                initialGrade.Text = "--";
                performanceLbl.Text = "--";
                studyHoursChart.Series.Clear();
                gradeChart.Series.Clear();
                percentageChart.Series.Clear();
                ResetDateTimePickers();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting default values: {ex.Message}");
            }
        }

        private void ResetDateTimePickers()
        {
            try
            {
                fromDateTimePicker.ValueChanged -= fromDateTimePicker_ValueChanged;
                toDateTimePicker.ValueChanged -= toDateTimePicker_ValueChanged;

                DateTime currentDate = DateTime.Now;

                fromDateTimePicker.MinDate = DateTimePicker.MinimumDateTime;
                fromDateTimePicker.MaxDate = DateTimePicker.MaximumDateTime;
                toDateTimePicker.MinDate = DateTimePicker.MinimumDateTime;
                toDateTimePicker.MaxDate = DateTimePicker.MaximumDateTime;

                fromDateTimePicker.Value = currentDate;
                toDateTimePicker.Value = currentDate;

                fromDateTimePicker.ValueChanged += fromDateTimePicker_ValueChanged;
                toDateTimePicker.ValueChanged += toDateTimePicker_ValueChanged;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error resetting date pickers: {ex.Message}");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            DefaultValue();
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private bool ValidateForm()
        {
            if (subjectList.SelectedIndex == -1 || !IsValidSubject(subjectList.SelectedValue.ToString()))
            {
                ShowErrorMessage("Please select a valid subject.");
                subjectList.Focus();
                return false;
            }

            if (fromDateTimePicker.Value == DateTimePicker.MinimumDateTime || toDateTimePicker.Value == DateTimePicker.MinimumDateTime)
            {
                ShowErrorMessage("Please select valid dates.");
                fromDateTimePicker.Focus();
                return false;
            }

            TimeSpan dateDifference = toDateTimePicker.Value.Date - fromDateTimePicker.Value.Date;
            if (dateDifference.Days < 6)
            {
                ShowErrorMessage("The date range must be at least a week.");
                fromDateTimePicker.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidSubject(string subjectCode)
        {
            foreach (var item in subjectList.Items)
            {
                if (((SubjectDTO)item).SubjectCode == subjectCode)
                {
                    return true;
                }
            }
            return false;
        }

        private async void LoadData()
        {
            try
            {
                if (!ValidateForm()) return;

                List<StudySessionDTO> sessions = await GetStudySessionList();
                if (sessions.Count == 0)
                {
                    MessageBox.Show("Study Sessions not found for tthe criteria.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
               // List<Prediction> predictions = PredictionHandlerService.PredictPerformance(GetStartDateGrade(), sessions);
                List<Prediction> predictions = PredictionHandlerService.PredictPerformance(Grade.A, sessions);

                dataRangeDgv.DataSource = new BindingList<Prediction>(predictions);
                /*initialGrade.Text = LoadDataService.ToDisplayGradeValue(GetStartDateGrade());
                predictedGrade.Text = LoadDataService.ToDisplayGradeValue(predictions[predictions.Count - 1].Grade);*/
                performanceLbl.Text = PerformanceRate(predictions);

                PlotCharts(predictions);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
        }

        private void PlotCharts(List<Prediction> predictions)
        {
            studyHoursChart.Series.Clear();
            gradeChart.Series.Clear();
            percentageChart.Series.Clear();

            if (studyHoursChart.ChartAreas.Count == 0) studyHoursChart.ChartAreas.Add(new ChartArea());
            if (gradeChart.ChartAreas.Count == 0) gradeChart.ChartAreas.Add(new ChartArea());
            if (percentageChart.ChartAreas.Count == 0) percentageChart.ChartAreas.Add(new ChartArea());

            Series studyHoursSeries = new Series("Study Hours") { ChartType = SeriesChartType.Bar, XValueType = ChartValueType.String };
            Series gradeVariationsSeries = new Series("Grade Variations") { ChartType = SeriesChartType.Bar, XValueType = ChartValueType.String };
            Series percentageSeries = new Series("Percentage") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.String };

            foreach (var prediction in predictions)
            {
                studyHoursSeries.Points.AddXY(prediction.Week, prediction.StudyHours);
                gradeVariationsSeries.Points.AddXY(prediction.Week, GetNumericValueForGrade(prediction.Grade));
                percentageSeries.Points.AddXY(prediction.Week, prediction.Percentage);
            }

            studyHoursChart.Series.Add(studyHoursSeries);
            gradeChart.Series.Add(gradeVariationsSeries);
            percentageChart.Series.Add(percentageSeries);

            studyHoursChart.Titles.Clear();
            studyHoursChart.Titles.Add("Weekly Study Hours");
            studyHoursChart.ChartAreas[0].AxisX.Title = "Week";
            studyHoursChart.ChartAreas[0].AxisY.Title = "Study Hours";

            gradeChart.Titles.Clear();
            gradeChart.Titles.Add("Weekly Grade Variations");
            gradeChart.ChartAreas[0].AxisX.Title = "Week";
            gradeChart.ChartAreas[0].AxisY.Title = "Grade (Numeric)";

            percentageChart.Titles.Clear();
            percentageChart.Titles.Add("Weekly Percentage");
            percentageChart.ChartAreas[0].AxisX.Title = "Week";
            percentageChart.ChartAreas[0].AxisY.Title = "Percentage";

            CustomizeChartAppearance();
        }

        private void CustomizeChartAppearance()
        {
            if (studyHoursChart.Legends.Count == 0) studyHoursChart.Legends.Add(new Legend());
            if (gradeChart.Legends.Count == 0) gradeChart.Legends.Add(new Legend());
            if (percentageChart.Legends.Count == 0) percentageChart.Legends.Add(new Legend());

            studyHoursChart.ChartAreas[0].AxisX.Interval = 1;
            studyHoursChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            studyHoursChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            studyHoursChart.Legends[0].Enabled = true;

            gradeChart.ChartAreas[0].AxisX.Interval = 1;
            gradeChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            gradeChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            gradeChart.Legends[0].Enabled = true;

            percentageChart.ChartAreas[0].AxisX.Interval = 1;
            percentageChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            percentageChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            percentageChart.Legends[0].Enabled = true;
        }

        private double GetNumericValueForGrade(Grade grade)
        {
            switch (grade)
            {
                case Grade.A_Plus: return 97.5;
                case Grade.A: return 89.5;
                case Grade.A_Minus: return 79.5;
                case Grade.B_Plus: return 69.5;
                case Grade.B: return 59.5;
                case Grade.B_Minus: return 52;
                case Grade.C_Plus: return 47;
                case Grade.C: return 42;
                case Grade.C_Minus: return 37;
                case Grade.E: return 17.5;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private string PerformanceRate(List<Prediction> predictions)
        {
            Grade predictedGrade = predictions[predictions.Count - 1].Grade;
            double percentageChange = GetNumericValueForGrade(predictedGrade) /*- GetNumericValueForGrade(GetStartDateGrade())*/;

            if (percentageChange == 0)
            {
                return "Good";
            }
            else if (percentageChange > 0)
            {
                return "Excellent";
            }

            return "Poor";
        }

        private async Task<List<StudySessionDTO>> GetStudySessionList()
        {
            try
            {
                string subjectCode = subjectList.SelectedValue as string;
                DateTime? fromDate = fromDateTimePicker.Value;
                DateTime? toDate = fromDateTimePicker.Value;

                return await LoadDataService.GetStudySessionListByCriteria(subjectCode, fromDate, toDate);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error retrieving study session list: {ex.Message}");
                return new List<StudySessionDTO>();
            }
        }


        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                toDateTimePicker.MinDate = fromDateTimePicker.Value;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error updating 'From' date picker: {ex.Message}");
            }
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fromDateTimePicker.MaxDate = toDateTimePicker.Value;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error updating 'To' date picker: {ex.Message}");
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task<GradeDTO> GetStartDateGrade()
        {
            if (subjectList.SelectedValue is string subjectCode)
            {
                try
                {
                    return await LoadDataService.CurrentGradeKnowledge(subjectCode, fromDateTimePicker.Value.Date);
                }
                catch (InvalidOperationException ex)
                {
                    ShowErrorMessage($"Error retrieving starting grade: {ex.Message}");
                }
            }
            throw new InvalidOperationException("Invalid subject selected.");
        }
    }
}

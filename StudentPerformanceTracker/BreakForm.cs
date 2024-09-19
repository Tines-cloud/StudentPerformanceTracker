﻿using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class BreakForm : Form
    {
        public BreakForm()
        {
            InitializeComponent();
            InitializeFormContents();
            timer1.Start();
        }

        private async void InitializeFormContents()
        {
            try
            {
                if (EventService.CurrentUser.Role.RoleName != "Admin")
                {
                    DisableDeleteButton();
                    userToolStripMenuItem.Enabled = EventService.CurrentUser.Role.RoleName == "Admin";
                }

                toolStripLabel1.Text = $"Logged in as: {EventService.CurrentUser.FirstName} ({EventService.CurrentUser.Role})";
                subjectList.DataSource = await LoadDataService.LoadStudySubjects();
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

        private void DisableDeleteButton()
        {
            deleteBtn.Enabled = false;
            deleteBtn.Cursor = Cursors.No;
            deleteBtn.BackgroundImage = Properties.Resources.not_delete;
        }

        private void InitializeDataGridView()
        {
            try
            {
                breakDgv.AutoGenerateColumns = false;
                breakDgv.AllowUserToAddRows = false;

                AddColumnsToDataGridView();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing DataGridView: {ex.Message}");
            }
        }

        private void AddColumnsToDataGridView()
        {
            breakDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BreakDTO.Id),
                HeaderText = "ID"
            });

            breakDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BreakDTO.Date),
                HeaderText = "Date"
            });

            breakDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BreakDTO.Subject.SubjectName),
                HeaderText = "Subject"
            });

            breakDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(BreakDTO.TotalDuration),
                HeaderText = "Total Break Duration"
            });
        }

        private void DefaultValue()
        {
            try
            {
                subjectList.SelectedValue = "";
                dateOptionCheckBox.Checked = false;
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
                fromDateTimePicker.CustomFormat = " ";
                toDateTimePicker.CustomFormat = " ";
                breakDgv.DataSource = null;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                toolStripLabel2.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error updating time: {ex.Message}");
            }
        }

        private async void LoadData()
        {
            try
            {
                breakDgv.DataSource = new BindingList<BreakDTO>(await GetBreakList());
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
        }

        private async Task<List<BreakDTO>> GetBreakList()
        {
            try
            {
                string subjectCode = subjectList.SelectedValue as string ?? string.Empty;
                DateTime? fromDate = dateOptionCheckBox.Checked ? fromDateTimePicker.Value : (DateTime?)null;
                DateTime? toDate = dateOptionCheckBox.Checked ? toDateTimePicker.Value : (DateTime?)null;

                return await LoadDataService.GetBreakListByCriteria(subjectCode, EventService.CurrentUser.Username, fromDate, toDate);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error retrieving break list: {ex.Message}");
                return new List<BreakDTO>();
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

        private void dateOptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateOptionCheckBox.Checked)
                {
                    fromDateTimePicker.Enabled = true;
                    toDateTimePicker.Enabled = true;
                    fromDateTimePicker.CustomFormat = "dd/MM/yyyy";
                    toDateTimePicker.CustomFormat = "dd/MM/yyyy";
                }
                else
                {
                    fromDateTimePicker.Enabled = false;
                    toDateTimePicker.Enabled = false;
                    fromDateTimePicker.CustomFormat = " ";
                    toDateTimePicker.CustomFormat = " ";
                    ResetDateTimePickers();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error handling date checkbox change: {ex.Message}");
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfirmAction("Do you want to logout?"))
                {
                    timer1.Stop();
                    new LoginForm().Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error logging out: {ex.Message}");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            DefaultValue();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = breakDgv.SelectedRows;
                if (selectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select at least one item.");
                    return;
                }

                if (ConfirmAction($"Do you want to delete these {selectedRows.Count} item(s)?"))
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.DataBoundItem is BreakDTO breakObj)
                        {
                            await EventService.RemoveBreak(breakObj.Id);
                        }
                    }
                    LoadData();
                    ShowSuccessMessage("Break record(s) deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error deleting breaks: {ex.Message}");
            }
        }

        private void ChangeForm()
        {
            try
            {
                Hide();
                timer1.Stop();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error changing form: {ex.Message}");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfirmAction("Do you want to exit?"))
                {
                    timer1.Stop();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error exiting application: {ex.Message}");
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { ChangeForm(); new MainForm().ShowDialog(); }, "Error opening home form");
        }

        private void studySessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { ChangeForm(); new StudySessionForm().Show(); }, "Error opening study sessions form");
        }

        private void knowledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { ChangeForm(); new KnowledgeForm().Show(); }, "Error opening knowledge form");
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { new SubjectForm().ShowDialog(); }, "Error opening subject form");
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { new SettingsForm().ShowDialog(); }, "Error opening settings form");
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { new UserForm().ShowDialog(); }, "Error opening user form");
        }

        private bool ConfirmAction(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowForm(Action showFormAction, string errorMessage)
        {
            try
            {
                showFormAction();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"{errorMessage}: {ex.Message}");
            }
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void predictionAndAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { new PredictionAnalyseForm().ShowDialog(); }, "Error opening prediction form");
        }

        private void rulesAndAssumptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => new RulesAssumptionsForm().ShowDialog(), "Error opening rules form");
        }
    }
}
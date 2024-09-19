using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class KnowledgeForm : Form
    {
        private List<KnowledgeDTO> knowledgeList;

        public KnowledgeForm()
        {
            InitializeComponent();
            InitializeFormContents();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel2.Text = DateTime.Now.ToString();
        }

        public void InitializeFormContents()
        {
            try
            {
                toolStripLabel1.Text = $"Logged in as: {EventService.CurrentUser.FirstName} ({EventService.CurrentUser.Role})";
             //   userToolStripMenuItem.Enabled = EventService.CurrentUser.Role.RoleName == "Admin";

                comboBox1.DataSource = LoadDataService.LoadStudySubjects();
                comboBox1.DisplayMember = "SubjectName";
                comboBox1.ValueMember = "SubjectCode";

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
                knowledgeDgv.AutoGenerateColumns = false;
                knowledgeDgv.AllowUserToAddRows = false;

                knowledgeDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(KnowledgeDTO.Id),
                    HeaderText = "ID"
                });
                knowledgeDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(KnowledgeDTO.Subject.SubjectName),
                    HeaderText = "Subject"
                });
                knowledgeDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(KnowledgeDTO.CurrentGrade.GradeName),
                    HeaderText = "Grade"
                });
                knowledgeDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(KnowledgeDTO.Date),
                    HeaderText = "Date"
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing DataGridView: {ex.Message}");
            }
        }

        public void DefaultValue()
        {
            try
            {
                comboBox1.SelectedValue = "";
                dateOptionCheckBox.Checked = false;
                fromDateTimePicker.Enabled = false;
                toDateTimePicker.Enabled = false;
                fromDateTimePicker.CustomFormat = " ";
                toDateTimePicker.CustomFormat = " ";
                knowledgeDgv.DataSource = null;
                ResetDateTimePickers();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting default values: {ex.Message}");
            }
        }

        public void ResetDateTimePickers()
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

        public async void LoadData()
        {
            try
            {
                knowledgeList = await GetKnowledgeList();
                knowledgeDgv.DataSource = new BindingList<KnowledgeDTO>(knowledgeList);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
        }

        private async Task<List<KnowledgeDTO>> GetKnowledgeList()
        {
            try
            {
                string subjectCode = comboBox1.SelectedValue as string ?? string.Empty;
                DateTime? fromDate = null;
                DateTime? toDate = null;

                if (dateOptionCheckBox.Checked)
                {
                    fromDate = fromDateTimePicker.Value;
                    toDate = toDateTimePicker.Value;
                }

                return await LoadDataService.GetKnowledgeListByCriteria(subjectCode, fromDate, toDate);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error retrieving knowledge list: {ex.Message}");
                return new List<KnowledgeDTO>();
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                KnowledgeDTO knowledge = new KnowledgeDTO
                {
                    Date = DateTime.Now.Date
                };

                AddKnowledgeForm addKnowledge = new AddKnowledgeForm(knowledge, true);
                if (addKnowledge.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error adding knowledge: {ex.Message}");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (knowledgeDgv.SelectedRows.Count > 0)
                {
                    var rowIndex = knowledgeDgv.SelectedRows[0].Index;
                    var knowledge = knowledgeList[rowIndex];

                    AddKnowledgeForm addKnowledge = new AddKnowledgeForm(knowledge, false);
                    if (addKnowledge.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else
                {
                    ShowErrorMessage("Please select a knowledge entry to edit.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error editing knowledge: {ex.Message}");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = knowledgeDgv.SelectedRows;
                if (selectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select at least one item.");
                    return;
                }

                if (ConfirmAction($"Do you want to delete these {selectedRows.Count} item(s)?"))
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.DataBoundItem is KnowledgeDTO knowledge)
                        {
                            EventService.RemoveKnowledge(knowledge.Id);
                        }
                    }
                    LoadData();
                    ShowSuccessMessage("Knowledge record(s) deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error deleting knowledge entries: {ex.Message}");
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

        private void breaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(() => { ChangeForm(); new BreakForm().Show(); }, "Error opening breaks form");
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
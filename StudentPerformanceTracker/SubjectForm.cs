using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class SubjectForm : Form
    {
        private bool _isNew;

        public SubjectForm()
        {
            InitializeComponent();
            InitializeFormContents();
        }

        private void InitializeFormContents()
        {
            try
            {
                if (EventService.CurrentUser.Role.RoleName != "Admin")
                {
                    addBtn.Visible = false;
                    editBtn.Visible = false;
                    deleteBtn.Visible = false;
                }

                subjectDgv.AutoGenerateColumns = false;
                subjectDgv.AllowUserToAddRows = false;

                subjectDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(SubjectDTO.SubjectCode),
                    HeaderText = "Subject Code"
                });

                subjectDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(SubjectDTO.SubjectName),
                    HeaderText = "Subject Name"
                });

                subjectDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(SubjectDTO.Modules),
                    HeaderText = "Modules"
                });

                DefaultValue();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing form contents: {ex.Message}");
            }
        }

        private void DefaultValue()
        {
            try
            {
                groupBox1.Enabled = false;
                groupBox1.Text = string.Empty;
                subjectCodeTxt.Text = string.Empty;
                subjectNameTxt.Text = string.Empty;
                modulesTxt.Text = string.Empty;
                LoadData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting default values: {ex.Message}");
            }
        }

        private async void LoadData()
        {
            subjectDgv.DataSource = null;
            var autoSizeColumnsMode = subjectDgv.AutoSizeColumnsMode;
            var autoSizeRowsMode = subjectDgv.AutoSizeRowsMode;

            subjectDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            subjectDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            try
            {
                var subjects = await LoadDataService.LoadStudySubjects();
                subjectDgv.DataSource = new BindingList<SubjectDTO>(subjects);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
            finally
            {
                subjectDgv.AutoSizeColumnsMode = autoSizeColumnsMode;
                subjectDgv.AutoSizeRowsMode = autoSizeRowsMode;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void subjectDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = subjectDgv.Rows[e.RowIndex];

                    if (row.DataBoundItem is SubjectDTO subject)
                    {
                        groupBox1.Enabled = false;
                        subjectCodeTxt.Text = subject.SubjectCode;
                        subjectNameTxt.Text = subject.SubjectName;
                        modulesTxt.Text = subject.Modules;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error selecting subject: {ex.Message}");
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Text = "Add";
                groupBox1.Enabled = true;
                saveBtn.Text = "Save";
                subjectCodeTxt.Enabled = true;
                _isNew = true;

                subjectCodeTxt.Text = string.Empty;
                subjectNameTxt.Text = string.Empty;
                modulesTxt.Text = string.Empty;

            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error adding subject: {ex.Message}");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (subjectDgv.SelectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select a subject to update.");
                    return;
                }

                groupBox1.Text = "Update";
                groupBox1.Enabled = true;
                saveBtn.Text = "Update";
                subjectCodeTxt.Enabled = false;
                _isNew = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error editing subject: {ex.Message}");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = subjectDgv.SelectedRows;
                if (selectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select a subject to delete.");
                    return;
                }

                if (ConfirmAction($"Do you want to delete these {selectedRows.Count} item(s)?"))
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.DataBoundItem is SubjectDTO subject)
                        {
                            EventService.RemoveSubject(subject);
                        }
                    }
                    DefaultValue();
                    ShowSuccessMessage("Subject record(s) deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error deleting subjects: {ex.Message}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    SubjectDTO subject = new SubjectDTO
                    {
                        SubjectCode = subjectCodeTxt.Text,
                        SubjectName = subjectNameTxt.Text,
                        Modules = modulesTxt.Text
                    };

                    EventService.AddOrUpdateSubject(subject, _isNew);
                    DefaultValue();
                    if (_isNew)
                    {
                        ShowSuccessMessage("Subject added successfully.");
                    }
                    else
                    {
                        ShowSuccessMessage("Subject updated successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error saving subject: {ex.Message}");
            }
        }

        private bool ValidateForm()
        {
            bool IsFieldEmpty(string fieldValue, string errorMessage, Control controlToFocus)
            {
                if (string.IsNullOrWhiteSpace(fieldValue))
                {
                    ShowErrorMessage(errorMessage);
                    controlToFocus.Focus();
                    return true;
                }
                return false;
            }

            if (IsFieldEmpty(subjectCodeTxt.Text, "Subject Code is required.", subjectCodeTxt) ||
                IsFieldEmpty(subjectNameTxt.Text, "Subject Name is required.", subjectNameTxt) ||
                IsFieldEmpty(modulesTxt.Text, "Modules field is required.", modulesTxt))
            {
                return false;
            }


            return true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DefaultValue();
        }

        private bool ConfirmAction(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
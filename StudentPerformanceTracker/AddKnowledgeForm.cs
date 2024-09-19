using SPTKnowledgeService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class AddKnowledgeForm : Form
    {
        private KnowledgeDTO Knowledge;
        private bool isNew;

        public AddKnowledgeForm(KnowledgeDTO knowledge, bool isNew)
        {
            InitializeComponent();
            this.isNew = isNew;
            this.Knowledge = knowledge;

            try
            {
                LoadData();
                InitializeForm();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing form: {ex.Message}");
            }
        }

        private void InitializeForm()
        {
            if (isNew)
            {
                Text = "Add Knowledge";
                saveBtn.Text = "Save";
                idTxt.Text = "-1";
                dateTimePicker.Value = DateTime.Now;
                subjectList.SelectedIndex = -1;
                gradeList.SelectedIndex = -1;
            }
            else
            {
                Text = "Update Knowledge";
                saveBtn.Text = "Update";
                PopulateFields();
            }

            dateTimePicker.MaxDate = DateTime.Now;
        }

        private void PopulateFields()
        {
            try
            {
                if (Knowledge != null)
                {
                    idTxt.Text = Knowledge.Id.ToString();
                    dateTimePicker.Value = Knowledge.Date;
                    subjectList.SelectedValue = Knowledge.CurrentGrade.GradeCode;

                    foreach (var item in gradeList.Items)
                    {
                        if (item is KeyValuePair<GradeDTO, string> gradeItem && gradeItem.Key == Knowledge.CurrentGrade)
                        {
                            gradeList.SelectedItem = gradeItem;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error populating fields: {ex.Message}");
            }
        }

        private void LoadData()
        {
            try
            {
                subjectList.DataSource = LoadDataService.LoadStudySubjects();
                subjectList.DisplayMember = "SubjectName";
                subjectList.ValueMember = "SubjectCode";

                gradeList.DataSource = EventService.GetEnumDisplayNames<Grade>();
                gradeList.DisplayMember = "Value";
                gradeList.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    Knowledge.Subject.SubjectCode = subjectList.SelectedValue.ToString();
                    Knowledge.CurrentGrade = ((KeyValuePair<GradeDTO, string>)gradeList.SelectedItem).Key;
                    Knowledge.Date = dateTimePicker.Value.Date;

                    EventService.AddOrUpdateKnowledge(Knowledge, isNew);

                    ShowSuccessMessage(isNew ? "Knowledge added successfully." : "Knowledge updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error saving knowledge: {ex.Message}");
            }
        }

        private bool ValidateForm()
        {
            if (dateTimePicker.Value == null || dateTimePicker.Value == DateTime.MinValue || dateTimePicker.Value > DateTime.Now)
            {
                ShowErrorMessage("Please select a valid date.");
                dateTimePicker.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(subjectList.Text))
            {
                ShowErrorMessage("Please select a subject.");
                subjectList.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(gradeList.Text))
            {
                ShowErrorMessage("Please select a grade.");
                gradeList.Focus();
                return false;
            }

            if (subjectList.SelectedIndex == -1 || !IsValidSubject(subjectList.SelectedValue.ToString()))
            {
                ShowErrorMessage("Please select a valid subject.");
                subjectList.Focus();
                return false;
            }

            if (gradeList.SelectedItem == null || !IsValidGrade(((KeyValuePair<Grade, string>)gradeList.SelectedItem).Key))
            {
                ShowErrorMessage("Please select a valid grade.");
                gradeList.Focus();
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

        private bool IsValidGrade(Grade grade)
        {
            foreach (var item in gradeList.Items)
            {
                if (((KeyValuePair<Grade, string>)item).Key.Equals(grade))
                {
                    return true;
                }
            }
            return false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
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

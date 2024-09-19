using SPTUserService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class UserForm : Form
    {
        private bool _isNew;

        public UserForm()
        {
            InitializeComponent();
            InitializeFormContents();
        }

        private void InitializeFormContents()
        {
            try
            {
                userDgv.AutoGenerateColumns = false;
                userDgv.AllowUserToAddRows = false;

                userDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(UserDTO.Username),
                    HeaderText = "Username"
                });

                userDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(UserDTO.FirstName),
                    HeaderText = "First Name"
                });

                userDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(UserDTO.Role),
                    HeaderText = "Role"
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
                usernameTxt.Text = string.Empty;
                nameTxt.Text = string.Empty;
                passwordTxt.Text = string.Empty;
                roleList.Text = string.Empty;
                LoadData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting default values: {ex.Message}");
            }
        }

        private void LoadData()
        {
            userDgv.DataSource = null;
            var autoSizeColumnsMode = userDgv.AutoSizeColumnsMode;
            var autoSizeRowsMode = userDgv.AutoSizeRowsMode;

            userDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            userDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            try
            {
                userDgv.DataSource = new BindingList<UserDTO>((System.Collections.Generic.IList<UserDTO>)LoadDataService.GetUsers());
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
            finally
            {
                userDgv.AutoSizeColumnsMode = autoSizeColumnsMode;
                userDgv.AutoSizeRowsMode = autoSizeRowsMode;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DefaultValue();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    UserDTO user = new UserDTO
                    {
                        Username = usernameTxt.Text,
                        FirstName = nameTxt.Text,
                        Password = passwordTxt.Text
                    };

                    RoleDTO roleDTO = new RoleDTO();
                    roleDTO.RoleName=roleList.Text;

                    EventService.AddOrUpdateUser(user, _isNew);
                    DefaultValue();
                    ShowSuccessMessage(_isNew ? "User added successfully." : "User updated successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error saving user: {ex.Message}");
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

            if (IsFieldEmpty(usernameTxt.Text, "Username is required.", usernameTxt) ||
                IsFieldEmpty(nameTxt.Text, "First Name is required.", nameTxt) ||
                IsFieldEmpty(passwordTxt.Text, "Password is required.", passwordTxt) ||
                IsFieldEmpty(roleList.Text, "Role is required.", roleList))
            {
                return false;
            }

            if (!roleList.Items.Contains(roleList.Text))
            {
                ShowErrorMessage("Role is invalid.");
                roleList.Focus();
                return false;
            }

            return true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Text = "Add";
                groupBox1.Enabled = true;
                saveBtn.Text = "Save";
                usernameTxt.Enabled = true;

                usernameTxt.Text = string.Empty;
                passwordTxt.Text = string.Empty;
                nameTxt.Text = string.Empty;
                roleList.Text = string.Empty;

                _isNew = true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error adding user: {ex.Message}");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userDgv.SelectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select a user to update.");
                    return;
                }

                groupBox1.Text = "Update";
                groupBox1.Enabled = true;
                saveBtn.Text = "Update";
                usernameTxt.Enabled = false;
                _isNew = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error editing user: {ex.Message}");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = userDgv.SelectedRows;
                if (selectedRows.Count == 0)
                {
                    ShowErrorMessage("Please select a user to delete.");
                    return;
                }

                if (ConfirmAction($"Do you want to delete these {selectedRows.Count} item(s)?"))
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.DataBoundItem is UserDTO user)
                        {
                            EventService.RemoveUser(user);
                        }
                    }
                    DefaultValue();
                    ShowSuccessMessage("User(s) deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error deleting users: {ex.Message}");
            }
        }

        private void userDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = userDgv.Rows[e.RowIndex];

                    if (row.DataBoundItem is UserDTO user)
                    {
                        groupBox1.Enabled = false;
                        usernameTxt.Text = user.Username;
                        nameTxt.Text = user.FirstName;
                        passwordTxt.Text = user.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error selecting user: {ex.Message}");
            }
        }

        private void showhideHidePassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordTxt.UseSystemPasswordChar)
                {
                    passwordTxt.UseSystemPasswordChar = false;
                    showhideHidePassBtn.Image = Properties.Resources.hide;
                }
                else
                {
                    passwordTxt.UseSystemPasswordChar = true;
                    showhideHidePassBtn.Image = Properties.Resources.show;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error toggling password visibility: {ex.Message}");
            }
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
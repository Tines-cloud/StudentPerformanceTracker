using SPTUserService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class SettingsForm : Form
    {
        private UserDTO User { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            try
            {
                User = EventService.CurrentUser;
                User.UserPreference = EventService.CurrentUser.UserPreference;
                InitializeValues();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing settings: {ex.Message}");
            }
        }

        private void InitializeValues()
        {
            try
            {
                focusMinutes.Value = User.UserPreference.DefFocusTime;
                breakminutes.Value = User.UserPreference.DefBreakTime;
                yesRadioBtn.Checked = User.UserPreference.Notifications;
                noRadioBtn.Checked = !User.UserPreference.Notifications;

                usernameTxt.Text = User.Username;
                firstNameTxt.Text = User.FirstName;
                passwordTxt.Text = User.Password;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing values: {ex.Message}");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeValues();
                Close();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error cancelling changes: {ex.Message}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    User.UserPreference.DefFocusTime = (int)focusMinutes.Value;
                    User.UserPreference.DefBreakTime = (int)breakminutes.Value;
                    User.UserPreference.Notifications = yesRadioBtn.Checked;

                    User.Username = usernameTxt.Text;
                    User.FirstName = firstNameTxt.Text;
                    User.Password = passwordTxt.Text;

                    EventService.SaveUser(User);

                    ShowSuccessMessage("Settings saved successfully.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error saving settings: {ex.Message}");
            }
        }

        private void showHidePassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                passwordTxt.UseSystemPasswordChar = !passwordTxt.UseSystemPasswordChar;
                showHidePassBtn.Image = passwordTxt.UseSystemPasswordChar ? Properties.Resources.show : Properties.Resources.hide;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error toggling password visibility: {ex.Message}");
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

            if (IsFieldEmpty(firstNameTxt.Text, "First Name is required.", firstNameTxt) ||
                IsFieldEmpty(passwordTxt.Text, "Password is required.", passwordTxt))
            {
                return false;
            }

            return true;
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

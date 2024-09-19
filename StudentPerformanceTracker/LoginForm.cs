using SPTUserService.DTO;
using StudentPerformanceTracker.API_Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ClearTextboxes()
        {
            usernameTxt.Clear();
            passwordTxt.Clear();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearTextboxes();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            try
            {
                var userServiceClient = new UserServiceClient();

                var user = await LoginUser(userServiceClient, username, password);

                if (user != null)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    Hide();
                }
                else
                {
                    ShowErrorMessage("Invalid username or password.");
                    ClearTextboxes();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error during login: {ex.Message}");
            }
        }

        private async Task<UserDTO> LoginUser(UserServiceClient userServiceClient, string username, string password)
        {
            try
            {
                // Attempt to login
                var loginResult = await userServiceClient.LoginAsync(username, password);

                if (loginResult != null)
                {
                    Console.WriteLine("Login successful. Fetching user details...");
                    // Fetch user details after successful login
                    var user = await userServiceClient.GetUserByUsernameAsync(username);
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    ShowErrorMessage("Invalid username or password.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error retrieving user: {ex.Message}");
                return null;
            }
        }

        private void showHidePasswordIcon_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePasswordVisibility();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error toggling password visibility: {ex.Message}");
            }
        }

        private void TogglePasswordVisibility()
        {
            if (passwordTxt.UseSystemPasswordChar)
            {
                passwordTxt.UseSystemPasswordChar = false;
                showHidePasswordIcon.Image = Properties.Resources.hide;
            }
            else
            {
                passwordTxt.UseSystemPasswordChar = true;
                showHidePasswordIcon.Image = Properties.Resources.show;
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

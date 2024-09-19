using SPTKnowledgeService.DTO;
using SPTUserService.DTO;
using StudentPerformanceTracker.Models;
using StudentPerformanceTracker.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    public partial class MainForm : Form
    {
        private DateTime startTime;
        private int totalTimeInSeconds;
        private int remainingTimeInSeconds;

        public MainForm()
        {
            InitializeComponent();
            InitializeGrids();
            LoadData();
            SetupUI();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void InitializeGrids()
        {
            try
            {
                studySessionDgv.AutoGenerateColumns = false;
                studySessionDgv.AllowUserToAddRows = false;
                breakDgv.AutoGenerateColumns = false;
                breakDgv.AllowUserToAddRows = false;

                // study session data grid view
                studySessionDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(StudySessionDTO.Date),
                    HeaderText = "Date"
                });
                studySessionDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(StudySessionDTO.Subject.SubjectName),
                    HeaderText = "Subject"
                });
                studySessionDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(StudySessionDTO.StartTime),
                    HeaderText = "Start Time"
                });
                studySessionDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(StudySessionDTO.EndTime),
                    HeaderText = "End Time"
                });
                studySessionDgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(StudySessionDTO.TotalDuration),
                    HeaderText = "Study Duration"
                });

                // break data grid view
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
                    HeaderText = "Break Duration"
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error initializing grids: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                timer3.Start();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error starting timer: {ex.Message}");
            }
        }

        private void SetupUI()
        {
            try
            {
                breakBtn.Enabled = false;
                stopBtn.Enabled = false;
                toolStripLabel1.Text = $"Logged in as: {EventService.CurrentUser.Username}";

             //   userToolStripMenuItem.Enabled = currentUser.Role.RoleName == "Admin";
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting up UI: {ex.Message}");
            }
        }

        private void LoadData()
        {
            try
            {/*
                LoadSubjectDropDown();
                studySessionDgv.DataSource = new BindingList<StudySessionDTO>();
                breakDgv.DataSource = new BindingList<BreakDTO>();
                ChangeKnowledgeLevelLabel();*/
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading data: {ex.Message}");
            }
        }

        private void LoadSubjectDropDown()
        {
            /*try
            {
                subjectList.DataSource = new object();// LoadDataService.LoadStudySubjects();
                subjectList.DisplayMember = "SubjectName";
                subjectList.ValueMember = "SubjectCode";
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading subjects: {ex.Message}");
            }*/
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventService.isStudying)
                {
                    if (ConfirmAction("Study Session is in progress. Do you want to logout?"))
                    {
                        Stop();
                    }
                }
                else if (ConfirmAction("Do you want to logout?"))
                {
                    new LoginForm().Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error logging out: {ex.Message}");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            try
            {
                if (EventService.isStudying)
                {
                    if (ConfirmAction("Study Session is in progress. Do you want to exit?"))
                    {
                        Stop();
                        Environment.Exit(0);
                        timer3.Stop();
                    }
                }
                else
                {
                    if (ConfirmAction("Do you want to exit?"))
                    {
                        Environment.Exit(0);
                        timer3.Stop();
                    }

                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error exiting application: {ex.Message}");
            }
        }

        private void subjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeKnowledgeLevelLabel();
        }

        private void ChangeKnowledgeLevelLabel()
        {
            if (subjectList.SelectedValue is string subjectCode)
            {
                try
                {
                    knowledgeLabel.Text = $"{LoadDataService.CurrentKnowledge(subjectCode)}";
                }
                catch (InvalidOperationException ex)
                {
                    knowledgeLabel.Text = ex.Message;
                }
            }
        }

        private bool IsValidSubject(string subject)
        {
            foreach (var item in subjectList.Items)
            {
                if (((SubjectDTO)item).SubjectCode == subject)
                {
                    return true;
                }
            }
            return false;
        }

        private void studyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(subjectList.Text))
                {
                    ShowErrorMessage("Please select a subject.");
                    subjectList.Focus();
                    return;
                }

                if (subjectList.SelectedIndex == -1 || !IsValidSubject(subjectList.SelectedValue.ToString()))
                {
                    ShowErrorMessage("Please select a valid subject.");
                    subjectList.Focus();
                    return;
                }

                if (subjectList.SelectedValue is string subjectCode)
                {
                    studyBtn.Enabled = false;
                    breakBtn.Enabled = true;
                    stopBtn.Enabled = true;

                    timer2.Stop();
                    breakProgressBar.Minimum = 0;
                    breakProgressBar.Maximum = 100;
                    breakProgressBar.Value = 100;
                    breakPercentageLabel.Text = "100%";

                    int userPreferredTimeInMinutes = EventService.CurrentUser.UserPreference.DefFocusTime;
                    totalTimeInSeconds = userPreferredTimeInMinutes * 60;
                    startTime = DateTime.Now;
                    remainingTimeInSeconds = totalTimeInSeconds;

                    focusProgressBar.Minimum = 0;
                    focusProgressBar.Maximum = totalTimeInSeconds;
                    focusProgressBar.Value = totalTimeInSeconds;

                    EventService.SetStudySessions(subjectCode);
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error starting study session: {ex.Message}");
            }
        }

        private void breakBtn_Click(object sender, EventArgs e)
        {
            try
            {
                studyBtn.Enabled = true;
                breakBtn.Enabled = false;
                focusProgressBar.Minimum = 0;
                focusProgressBar.Maximum = 100;
                focusProgressBar.Value = 100;
                focusPercentageLabel.Text = "100%";
                timer1.Stop();

                int userPreferredTimeInMinutes = EventService.CurrentUser.UserPreference.DefBreakTime;
                totalTimeInSeconds = userPreferredTimeInMinutes * 60;
                startTime = DateTime.Now;
                remainingTimeInSeconds = totalTimeInSeconds;

                breakProgressBar.Minimum = 0;
                breakProgressBar.Maximum = totalTimeInSeconds;
                breakProgressBar.Value = totalTimeInSeconds;

                EventService.SetBreaks();
                timer2.Start();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error starting break: {ex.Message}");
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            Stop();
        }

        public void Stop()
        {
            try
            {
                breakBtn.Enabled = false;
                studyBtn.Enabled = true;
                timer1.Stop();
                timer2.Stop();
                focusPercentageLabel.Text = "100%";
                breakPercentageLabel.Text = "100%";

                focusProgressBar.Minimum = 0;
                focusProgressBar.Maximum = 100;
                focusProgressBar.Value = 100;
                breakProgressBar.Minimum = 0;
                breakProgressBar.Maximum = 100;
                breakProgressBar.Value = 100;

                EventService.EndStudy();
                LoadData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error stopping session: {ex.Message}");
            }
        }

        public void ChangeForm()
        {
            try
            {
                Hide();
                timer3.Stop();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error changing form: {ex.Message}");
            }
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() => new SettingsForm().ShowDialog(), "Error opening settings");
        }

        private void knowledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() =>
            {
                ChangeForm();
                new KnowledgeForm().Show();
            }, "Error opening knowledge form");
        }

        private void studySessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() =>
            {
                ChangeForm();
                new StudySessionForm().Show();
            }, "Error opening study sessions form");
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() => new SubjectForm().ShowDialog(), "Error opening subject form");
        }

        private void breaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() =>
            {
                ChangeForm();
                new BreakForm().Show();
            }, "Error opening breaks form");
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() => new UserForm().ShowDialog(), "Error opening user form");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HandleTimerTick(focusProgressBar, focusPercentageLabel, timer1, "Time's up! Take a break");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            HandleTimerTick(breakProgressBar, breakPercentageLabel, timer2, "Time's up! Start study");
        }

        private void HandleTimerTick(ProgressBar progressBar, Label percentageLabel, System.Windows.Forms.Timer timer, string message)
        {
            try
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                remainingTimeInSeconds = totalTimeInSeconds - (int)elapsed.TotalSeconds;

                if (remainingTimeInSeconds >= 0)
                {
                    int remainingPercentage = (int)(((double)remainingTimeInSeconds / totalTimeInSeconds) * 100);
                    progressBar.Value = remainingTimeInSeconds;
                    percentageLabel.Text = $"{remainingPercentage}%";
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error during timer tick: {ex.Message}");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
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

        private void ShowFormWhileNotStudying(Action showFormAction, string errorMessage)
        {
            if (EventService.isStudying)
            {
                MessageBox.Show("Focus on your studies", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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
        }

        private bool ConfirmAction(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void predictionAndAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() => new PredictionAnalyseForm().ShowDialog(), "Error opening prediction form");
        }

        private void rulesAndAssumptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormWhileNotStudying(() => new RulesAssumptionsForm().ShowDialog(), "Error opening rules form");
        }
    }
}
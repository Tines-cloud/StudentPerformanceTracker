using System.Windows.Forms;

namespace StudentPerformanceTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knowledgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studySessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breaksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictionAndAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesAndAssumptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.studySessionGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.studySessionDgv = new System.Windows.Forms.DataGridView();
            this.breakGroupBox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.breakDgv = new System.Windows.Forms.DataGridView();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.userNameStatusStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.studyBtn = new System.Windows.Forms.Button();
            this.breakBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.subjectList = new System.Windows.Forms.ComboBox();
            this.subjectSelectionLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.breakPercentageLabel = new System.Windows.Forms.Label();
            this.focusPercentageLabel = new System.Windows.Forms.Label();
            this.breakProgressBar = new System.Windows.Forms.ProgressBar();
            this.focusProgressBar = new System.Windows.Forms.ProgressBar();
            this.knowledgeLabel = new System.Windows.Forms.Label();
            this.breakLabel = new System.Windows.Forms.Label();
            this.focusLabel = new System.Windows.Forms.Label();
            this.knowledgeLabelTxt = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dateTimeToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.studySessionGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studySessionDgv)).BeginInit();
            this.breakGroupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.breakDgv)).BeginInit();
            this.userNameStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.dateTimeToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.DarkMagenta;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainMenuStrip.Size = new System.Drawing.Size(1051, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Enabled = false;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knowledgeToolStripMenuItem,
            this.studySessionsToolStripMenuItem,
            this.breaksToolStripMenuItem,
            this.subjectToolStripMenuItem,
            this.predictionAndAnalysisToolStripMenuItem,
            this.rulesAndAssumptionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.viewToolStripMenuItem.Text = "Add/ View";
            // 
            // knowledgeToolStripMenuItem
            // 
            this.knowledgeToolStripMenuItem.Name = "knowledgeToolStripMenuItem";
            this.knowledgeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.knowledgeToolStripMenuItem.Text = "Knowledge";
            this.knowledgeToolStripMenuItem.Click += new System.EventHandler(this.knowledgeToolStripMenuItem_Click);
            // 
            // studySessionsToolStripMenuItem
            // 
            this.studySessionsToolStripMenuItem.Name = "studySessionsToolStripMenuItem";
            this.studySessionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.studySessionsToolStripMenuItem.Text = "Study Sessions";
            this.studySessionsToolStripMenuItem.Click += new System.EventHandler(this.studySessionsToolStripMenuItem_Click);
            // 
            // breaksToolStripMenuItem
            // 
            this.breaksToolStripMenuItem.Name = "breaksToolStripMenuItem";
            this.breaksToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.breaksToolStripMenuItem.Text = "Breaks";
            this.breaksToolStripMenuItem.Click += new System.EventHandler(this.breaksToolStripMenuItem_Click);
            // 
            // subjectToolStripMenuItem
            // 
            this.subjectToolStripMenuItem.Name = "subjectToolStripMenuItem";
            this.subjectToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.subjectToolStripMenuItem.Text = "Subject";
            this.subjectToolStripMenuItem.Click += new System.EventHandler(this.subjectToolStripMenuItem_Click);
            // 
            // predictionAndAnalysisToolStripMenuItem
            // 
            this.predictionAndAnalysisToolStripMenuItem.Name = "predictionAndAnalysisToolStripMenuItem";
            this.predictionAndAnalysisToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.predictionAndAnalysisToolStripMenuItem.Text = "Prediction and Analysis";
            this.predictionAndAnalysisToolStripMenuItem.Click += new System.EventHandler(this.predictionAndAnalysisToolStripMenuItem_Click);
            // 
            // rulesAndAssumptionsToolStripMenuItem
            // 
            this.rulesAndAssumptionsToolStripMenuItem.Name = "rulesAndAssumptionsToolStripMenuItem";
            this.rulesAndAssumptionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.rulesAndAssumptionsToolStripMenuItem.Text = "Rules and Assumptions";
            this.rulesAndAssumptionsToolStripMenuItem.Click += new System.EventHandler(this.rulesAndAssumptionsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSettingsToolStripMenuItem,
            this.userToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // userSettingsToolStripMenuItem
            // 
            this.userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            this.userSettingsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userSettingsToolStripMenuItem.Text = "User Settings";
            this.userSettingsToolStripMenuItem.Click += new System.EventHandler(this.userSettingsToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Enabled = false;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(6, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.MediumOrchid;
            this.splitContainer1.Panel1.Controls.Add(this.studySessionGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.MediumOrchid;
            this.splitContainer1.Panel2.Controls.Add(this.breakGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 280);
            this.splitContainer1.SplitterDistance = 593;
            this.splitContainer1.TabIndex = 3;
            // 
            // studySessionGroupBox
            // 
            this.studySessionGroupBox.Controls.Add(this.panel2);
            this.studySessionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studySessionGroupBox.Location = new System.Drawing.Point(9, 22);
            this.studySessionGroupBox.Name = "studySessionGroupBox";
            this.studySessionGroupBox.Size = new System.Drawing.Size(575, 245);
            this.studySessionGroupBox.TabIndex = 1;
            this.studySessionGroupBox.TabStop = false;
            this.studySessionGroupBox.Text = "Study Sessions";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.studySessionDgv);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 218);
            this.panel2.TabIndex = 0;
            // 
            // studySessionDgv
            // 
            this.studySessionDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studySessionDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.studySessionDgv.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.studySessionDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studySessionDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studySessionDgv.Location = new System.Drawing.Point(0, 0);
            this.studySessionDgv.Name = "studySessionDgv";
            this.studySessionDgv.Size = new System.Drawing.Size(563, 218);
            this.studySessionDgv.TabIndex = 1;
            // 
            // breakGroupBox
            // 
            this.breakGroupBox.Controls.Add(this.panel3);
            this.breakGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakGroupBox.Location = new System.Drawing.Point(10, 22);
            this.breakGroupBox.Name = "breakGroupBox";
            this.breakGroupBox.Size = new System.Drawing.Size(421, 245);
            this.breakGroupBox.TabIndex = 1;
            this.breakGroupBox.TabStop = false;
            this.breakGroupBox.Text = "Breaks";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.breakDgv);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.panel3.Location = new System.Drawing.Point(4, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 218);
            this.panel3.TabIndex = 0;
            // 
            // breakDgv
            // 
            this.breakDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.breakDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.breakDgv.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.breakDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.breakDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.breakDgv.Location = new System.Drawing.Point(0, 0);
            this.breakDgv.Name = "breakDgv";
            this.breakDgv.Size = new System.Drawing.Size(411, 218);
            this.breakDgv.TabIndex = 1;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Indigo;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.logoutBtn.Location = new System.Drawing.Point(974, 0);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(69, 26);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // userNameStatusStrip
            // 
            this.userNameStatusStrip.BackColor = System.Drawing.Color.DarkMagenta;
            this.userNameStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.userNameStatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.userNameStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.userNameStatusStrip.Location = new System.Drawing.Point(758, 1);
            this.userNameStatusStrip.Name = "userNameStatusStrip";
            this.userNameStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.userNameStatusStrip.Size = new System.Drawing.Size(3, 25);
            this.userNameStatusStrip.TabIndex = 7;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.Color.DarkMagenta;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 25);
            // 
            // studyBtn
            // 
            this.studyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studyBtn.Location = new System.Drawing.Point(17, 84);
            this.studyBtn.Name = "studyBtn";
            this.studyBtn.Size = new System.Drawing.Size(197, 56);
            this.studyBtn.TabIndex = 8;
            this.studyBtn.Text = "Study";
            this.studyBtn.UseVisualStyleBackColor = true;
            this.studyBtn.Click += new System.EventHandler(this.studyBtn_Click);
            // 
            // breakBtn
            // 
            this.breakBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.breakBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakBtn.Location = new System.Drawing.Point(232, 84);
            this.breakBtn.Name = "breakBtn";
            this.breakBtn.Size = new System.Drawing.Size(197, 56);
            this.breakBtn.TabIndex = 9;
            this.breakBtn.Text = "Break";
            this.breakBtn.UseVisualStyleBackColor = true;
            this.breakBtn.Click += new System.EventHandler(this.breakBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBtn.Location = new System.Drawing.Point(17, 155);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(197, 56);
            this.stopBtn.TabIndex = 10;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(232, 155);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(197, 56);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel1.Controls.Add(this.subjectList);
            this.panel1.Controls.Add(this.stopBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.subjectSelectionLabel);
            this.panel1.Controls.Add(this.breakBtn);
            this.panel1.Controls.Add(this.studyBtn);
            this.panel1.Location = new System.Drawing.Point(604, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 243);
            this.panel1.TabIndex = 12;
            // 
            // subjectList
            // 
            this.subjectList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectList.FormattingEnabled = true;
            this.subjectList.Location = new System.Drawing.Point(160, 24);
            this.subjectList.Name = "subjectList";
            this.subjectList.Size = new System.Drawing.Size(264, 28);
            this.subjectList.TabIndex = 1;
            this.subjectList.SelectedIndexChanged += new System.EventHandler(this.subjectList_SelectedIndexChanged);
            // 
            // subjectSelectionLabel
            // 
            this.subjectSelectionLabel.AutoSize = true;
            this.subjectSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectSelectionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subjectSelectionLabel.Location = new System.Drawing.Point(13, 32);
            this.subjectSelectionLabel.Name = "subjectSelectionLabel";
            this.subjectSelectionLabel.Size = new System.Drawing.Size(70, 20);
            this.subjectSelectionLabel.TabIndex = 0;
            this.subjectSelectionLabel.Text = "Subject";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel4.Controls.Add(this.breakPercentageLabel);
            this.panel4.Controls.Add(this.focusPercentageLabel);
            this.panel4.Controls.Add(this.breakProgressBar);
            this.panel4.Controls.Add(this.focusProgressBar);
            this.panel4.Controls.Add(this.knowledgeLabel);
            this.panel4.Controls.Add(this.breakLabel);
            this.panel4.Controls.Add(this.focusLabel);
            this.panel4.Controls.Add(this.knowledgeLabelTxt);
            this.panel4.Location = new System.Drawing.Point(6, 318);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(592, 243);
            this.panel4.TabIndex = 13;
            // 
            // breakPercentageLabel
            // 
            this.breakPercentageLabel.AutoSize = true;
            this.breakPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            this.breakPercentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakPercentageLabel.Location = new System.Drawing.Point(533, 155);
            this.breakPercentageLabel.Name = "breakPercentageLabel";
            this.breakPercentageLabel.Size = new System.Drawing.Size(41, 13);
            this.breakPercentageLabel.TabIndex = 7;
            this.breakPercentageLabel.Text = "100 %";
            // 
            // focusPercentageLabel
            // 
            this.focusPercentageLabel.AutoSize = true;
            this.focusPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusPercentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPercentageLabel.Location = new System.Drawing.Point(533, 93);
            this.focusPercentageLabel.Name = "focusPercentageLabel";
            this.focusPercentageLabel.Size = new System.Drawing.Size(41, 13);
            this.focusPercentageLabel.TabIndex = 6;
            this.focusPercentageLabel.Text = "100 %";
            // 
            // breakProgressBar
            // 
            this.breakProgressBar.Location = new System.Drawing.Point(159, 172);
            this.breakProgressBar.Name = "breakProgressBar";
            this.breakProgressBar.Size = new System.Drawing.Size(415, 23);
            this.breakProgressBar.TabIndex = 5;
            // 
            // focusProgressBar
            // 
            this.focusProgressBar.BackColor = System.Drawing.Color.Black;
            this.focusProgressBar.Location = new System.Drawing.Point(159, 109);
            this.focusProgressBar.Name = "focusProgressBar";
            this.focusProgressBar.Size = new System.Drawing.Size(415, 23);
            this.focusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.focusProgressBar.TabIndex = 4;
            this.focusProgressBar.Value = 100;
            // 
            // knowledgeLabel
            // 
            this.knowledgeLabel.AutoSize = true;
            this.knowledgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knowledgeLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.knowledgeLabel.Location = new System.Drawing.Point(310, 34);
            this.knowledgeLabel.Name = "knowledgeLabel";
            this.knowledgeLabel.Size = new System.Drawing.Size(29, 29);
            this.knowledgeLabel.TabIndex = 3;
            this.knowledgeLabel.Text = "A";
            // 
            // breakLabel
            // 
            this.breakLabel.AutoSize = true;
            this.breakLabel.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakLabel.Location = new System.Drawing.Point(22, 166);
            this.breakLabel.Name = "breakLabel";
            this.breakLabel.Size = new System.Drawing.Size(82, 31);
            this.breakLabel.TabIndex = 2;
            this.breakLabel.Text = "Break";
            // 
            // focusLabel
            // 
            this.focusLabel.AutoSize = true;
            this.focusLabel.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLabel.Location = new System.Drawing.Point(22, 103);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(83, 31);
            this.focusLabel.TabIndex = 1;
            this.focusLabel.Text = "Focus";
            // 
            // knowledgeLabelTxt
            // 
            this.knowledgeLabelTxt.AutoSize = true;
            this.knowledgeLabelTxt.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knowledgeLabelTxt.Location = new System.Drawing.Point(22, 32);
            this.knowledgeLabelTxt.Name = "knowledgeLabelTxt";
            this.knowledgeLabelTxt.Size = new System.Drawing.Size(296, 31);
            this.knowledgeLabelTxt.TabIndex = 0;
            this.knowledgeLabelTxt.Text = "Current Knowledge is : ";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dateTimeToolStrip
            // 
            this.dateTimeToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dateTimeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.dateTimeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.dateTimeToolStrip.Location = new System.Drawing.Point(0, 567);
            this.dateTimeToolStrip.Name = "dateTimeToolStrip";
            this.dateTimeToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.dateTimeToolStrip.Size = new System.Drawing.Size(1051, 25);
            this.dateTimeToolStrip.TabIndex = 14;
            this.dateTimeToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(1051, 592);
            this.Controls.Add(this.dateTimeToolStrip);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userNameStatusStrip);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.studySessionGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studySessionDgv)).EndInit();
            this.breakGroupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.breakDgv)).EndInit();
            this.userNameStatusStrip.ResumeLayout(false);
            this.userNameStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.dateTimeToolStrip.ResumeLayout(false);
            this.dateTimeToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSettingsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView studySessionDgv;
        private System.Windows.Forms.DataGridView breakDgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.ToolStrip userNameStatusStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem knowledgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studySessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breaksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectToolStripMenuItem;
        private System.Windows.Forms.Button studyBtn;
        private System.Windows.Forms.Button breakBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label subjectSelectionLabel;
        private System.Windows.Forms.ComboBox subjectList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label breakLabel;
        private System.Windows.Forms.Label focusLabel;
        private System.Windows.Forms.Label knowledgeLabelTxt;
        private System.Windows.Forms.ProgressBar breakProgressBar;
        private System.Windows.Forms.ProgressBar focusProgressBar;
        private System.Windows.Forms.Label knowledgeLabel;
        private Label focusPercentageLabel;
        private Label breakPercentageLabel;
        private Timer timer2;
        private ToolStrip dateTimeToolStrip;
        private ToolStripLabel toolStripLabel2;
        private Timer timer3;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox studySessionGroupBox;
        private GroupBox breakGroupBox;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem predictionAndAnalysisToolStripMenuItem;
        private ToolStripMenuItem rulesAndAssumptionsToolStripMenuItem;
    }
}
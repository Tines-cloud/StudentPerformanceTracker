namespace StudentPerformanceTracker
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.saveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.breakminutes = new System.Windows.Forms.NumericUpDown();
            this.focusMinutes = new System.Windows.Forms.NumericUpDown();
            this.noRadioBtn = new System.Windows.Forms.RadioButton();
            this.yesRadioBtn = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showHidePassBtn = new System.Windows.Forms.PictureBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.breakminutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusMinutes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showHidePassBtn)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(209, 345);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(118, 34);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "First Name";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTxt.Location = new System.Drawing.Point(142, 64);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(204, 22);
            this.firstNameTxt.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(7, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 148);
            this.panel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MediumOrchid;
            this.groupBox2.Controls.Add(this.breakminutes);
            this.groupBox2.Controls.Add(this.focusMinutes);
            this.groupBox2.Controls.Add(this.noRadioBtn);
            this.groupBox2.Controls.Add(this.yesRadioBtn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 136);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // breakminutes
            // 
            this.breakminutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.breakminutes.Location = new System.Drawing.Point(229, 61);
            this.breakminutes.Name = "breakminutes";
            this.breakminutes.Size = new System.Drawing.Size(117, 22);
            this.breakminutes.TabIndex = 10;
            // 
            // focusMinutes
            // 
            this.focusMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.focusMinutes.Location = new System.Drawing.Point(229, 20);
            this.focusMinutes.Name = "focusMinutes";
            this.focusMinutes.Size = new System.Drawing.Size(117, 22);
            this.focusMinutes.TabIndex = 9;
            // 
            // noRadioBtn
            // 
            this.noRadioBtn.AutoSize = true;
            this.noRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.noRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.noRadioBtn.Location = new System.Drawing.Point(303, 100);
            this.noRadioBtn.Name = "noRadioBtn";
            this.noRadioBtn.Size = new System.Drawing.Size(43, 20);
            this.noRadioBtn.TabIndex = 8;
            this.noRadioBtn.TabStop = true;
            this.noRadioBtn.Text = "No";
            this.noRadioBtn.UseVisualStyleBackColor = true;
            // 
            // yesRadioBtn
            // 
            this.yesRadioBtn.AutoSize = true;
            this.yesRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yesRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.yesRadioBtn.Location = new System.Drawing.Point(229, 100);
            this.yesRadioBtn.Name = "yesRadioBtn";
            this.yesRadioBtn.Size = new System.Drawing.Size(49, 20);
            this.yesRadioBtn.TabIndex = 7;
            this.yesRadioBtn.TabStop = true;
            this.yesRadioBtn.Text = "Yes";
            this.yesRadioBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Receive Notifications";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Break Time Duration (min)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Focus Time Duration (min)";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(62, 345);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(118, 34);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumOrchid;
            this.groupBox1.Controls.Add(this.showHidePassBtn);
            this.groupBox1.Controls.Add(this.passwordTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.firstNameTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.usernameTxt);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 144);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // showHidePassBtn
            // 
            this.showHidePassBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showHidePassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showHidePassBtn.Image = global::StudentPerformanceTracker.Properties.Resources.show;
            this.showHidePassBtn.Location = new System.Drawing.Point(320, 105);
            this.showHidePassBtn.Name = "showHidePassBtn";
            this.showHidePassBtn.Size = new System.Drawing.Size(20, 20);
            this.showHidePassBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showHidePassBtn.TabIndex = 9;
            this.showHidePassBtn.TabStop = false;
            this.showHidePassBtn.Click += new System.EventHandler(this.showHidePassBtn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.passwordTxt.Location = new System.Drawing.Point(142, 104);
            this.passwordTxt.MaxLength = 15;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(204, 22);
            this.passwordTxt.TabIndex = 8;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Enabled = false;
            this.usernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxt.Location = new System.Drawing.Point(142, 22);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(204, 22);
            this.usernameTxt.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(7, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 160);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.saveBtn);
            this.panel3.Controls.Add(this.cancelBtn);
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 391);
            this.panel3.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 334);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(404, 400);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.breakminutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusMinutes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showHidePassBtn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstNameTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton noRadioBtn;
        private System.Windows.Forms.RadioButton yesRadioBtn;
        private System.Windows.Forms.NumericUpDown focusMinutes;
        private System.Windows.Forms.NumericUpDown breakminutes;
        private System.Windows.Forms.PictureBox showHidePassBtn;
        private System.Windows.Forms.TextBox passwordTxt;
    }
}
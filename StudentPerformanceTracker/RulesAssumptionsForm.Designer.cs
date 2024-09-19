namespace StudentPerformanceTracker
{
    partial class RulesAssumptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesAssumptionsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowserRules1 = new System.Windows.Forms.WebBrowser();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowserRules1);
            this.panel1.Location = new System.Drawing.Point(6, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 674);
            this.panel1.TabIndex = 0;
            // 
            // webBrowserRules1
            // 
            this.webBrowserRules1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserRules1.Location = new System.Drawing.Point(0, 0);
            this.webBrowserRules1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserRules1.Name = "webBrowserRules1";
            this.webBrowserRules1.Size = new System.Drawing.Size(903, 674);
            this.webBrowserRules1.TabIndex = 3;
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Location = new System.Drawing.Point(7, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(103, 35);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // RulesAssumptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(915, 733);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RulesAssumptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rules & Assumptions";
            this.Load += new System.EventHandler(this.RulesAssumptions_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.WebBrowser webBrowserRules1;
    }
}
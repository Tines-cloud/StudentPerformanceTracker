namespace StudentPerformanceTracker
{
    partial class PredictionAnalyseForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredictionAnalyseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.predictBtn = new System.Windows.Forms.Button();
            this.subjectList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.weekDaterangeGB = new System.Windows.Forms.GroupBox();
            this.StudyHoursGB = new System.Windows.Forms.GroupBox();
            this.gradeGB = new System.Windows.Forms.GroupBox();
            this.percentageGB = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.initialGrade = new System.Windows.Forms.Label();
            this.predictedGrade = new System.Windows.Forms.Label();
            this.performanceLbl = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataRangeDgv = new System.Windows.Forms.DataGridView();
            this.studyHoursChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gradeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.percentageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.weekDaterangeGB.SuspendLayout();
            this.StudyHoursGB.SuspendLayout();
            this.gradeGB.SuspendLayout();
            this.percentageGB.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRangeDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyHoursChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 80);
            this.panel1.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Purple;
            this.panel3.Controls.Add(this.toDateTimePicker);
            this.panel3.Controls.Add(this.fromDateTimePicker);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.subjectList);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(10, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1315, 62);
            this.panel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(383, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(681, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(649, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "From";
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(130, 16);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(97, 28);
            this.resetBtn.TabIndex = 7;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // predictBtn
            // 
            this.predictBtn.BackColor = System.Drawing.Color.Transparent;
            this.predictBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.predictBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictBtn.Location = new System.Drawing.Point(12, 16);
            this.predictBtn.Name = "predictBtn";
            this.predictBtn.Size = new System.Drawing.Size(97, 27);
            this.predictBtn.TabIndex = 6;
            this.predictBtn.Text = "Predict";
            this.predictBtn.UseVisualStyleBackColor = false;
            this.predictBtn.Click += new System.EventHandler(this.predictBtn_Click);
            // 
            // subjectList
            // 
            this.subjectList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectList.FormattingEnabled = true;
            this.subjectList.Location = new System.Drawing.Point(100, 21);
            this.subjectList.Name = "subjectList";
            this.subjectList.Size = new System.Drawing.Size(210, 24);
            this.subjectList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = ":";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel2.Controls.Add(this.percentageGB);
            this.panel2.Controls.Add(this.gradeGB);
            this.panel2.Controls.Add(this.StudyHoursGB);
            this.panel2.Controls.Add(this.weekDaterangeGB);
            this.panel2.Location = new System.Drawing.Point(12, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1339, 701);
            this.panel2.TabIndex = 35;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(248, 16);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(97, 28);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeBtn);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.predictBtn);
            this.groupBox1.Location = new System.Drawing.Point(946, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 56);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // weekDaterangeGB
            // 
            this.weekDaterangeGB.Controls.Add(this.dataRangeDgv);
            this.weekDaterangeGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekDaterangeGB.Location = new System.Drawing.Point(14, 6);
            this.weekDaterangeGB.Name = "weekDaterangeGB";
            this.weekDaterangeGB.Size = new System.Drawing.Size(648, 341);
            this.weekDaterangeGB.TabIndex = 0;
            this.weekDaterangeGB.TabStop = false;
            this.weekDaterangeGB.Text = "Weekly status";
            // 
            // StudyHoursGB
            // 
            this.StudyHoursGB.Controls.Add(this.studyHoursChart);
            this.StudyHoursGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudyHoursGB.Location = new System.Drawing.Point(677, 6);
            this.StudyHoursGB.Name = "StudyHoursGB";
            this.StudyHoursGB.Size = new System.Drawing.Size(648, 341);
            this.StudyHoursGB.TabIndex = 1;
            this.StudyHoursGB.TabStop = false;
            this.StudyHoursGB.Text = "Study Hours";
            // 
            // gradeGB
            // 
            this.gradeGB.Controls.Add(this.gradeChart);
            this.gradeGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeGB.Location = new System.Drawing.Point(14, 353);
            this.gradeGB.Name = "gradeGB";
            this.gradeGB.Size = new System.Drawing.Size(648, 341);
            this.gradeGB.TabIndex = 2;
            this.gradeGB.TabStop = false;
            this.gradeGB.Text = "Grade Prediction";
            // 
            // percentageGB
            // 
            this.percentageGB.Controls.Add(this.percentageChart);
            this.percentageGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageGB.Location = new System.Drawing.Point(677, 353);
            this.percentageGB.Name = "percentageGB";
            this.percentageGB.Size = new System.Drawing.Size(648, 341);
            this.percentageGB.TabIndex = 3;
            this.percentageGB.TabStop = false;
            this.percentageGB.Text = "Markes Percentage Prediction";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel4.Controls.Add(this.performanceLbl);
            this.panel4.Controls.Add(this.predictedGrade);
            this.panel4.Controls.Add(this.initialGrade);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(12, 98);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1339, 67);
            this.panel4.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Initial Grade : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(431, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Predicted Grade : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(911, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 28);
            this.label9.TabIndex = 2;
            this.label9.Text = "Student Performance : ";
            // 
            // initialGrade
            // 
            this.initialGrade.AutoSize = true;
            this.initialGrade.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialGrade.ForeColor = System.Drawing.Color.GhostWhite;
            this.initialGrade.Location = new System.Drawing.Point(192, 19);
            this.initialGrade.Name = "initialGrade";
            this.initialGrade.Size = new System.Drawing.Size(30, 28);
            this.initialGrade.TabIndex = 3;
            this.initialGrade.Text = "--";
            // 
            // predictedGrade
            // 
            this.predictedGrade.AutoSize = true;
            this.predictedGrade.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictedGrade.ForeColor = System.Drawing.Color.GhostWhite;
            this.predictedGrade.Location = new System.Drawing.Point(637, 19);
            this.predictedGrade.Name = "predictedGrade";
            this.predictedGrade.Size = new System.Drawing.Size(30, 28);
            this.predictedGrade.TabIndex = 4;
            this.predictedGrade.Text = "--";
            // 
            // performanceLbl
            // 
            this.performanceLbl.AutoSize = true;
            this.performanceLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performanceLbl.ForeColor = System.Drawing.Color.GhostWhite;
            this.performanceLbl.Location = new System.Drawing.Point(1175, 19);
            this.performanceLbl.Name = "performanceLbl";
            this.performanceLbl.Size = new System.Drawing.Size(30, 28);
            this.performanceLbl.TabIndex = 5;
            this.performanceLbl.Text = "--";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Location = new System.Drawing.Point(402, 22);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(226, 22);
            this.fromDateTimePicker.TabIndex = 10;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTimePicker.Location = new System.Drawing.Point(700, 21);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(226, 22);
            this.toDateTimePicker.TabIndex = 11;
            // 
            // dataRangeDgv
            // 
            this.dataRangeDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataRangeDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataRangeDgv.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.dataRangeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRangeDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataRangeDgv.Location = new System.Drawing.Point(3, 18);
            this.dataRangeDgv.Name = "dataRangeDgv";
            this.dataRangeDgv.Size = new System.Drawing.Size(642, 320);
            this.dataRangeDgv.TabIndex = 3;
            // 
            // studyHoursChart
            // 
            this.studyHoursChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studyHoursChart.Location = new System.Drawing.Point(3, 18);
            this.studyHoursChart.Name = "studyHoursChart";
            series2.Name = "Series1";
            this.studyHoursChart.Series.Add(series2);
            this.studyHoursChart.Size = new System.Drawing.Size(642, 320);
            this.studyHoursChart.TabIndex = 0;
            this.studyHoursChart.Text = "chart1";
            // 
            // gradeChart
            // 
            chartArea1.Name = "ChartArea1";
            this.gradeChart.ChartAreas.Add(chartArea1);
            this.gradeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeChart.Location = new System.Drawing.Point(3, 18);
            this.gradeChart.Name = "gradeChart";
            this.gradeChart.Size = new System.Drawing.Size(642, 320);
            this.gradeChart.TabIndex = 0;
            this.gradeChart.Text = "chart1";
            // 
            // percentageChart
            // 
            this.percentageChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageChart.Location = new System.Drawing.Point(3, 18);
            this.percentageChart.Name = "percentageChart";
            series1.Name = "Series1";
            this.percentageChart.Series.Add(series1);
            this.percentageChart.Size = new System.Drawing.Size(642, 320);
            this.percentageChart.TabIndex = 1;
            this.percentageChart.Text = "chart1";
            // 
            // PredictionAnalyseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(1359, 882);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PredictionAnalyseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prediction and Analyse";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.weekDaterangeGB.ResumeLayout(false);
            this.StudyHoursGB.ResumeLayout(false);
            this.gradeGB.ResumeLayout(false);
            this.percentageGB.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRangeDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyHoursChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button predictBtn;
        private System.Windows.Forms.ComboBox subjectList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox percentageGB;
        private System.Windows.Forms.GroupBox gradeGB;
        private System.Windows.Forms.GroupBox StudyHoursGB;
        private System.Windows.Forms.GroupBox weekDaterangeGB;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label performanceLbl;
        private System.Windows.Forms.Label predictedGrade;
        private System.Windows.Forms.Label initialGrade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DataGridView dataRangeDgv;
        private System.Windows.Forms.DataVisualization.Charting.Chart studyHoursChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart percentageChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart gradeChart;
    }
}
namespace Milburn_Software2
{
    partial class ReportsForm
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
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.numApptTypeRpt = new System.Windows.Forms.Button();
            this.schedulePerConsultRpt = new System.Windows.Forms.Button();
            this.numCustomersPerMonthRpt = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDataGridView.Location = new System.Drawing.Point(12, 145);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.RowHeadersWidth = 62;
            this.reportDataGridView.RowTemplate.Height = 28;
            this.reportDataGridView.Size = new System.Drawing.Size(1084, 468);
            this.reportDataGridView.TabIndex = 0;
            // 
            // numApptTypeRpt
            // 
            this.numApptTypeRpt.Location = new System.Drawing.Point(12, 33);
            this.numApptTypeRpt.Name = "numApptTypeRpt";
            this.numApptTypeRpt.Size = new System.Drawing.Size(267, 92);
            this.numApptTypeRpt.TabIndex = 1;
            this.numApptTypeRpt.Text = "Number of Appointment Types by Month";
            this.numApptTypeRpt.UseVisualStyleBackColor = true;
            this.numApptTypeRpt.Click += new System.EventHandler(this.numApptTypeRpt_Click);
            // 
            // schedulePerConsultRpt
            // 
            this.schedulePerConsultRpt.Location = new System.Drawing.Point(285, 33);
            this.schedulePerConsultRpt.Name = "schedulePerConsultRpt";
            this.schedulePerConsultRpt.Size = new System.Drawing.Size(267, 92);
            this.schedulePerConsultRpt.TabIndex = 2;
            this.schedulePerConsultRpt.Text = "Schedule Per Consultant";
            this.schedulePerConsultRpt.UseVisualStyleBackColor = true;
            this.schedulePerConsultRpt.Click += new System.EventHandler(this.schedulePerConsultRpt_Click);
            // 
            // numCustomersPerMonthRpt
            // 
            this.numCustomersPerMonthRpt.Location = new System.Drawing.Point(558, 33);
            this.numCustomersPerMonthRpt.Name = "numCustomersPerMonthRpt";
            this.numCustomersPerMonthRpt.Size = new System.Drawing.Size(267, 92);
            this.numCustomersPerMonthRpt.TabIndex = 3;
            this.numCustomersPerMonthRpt.Text = "Number of Customers Per Month";
            this.numCustomersPerMonthRpt.UseVisualStyleBackColor = true;
            this.numCustomersPerMonthRpt.Click += new System.EventHandler(this.numCustomersPerMonthRpt_Click);
            // 
            // goBackBtn
            // 
            this.goBackBtn.Location = new System.Drawing.Point(831, 33);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(265, 92);
            this.goBackBtn.TabIndex = 4;
            this.goBackBtn.Text = "Go Back";
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBackBtn_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 637);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.numCustomersPerMonthRpt);
            this.Controls.Add(this.schedulePerConsultRpt);
            this.Controls.Add(this.numApptTypeRpt);
            this.Controls.Add(this.reportDataGridView);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reportDataGridView;
        private System.Windows.Forms.Button numApptTypeRpt;
        private System.Windows.Forms.Button schedulePerConsultRpt;
        private System.Windows.Forms.Button numCustomersPerMonthRpt;
        private System.Windows.Forms.Button goBackBtn;
    }
}
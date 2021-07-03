namespace Milburn_Software2
{
    partial class CustomerForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.customerNameInput = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressInput1 = new System.Windows.Forms.TextBox();
            this.address2Label = new System.Windows.Forms.Label();
            this.addressInput2 = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityInput = new System.Windows.Forms.TextBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.postalCodeInput = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneInput = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.countryDD = new System.Windows.Forms.ComboBox();
            this.addressIdInput = new System.Windows.Forms.TextBox();
            this.customerIdInput = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(29, 32);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // customerNameInput
            // 
            this.customerNameInput.Location = new System.Drawing.Point(130, 31);
            this.customerNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.customerNameInput.Name = "customerNameInput";
            this.customerNameInput.Size = new System.Drawing.Size(193, 20);
            this.customerNameInput.TabIndex = 1;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(29, 61);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address";
            // 
            // addressInput1
            // 
            this.addressInput1.Location = new System.Drawing.Point(130, 59);
            this.addressInput1.Margin = new System.Windows.Forms.Padding(2);
            this.addressInput1.Name = "addressInput1";
            this.addressInput1.Size = new System.Drawing.Size(193, 20);
            this.addressInput1.TabIndex = 3;
            // 
            // address2Label
            // 
            this.address2Label.AutoSize = true;
            this.address2Label.Location = new System.Drawing.Point(29, 90);
            this.address2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.address2Label.Name = "address2Label";
            this.address2Label.Size = new System.Drawing.Size(54, 13);
            this.address2Label.TabIndex = 4;
            this.address2Label.Text = "Address 2";
            // 
            // addressInput2
            // 
            this.addressInput2.Location = new System.Drawing.Point(130, 88);
            this.addressInput2.Margin = new System.Windows.Forms.Padding(2);
            this.addressInput2.Name = "addressInput2";
            this.addressInput2.Size = new System.Drawing.Size(193, 20);
            this.addressInput2.TabIndex = 5;
            this.addressInput2.Tag = "pass";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(29, 118);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 6;
            this.cityLabel.Text = "City";
            // 
            // cityInput
            // 
            this.cityInput.Location = new System.Drawing.Point(130, 116);
            this.cityInput.Margin = new System.Windows.Forms.Padding(2);
            this.cityInput.Name = "cityInput";
            this.cityInput.Size = new System.Drawing.Size(193, 20);
            this.cityInput.TabIndex = 7;
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Location = new System.Drawing.Point(29, 145);
            this.postalCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(64, 13);
            this.postalCodeLabel.TabIndex = 8;
            this.postalCodeLabel.Text = "Postal Code";
            // 
            // postalCodeInput
            // 
            this.postalCodeInput.Location = new System.Drawing.Point(130, 143);
            this.postalCodeInput.Margin = new System.Windows.Forms.Padding(2);
            this.postalCodeInput.Name = "postalCodeInput";
            this.postalCodeInput.Size = new System.Drawing.Size(193, 20);
            this.postalCodeInput.TabIndex = 9;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(29, 172);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(43, 13);
            this.countryLabel.TabIndex = 10;
            this.countryLabel.Text = "Country";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(29, 200);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 12;
            this.phoneLabel.Text = "Phone";
            // 
            // phoneInput
            // 
            this.phoneInput.Location = new System.Drawing.Point(130, 198);
            this.phoneInput.Margin = new System.Windows.Forms.Padding(2);
            this.phoneInput.Name = "phoneInput";
            this.phoneInput.Size = new System.Drawing.Size(193, 20);
            this.phoneInput.TabIndex = 13;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(157, 237);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(77, 21);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(245, 237);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(77, 21);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // countryDD
            // 
            this.countryDD.FormattingEnabled = true;
            this.countryDD.Location = new System.Drawing.Point(130, 170);
            this.countryDD.Margin = new System.Windows.Forms.Padding(2);
            this.countryDD.Name = "countryDD";
            this.countryDD.Size = new System.Drawing.Size(193, 21);
            this.countryDD.TabIndex = 16;
            // 
            // addressIdInput
            // 
            this.addressIdInput.Location = new System.Drawing.Point(130, 8);
            this.addressIdInput.Margin = new System.Windows.Forms.Padding(2);
            this.addressIdInput.Name = "addressIdInput";
            this.addressIdInput.Size = new System.Drawing.Size(68, 20);
            this.addressIdInput.TabIndex = 17;
            this.addressIdInput.Visible = false;
            // 
            // customerIdInput
            // 
            this.customerIdInput.Location = new System.Drawing.Point(207, 8);
            this.customerIdInput.Margin = new System.Windows.Forms.Padding(2);
            this.customerIdInput.Name = "customerIdInput";
            this.customerIdInput.Size = new System.Drawing.Size(68, 20);
            this.customerIdInput.TabIndex = 18;
            this.customerIdInput.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 270);
            this.Controls.Add(this.customerIdInput);
            this.Controls.Add(this.addressIdInput);
            this.Controls.Add(this.countryDD);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.phoneInput);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.postalCodeInput);
            this.Controls.Add(this.postalCodeLabel);
            this.Controls.Add(this.cityInput);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressInput2);
            this.Controls.Add(this.address2Label);
            this.Controls.Add(this.addressInput1);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.customerNameInput);
            this.Controls.Add(this.nameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox customerNameInput;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressInput1;
        private System.Windows.Forms.Label address2Label;
        private System.Windows.Forms.TextBox addressInput2;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityInput;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.TextBox postalCodeInput;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneInput;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox countryDD;
        private System.Windows.Forms.TextBox addressIdInput;
        private System.Windows.Forms.TextBox customerIdInput;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
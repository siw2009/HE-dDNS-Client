namespace dDNS_Client
{
    partial class RateSettings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateSettings));
            RateForm = new TextBox();
            RateLabel = new Label();
            OKButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // RateForm
            // 
            RateForm.Location = new Point(25, 35);
            RateForm.MaxLength = 255;
            RateForm.Name = "RateForm";
            RateForm.PlaceholderText = "Enter the refresh rate for syncing to dDNS service";
            RateForm.Size = new Size(340, 23);
            RateForm.TabIndex = 1;
            // 
            // RateLabel
            // 
            RateLabel.AutoSize = true;
            RateLabel.Location = new Point(25, 15);
            RateLabel.Name = "RateLabel";
            RateLabel.Size = new Size(319, 15);
            RateLabel.TabIndex = 2;
            RateLabel.Text = "Time interval (in seconds) between each sync to dDNS host";
            // 
            // OKButton
            // 
            OKButton.Location = new Point(75, 75);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(95, 40);
            OKButton.TabIndex = 5;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(220, 75);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(95, 40);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // RateSettings
            // 
            AcceptButton = OKButton;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(RateLabel);
            Controls.Add(RateForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RateSettings";
            Padding = new Padding(25, 15, 25, 25);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dDNS Refresh Rate Settings";
            TopMost = true;
            Load += Loadup;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox RateForm;
        private Label RateLabel;
        private Button OKButton;
        private Button CancelButton;
    }
}

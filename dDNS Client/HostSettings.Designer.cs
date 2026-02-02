namespace dDNS_Client
{
    partial class HostSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostSettings));
            HostForm = new TextBox();
            HostLabel = new Label();
            OKButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // HostForm
            // 
            HostForm.Location = new Point(25, 35);
            HostForm.MaxLength = 255;
            HostForm.Name = "HostForm";
            HostForm.PlaceholderText = "Enter the domain name for dDNS service provider";
            HostForm.Size = new Size(340, 23);
            HostForm.TabIndex = 1;
            // 
            // HostLabel
            // 
            HostLabel.AutoSize = true;
            HostLabel.Location = new Point(25, 15);
            HostLabel.Name = "HostLabel";
            HostLabel.Size = new Size(195, 15);
            HostLabel.TabIndex = 2;
            HostLabel.Text = "Hurricane Electric service hostname";
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
            // HostSettings
            // 
            AcceptButton = OKButton;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(HostLabel);
            Controls.Add(HostForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "HostSettings";
            Padding = new Padding(25, 15, 25, 25);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dDNS Host Settings";
            TopMost = true;
            Load += Loadup;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HostForm;
        private Label HostLabel;
        private Button OKButton;
        private Button CancelButton;
    }
}

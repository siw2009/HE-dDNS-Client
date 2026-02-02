namespace dDNS_Client
{
    partial class TargetSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetSettings));
            TargetForm = new TextBox();
            TargetLabel = new Label();
            TokenLabel = new Label();
            TokenForm = new TextBox();
            OKButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // TargetForm
            // 
            TargetForm.Location = new Point(25, 35);
            TargetForm.MaxLength = 255;
            TargetForm.Name = "TargetForm";
            TargetForm.PlaceholderText = "Enter the domain name registered for dDNS service";
            TargetForm.Size = new Size(340, 23);
            TargetForm.TabIndex = 1;
            // 
            // TargetLabel
            // 
            TargetLabel.AutoSize = true;
            TargetLabel.Location = new Point(25, 15);
            TargetLabel.Name = "TargetLabel";
            TargetLabel.Size = new Size(115, 15);
            TargetLabel.TabIndex = 2;
            TargetLabel.Text = "dDNS target domain";
            // 
            // TokenLabel
            // 
            TokenLabel.AutoSize = true;
            TokenLabel.Location = new Point(25, 70);
            TokenLabel.Name = "TokenLabel";
            TokenLabel.Size = new Size(72, 15);
            TokenLabel.TabIndex = 3;
            TokenLabel.Text = "dDNS Token";
            // 
            // TokenForm
            // 
            TokenForm.Location = new Point(25, 90);
            TokenForm.MaxLength = 255;
            TokenForm.Name = "TokenForm";
            TokenForm.PlaceholderText = "Enter assigned dDNS token here";
            TokenForm.Size = new Size(340, 23);
            TokenForm.TabIndex = 4;
            TokenForm.UseSystemPasswordChar = true;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(75, 130);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(95, 40);
            OKButton.TabIndex = 5;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(220, 130);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(95, 40);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // TargetSettings
            // 
            AcceptButton = OKButton;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(TokenForm);
            Controls.Add(TokenLabel);
            Controls.Add(TargetLabel);
            Controls.Add(TargetForm);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TargetSettings";
            Padding = new Padding(25, 15, 25, 25);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dDNS Target Settings";
            TopMost = true;
            Load += Loadup;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TargetForm;
        private Label TargetLabel;
        private Label TokenLabel;
        private TextBox TokenForm;
        private Button OKButton;
        private Button CancelButton;
    }
}

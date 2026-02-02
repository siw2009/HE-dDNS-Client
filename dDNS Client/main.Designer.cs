namespace dDNS_Client
{
    partial class main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            SystemTray = new NotifyIcon(components);
            MainMenu = new ContextMenuStrip(components);
            pauseToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            hEDDNSHostToolStripMenuItem = new ToolStripMenuItem();
            targetToolStripMenuItem = new ToolStripMenuItem();
            refreshRateToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            RefreshTimer = new System.Windows.Forms.Timer(components);
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // SystemTray
            // 
            SystemTray.ContextMenuStrip = MainMenu;
            SystemTray.Icon = (Icon)resources.GetObject("SystemTray.Icon");
            SystemTray.Visible = true;
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { pauseToolStripMenuItem, updateToolStripMenuItem, settingsToolStripMenuItem, quitToolStripMenuItem });
            MainMenu.Name = "contextMenuStrip1";
            MainMenu.Size = new Size(117, 92);
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Image = Properties.Resources.Pause;
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(116, 22);
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Image = Properties.Resources.Update;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(116, 22);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hEDDNSHostToolStripMenuItem, targetToolStripMenuItem, refreshRateToolStripMenuItem });
            settingsToolStripMenuItem.Image = Properties.Resources.Settings;
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // hEDDNSHostToolStripMenuItem
            // 
            hEDDNSHostToolStripMenuItem.Name = "hEDDNSHostToolStripMenuItem";
            hEDDNSHostToolStripMenuItem.Size = new Size(180, 22);
            hEDDNSHostToolStripMenuItem.Text = "HE dDNS Host";
            hEDDNSHostToolStripMenuItem.Click += hEDDNSHostToolStripMenuItem_Click;
            // 
            // targetToolStripMenuItem
            // 
            targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            targetToolStripMenuItem.Size = new Size(180, 22);
            targetToolStripMenuItem.Text = "Target";
            targetToolStripMenuItem.Click += targetToolStripMenuItem_Click;
            // 
            // refreshRateToolStripMenuItem
            // 
            refreshRateToolStripMenuItem.Name = "refreshRateToolStripMenuItem";
            refreshRateToolStripMenuItem.Size = new Size(180, 22);
            refreshRateToolStripMenuItem.Text = "Refresh rate";
            refreshRateToolStripMenuItem.Click += refreshRateToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Image = Properties.Resources.Quit;
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(116, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += Quit;
            // 
            // RefreshTimer
            // 
            RefreshTimer.Tick += RefreshTimer_Tick;
            // 
            // main
            // 
            ClientSize = new Size(800, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "main";
            Text = "dDNS Client";
            Load += HideWindows;
            Shown += HideWindows;
            MainMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon SystemTray;
        private ContextMenuStrip MainMenu;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem hEDDNSHostToolStripMenuItem;
        private ToolStripMenuItem targetToolStripMenuItem;
        private ToolStripMenuItem refreshRateToolStripMenuItem;
        private System.Windows.Forms.Timer RefreshTimer;
        private ToolStripMenuItem pauseToolStripMenuItem;
    }
}

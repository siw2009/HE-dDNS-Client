using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dDNS_Client
{
    public partial class main : Form
    {
        CurlWorker curl = new CurlWorker();
        private string[] args = new string[Global.CONFIG_ARGUMENTS];
        private bool paused = false;



        [StructLayout(LayoutKind.Sequential)]
        public struct CurlWorker
        {
            public IntPtr curl;
        }

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int start(ref CurlWorker curl);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void close();

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cleanup(ref CurlWorker curl);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr read_config(string conf_path);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int refresh_ddns(ref CurlWorker curl, string base64authheader, string target, string hostname, out IntPtr rlt);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int freeptr(IntPtr rlt);


        public main()
        {
            InitializeComponent();

            if (start(ref curl) != 0)
            {
                MessageBox.Show("cURL start failed", "cURL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Exit();
            }

            this.dDNSUpdate(true);
            this.SetTimer();
        }


        private void UpdateArgs()
        {
            IntPtr conf = read_config(Global.CONFPATH);
            if (conf == IntPtr.Zero) return;

            for (int i = 0; i < Global.CONFIG_ARGUMENTS; i++)
            {
                this.args[i] = Marshal.PtrToStringAnsi(conf + Global.CONFIG_ARGUMENTS_LENGTH * i);
            }

            freeptr(conf);
        }


        private void HideWindows(Object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
        }


        private void Exit()
        {
            cleanup(ref curl);
            close();
            System.Windows.Forms.Application.Exit();
        }


        private void Quit(Object sender, EventArgs e)
        {
            this.Exit();
        }

        private void SetTimer()
        {
            try
            {
                this.UpdateArgs();
                int next_time = int.Parse(args[2]);
                this.RefreshTimer.Interval = next_time * 1000;
                this.RefreshTimer.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("\"" + args[2] + "\" is not an integer", "Refresh Rate Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
        }

        private void targetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TargetSettings target_settings = new TargetSettings();
            target_settings.Show();
        }

        private void hEDDNSHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostSettings host_settings = new HostSettings();
            host_settings.Show();
        }

        private void refreshRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RateSettings rate_settings = new RateSettings();
            rate_settings.Show();
        }


        private void dDNSUpdate(bool showreply)
        {
            this.UpdateArgs();

            string authbase64 = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(args[0] + ":" + args[1]));

            IntPtr rlt;
            int errcode = refresh_ddns(ref this.curl, "Authorization: Basic " + authbase64, args[0], args[3], out rlt);
            if (rlt == IntPtr.Zero) return;

            string message = Marshal.PtrToStringAnsi(rlt);
            switch (errcode)
            {
                case 1:
                    if (showreply)  MessageBox.Show(message, "cURL Initialization Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    freeptr(rlt);
                    break;
                case 2:
                    if (showreply)  MessageBox.Show(message, "cURL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    if (showreply)  MessageBox.Show(message, "Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    freeptr(rlt);
                    break;
                default:
                    if (showreply)  MessageBox.Show(message, "dDNS Reply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    freeptr(rlt);
                    break;
            }


            this.SystemTray.Text = ("A dDNS client for Hurricane Electric dDNS service\n\nLatest dDNS Sync: " + DateTime.Now.ToString("yyyy-MM-dd(ddd) HH:mm:ss") + "\nServer reply: " + message).Substring(0, 127);
        }


        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dDNSUpdate(true);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            this.RefreshTimer.Stop();
            this.dDNSUpdate(false);
            this.SetTimer();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                this.SetTimer();
                this.pauseToolStripMenuItem.Text = "Pause";
                this.pauseToolStripMenuItem.Image = Properties.Resources.Pause;
            }
            else
            {
                this.RefreshTimer.Stop();
                this.pauseToolStripMenuItem.Text = "Resume";
                this.pauseToolStripMenuItem.Image = Properties.Resources.Resume;
            }

            this.paused = !this.paused;
        }
    }

    public static class Global
    {
        public const string WORKDIR = "C:\\Users\\siw20\\Downloads\\dDNS Client\\dDNS Client";
        public const string _dllImportPath = WORKDIR + "\\Core\\x64\\Debug\\dDNS Client Core.dll";
        public const string CONFPATH = WORKDIR + "\\Resources\\config.txt";
        public const int CONFIG_ARGUMENTS = 4;
        public const int CONFIG_ARGUMENTS_LENGTH = 256;
    }
}

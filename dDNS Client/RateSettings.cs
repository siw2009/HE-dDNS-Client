using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dDNS_Client
{
    public partial class RateSettings : Form
    {
        private string[] args = new string[Global.CONFIG_ARGUMENTS];



        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr read_config(string conf_path);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int write_config(string conf_path, IntPtr args);

        [DllImport(Global._dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void freeptr(IntPtr ptr);


        public RateSettings()
        {
            InitializeComponent();
        }


        private void UpdateArgs()
        {
            IntPtr conf = read_config(Global.CONFPATH);
            if (conf == IntPtr.Zero)  return;

            for (int i = 0; i < Global.CONFIG_ARGUMENTS; i++)
            {
                this.args[i] = Marshal.PtrToStringAnsi(conf + Global.CONFIG_ARGUMENTS_LENGTH * i);
            }

            freeptr(conf);
        }


        private void Loadup(object sender, EventArgs e)
        {
            this.UpdateArgs();
            this.RateForm.Text = this.args[2];
        }


        private void OKButton_Click(object sender, EventArgs e)
        {
            string newRate = this.RateForm.Text + "\0";
            try
            {
                int check = int.Parse(newRate);
            }
            catch (FormatException)
            {
                MessageBox.Show("\"" + newRate + "\" is not an integer\nResetting to previous (" + args[2] + ")", "Refresh Rate Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newRate = args[2];
            }


            byte[] newConf = new byte[Global.CONFIG_ARGUMENTS_LENGTH * Global.CONFIG_ARGUMENTS];


            for (int i = 0; i < Global.CONFIG_ARGUMENTS; i++)
            {
                for (int j = 0; j < args[i].Length && j < Global.CONFIG_ARGUMENTS_LENGTH; j++) { newConf[i * Global.CONFIG_ARGUMENTS_LENGTH + j] = (byte)args[i][j]; }
            }
            for (int i = 0; i < newRate.Length && i < Global.CONFIG_ARGUMENTS_LENGTH; i++) { newConf[i + Global.CONFIG_ARGUMENTS_LENGTH * 2] = (byte)newRate[i]; }


            GCHandle newConfHandle = GCHandle.Alloc(newConf, GCHandleType.Pinned);
            try
            {
                IntPtr newConfPtr = newConfHandle.AddrOfPinnedObject();
                if (write_config(Global.CONFPATH, newConfPtr) != 0)
                {
                    MessageBox.Show("Writing config failed.\nConfig path: " + Global.CONFPATH);
                }
            } finally
            {
                newConfHandle.Free();
            }

            this.Close();
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

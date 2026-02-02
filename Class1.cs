using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class libdDNS
{
	public dDNS()
	{
		private const string _dllImportPath = "C:\Users\siw20\Downloads\dDNS Client\dDNS Client\ddns-client.dll";
		[DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdec1)]
		public static extern char* read_config(const char* conf_path);

    }
}

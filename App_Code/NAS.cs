using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Text;
using System.Net;  
using System.IO; 
using System.Diagnostics;

namespace File_Upload_system
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class NAS
	{
		
		static string username="";
		static string pass="";
		static string foldername="";
		public NAS()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string getusername()
		{
			username="pmg";  // Enter Here NAS server Folder Access User Name
			return username;
		}
		public static string getpass()
		{
			pass="pmgbses";  // Enter Here NAS server Folder Access password
			return pass;
		}
		public static string getfolder()
		{
			foldername="upload";  // Enter Here NAS server  Folder Name
			return foldername;
		}
		public static void map_drive()
		{
			Process proc=new Process();
			proc.StartInfo.CreateNoWindow=true;
			proc.StartInfo.UseShellExecute=false;
			proc.StartInfo.FileName="cmd.exe";
			//================================For Live ============================//
            //proc.StartInfo.Arguments = "/c " + "NET USE y: \\" + "\\10.125.66.13\\" + NAS.getfolder() + " /USER:" + NAS.getusername() + " " + NAS.getpass();
			////====================For Testing ============================//
			proc.StartInfo.Arguments="/c "+"NET USE y: \\"+"\\10.125.123.104\\"+NAS.getfolder()+" /USER:"+NAS.getusername()+" "+NAS.getpass();
			proc.Start(); 
			proc.WaitForExit(); 

		

		}
		public static void unmap_drive()
		{
			Process proc=new Process();
			proc.StartInfo.CreateNoWindow=true;
			proc.StartInfo.UseShellExecute=false;
			proc.StartInfo.FileName="cmd.exe";
			proc.StartInfo.Arguments="/c NET USE * /delete /yes";
            proc.Start(); 
			proc.WaitForExit(); 

		}
        public static void cmd_exe(string dir,string cmd)
        {
            AppLauncher launcher = new AppLauncher(dir);
            launcher.runApp(); 

        }
        class AppLauncher
        {
            string app2Launch;
            public AppLauncher(string path)
            {
                app2Launch = path;
            }
            public void runApp()
            {
                ProcessStartInfo pInfo = new ProcessStartInfo(app2Launch);
                pInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process p = Process.Start(pInfo);
            }
        }

     
	
		
	}
}
	
		

	


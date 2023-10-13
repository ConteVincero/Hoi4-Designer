using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Hoi4_Designer
{
    public class FileLocation
    {//Finds the location of Hoi4 on disk
        public static string installLocation = SetInstallLocation();
        public static string SetInstallLocation()
        {
            //Find the install location of steam
            string registyLocation;
            if (Environment.Is64BitProcess)
            {
                registyLocation = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam";
            }
            else
            {
                registyLocation = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Valve\\Steam";
            }
            string SteamInstallPath = (string)Registry.GetValue(registyLocation, "InstallPath", "");
            //now open libraryfiles.vdf
            StreamReader fileReader = File.OpenText(SteamInstallPath+ "\\steamapps\\libraryfolders.vdf");
            string line;
            string curPath = "";
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("path"))
                {
                    curPath = line.Substring(line.IndexOf("path")+5).Trim().Replace("\"", "");
                }
                if (line.Contains("394360"))
                {
                    curPath += "\\steamapps\\common\\Hearts of Iron IV\\";
                    break;
                }
            }
            return curPath;
        }
    }
}

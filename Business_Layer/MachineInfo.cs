/*File Sharing is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Foobar is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with File Sharing.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Management;
using System.Management.Instrumentation;

namespace Business_Layer
{
    public class MachineInfo
    {

        public static string MachineName = Environment.MachineName;
        public static IPEndPoint MachineIP;
        public static List<FileInfo> Files = new List<FileInfo>();

        /// <summary>
        /// It gets the current share folder file list
        /// </summary>
        /// <param name="folder"></param>
        public static void GetFiles(string folder)
        {
            if (!Directory.Exists(folder))
                return;

            foreach (string file in Directory.GetFiles(folder))
            {
                FileInfo info = new FileInfo(Path.GetFileName(file), (new System.IO.FileInfo(file).Length / 1024));
                Files.Add(info);
            }
        }

        /// <summary>
        /// It gets the current machine IP address
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint GetMachineIP()
        {
            IPEndPoint result = null;

             ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select IPAddress From Win32_NetworkAdapterConfiguration");

             foreach (ManagementObject obj in searcher.Get())
             {
                 if (obj["IPAddress"] != null)
                 {
                     string[] ip = (string[])obj["IPAddress"];
                     result = new IPEndPoint(IPAddress.Parse(ip[0]), 9898);
                     break;
                 }
             }
        
            return result;
        }

        public static string GetJustIP()
        {
            string result = null;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select IPAddress From Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj["IPAddress"] != null)
                {
                    string[] ip = (string[])obj["IPAddress"];
                    result = ip[0];
                    break;
                }
            }

            return result;
        }

    }
}

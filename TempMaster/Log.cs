using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TempMaster
{
    class Log
    {
        public string LogFileName { get; set; }
        public string LogInterval { get; set; }
        private DateTime LastWriteTime;
        private StreamWriter SW;
        
        public Log(string loginterval)
        {
            //create and open a new file
            LogInterval = loginterval;
            string appPath = Application.StartupPath;
            LogFileName = string.Concat(appPath, "\\", System.DateTime.Now.ToString("yyyyMMddTHHmmss"), ".log");
            SW = new StreamWriter(LogFileName);
        }

        public void LogFile(string temp)
        {
            string line;
            line = string.Concat(System.DateTime.Now, ",", temp);
            double interval = Convert.ToDouble(LogInterval);
            if (System.DateTime.Now >= LastWriteTime.AddSeconds(interval))
            {
                SW.WriteLine(line);
                LastWriteTime = System.DateTime.Now;
            }
        }

        public void CloseLog()
        {
            if (SW != null)
            {
                SW.Flush();
                SW.Close();
            }
        }
    }
}

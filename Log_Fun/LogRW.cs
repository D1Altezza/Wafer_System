using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wafer_System.Log_Fun
{
    public class LogRW
    {
        public void WriteLog(string message, string log_type)
        {
            string DIRNAME = Application.StartupPath + @"\Log\" + log_type + "\u005C";
            string FILENAME = DIRNAME + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (!Directory.Exists(DIRNAME))
                Directory.CreateDirectory(DIRNAME);

            //if (!File.Exists(FILENAME))
            //{
            //    // The File.Create method creates the file and opens a FileStream on the file. You neeed to close it.
            //    File.Create(FILENAME).Close();
            //}
            using (StreamWriter sw = File.AppendText(FILENAME))
            {
                Log(message, sw);
            }

        }

        private static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\n");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("");
            w.WriteLine("{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static void ReadLog(string Date_yyyyMMdd)
        {
            string DIRNAME = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
            string FILENAME = DIRNAME + Date_yyyyMMdd + ".txt";

            if (File.Exists(FILENAME))
            {
                using (StreamReader r = File.OpenText(FILENAME))
                {
                    DumpLog(r);
                }
            }
            else
            {
                Console.WriteLine(Date_yyyyMMdd + ": No Data!");
            }
        }

        private static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}

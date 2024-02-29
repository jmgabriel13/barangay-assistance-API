using System;
using System.IO;

namespace Base.Services.Helpers.Utility
{
    public class Logger
    {
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory;

        public void ErrorLog(string Message)
        {
            try
            {
                StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_errorlogs" + "\\" + DateTime.Now.ToString("yyyyMM") + "\\err" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                errsr.WriteLine(DateTime.Now.ToString() + " : " + Message);
                errsr.Close();
                Console.WriteLine(DateTime.Now.ToString() + " : " + Message);
            }
            catch (Exception)
            {
                try
                {
                    if (!Directory.Exists(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_errorlogs" + "\\" + DateTime.Now.ToString("yyyyMM")))
                        Directory.CreateDirectory(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_errorlogs" + "\\" + DateTime.Now.ToString("yyyyMM"));
                    StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_errorlogs" + "\\" + DateTime.Now.ToString("yyyyMM") + "\\err" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                    errsr.WriteLine(DateTime.Now.ToString() + " : " + Message);
                    errsr.Close();
                    Console.WriteLine(DateTime.Now.ToString() + " : " + Message);
                }
                catch (Exception ex2)
                {
                    StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\GeneralError" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                    errsr.WriteLine(DateTime.Now.ToString() + "unable to create directory / write to file -- " + ex2.Message + " : " + ex2.StackTrace + Environment.NewLine);
                    errsr.Close();
                    Console.WriteLine(DateTime.Now.ToString() + "unable to create directory / write to file -- " + ex2.Message + " : " + ex2.StackTrace);
                }
            }
        }

        public void EventLog(string Message)
        {
            try
            {
                StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_eventlogs" + "\\" + DateTime.Now.ToString("yyyyMM") + "\\event" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                errsr.WriteLine(DateTime.Now.ToString() + " : " + Message);
                errsr.Close();
                Console.WriteLine(DateTime.Now.ToString() + " : " + Message);
            }
            catch (Exception)
            {
                try
                {
                    if (!Directory.Exists(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_eventlogs" + "\\" + DateTime.Now.ToString("yyyyMM")))
                        Directory.CreateDirectory(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_eventlogs" + "\\" + DateTime.Now.ToString("yyyyMM"));
                    StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\_eventlogs" + "\\" + DateTime.Now.ToString("yyyyMM") + "\\event" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                    errsr.WriteLine(DateTime.Now.ToString() + " : " + Message);
                    errsr.Close();
                    Console.WriteLine(DateTime.Now.ToString() + " : " + Message);
                }
                catch (Exception ex2)
                {
                    StreamWriter errsr = new StreamWriter(path.Remove(path.IndexOf("\\bin\\Debug")) + "\\GeneralError" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                    errsr.WriteLine(DateTime.Now.ToString() + "unable to create directory / write to file -- " + ex2.Message + " : " + ex2.StackTrace + Environment.NewLine);
                    errsr.Close();
                    Console.WriteLine(DateTime.Now.ToString() + "unable to create directory / write to file -- " + ex2.Message + " : " + ex2.StackTrace);
                }
            }
        }

        public string LogException(Exception ex, string message = "")
        {
            var msg = "An error occured while processing your request. Please contact admin if it persists.";

            ErrorLog(message + Environment.NewLine + "Exception: " + ex.ToString() +
                        Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);

            return msg;
        }

        public void LogEvents(string _event) =>
            EventLog(_event + Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
    }
}
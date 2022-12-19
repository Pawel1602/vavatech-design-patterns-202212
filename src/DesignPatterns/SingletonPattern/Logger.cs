using System;
using System.IO;

namespace SingletonPattern
{
    public class Logger : Singleton<Logger>
    {
        private readonly string path = "log.txt";

        public void LogInformation(string message)
        {
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{DateTime.Now} {message}");
        }

     

        
    }
}

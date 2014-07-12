using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public static class Logger
    {
        private const string OutputFile = "log.txt";
        public static void LogException(Exception exception, string source, string method, int line)
        {
            var result = string.Format("Time: {0}, Type: {1}, Class: {2}, Method: {3}, Line: {4}", DateTime.Now,
                      exception.GetType(), ConvertFilePathToFileName(source), method, line);
            Console.WriteLine(result);
            Log(result, exception.GetOriginalException());
            // Added for tests to catch exception otherwise doesn't throw it
            throw new ArgumentNullException(result);
            Environment.Exit(0);
        }

        private static void Log(string log, Exception exception)
        {
            using (var sr = new StreamWriter(OutputFile, true))
            {
                sr.WriteLine(log);
                sr.WriteLine(exception);
            }
        }

        private static string ConvertFilePathToFileName(string filePath)
        {
            int index = filePath.LastIndexOf('\\');
            string fileName = filePath.Substring(index + 1);
            return fileName;
        }

        private static Exception GetOriginalException(this Exception ex)
        {
            while (true)
            {
                if (ex.InnerException == null) return ex;

                ex = ex.InnerException;
            }
        }
    }
}

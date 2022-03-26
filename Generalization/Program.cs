using System;
using System.IO;

namespace Generalization
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogger = new LocalFileLogger<int>("text.txt");
            fileLogger.LogInfo("message1");
            fileLogger.LogInfo("message2");
            fileLogger.LogError("message3", new Exception("Ошибочка вышла"));

            var fileLogger2 = new LocalFileLogger<string>("text.txt");
            fileLogger2.LogInfo("message4");
            fileLogger2.LogInfo("message5");
            fileLogger2.LogError("message6", new Exception("Опять ошибка =("));

            var fileLogger3 = new LocalFileLogger<bool>("text.txt");
            fileLogger3.LogInfo("message7");
            fileLogger3.LogInfo("message8");
            fileLogger3.LogError("message9", new Exception("ABOBA"));

        }
    }
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);

    }


    public class LocalFileLogger<T>: ILogger { 
        private string filePath;
        public LocalFileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void LogInfo(string message)
        {
            string GenericTypeName = typeof(T).Name;
            File.AppendAllText(filePath, $"[Info] : [{GenericTypeName}] : {message}\n");
        }

        public void LogWarning(string message)
        {
            string GenericTypeName = typeof(T).Name;
            File.AppendAllText(filePath, $"[Warning] : [{GenericTypeName}] : {message}\n");
        }
        public void LogError(string message, Exception ex)
        {
            string GenericTypeName = typeof(T).Name;
            File.AppendAllText(filePath, $"[Error] : [{GenericTypeName}] : {message}. {ex.Message}\n");
        }
    }
}

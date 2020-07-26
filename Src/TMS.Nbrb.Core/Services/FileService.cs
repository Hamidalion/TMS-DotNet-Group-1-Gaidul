using System;
using System.IO;
using System.Text;
using TMS.Nbrb.Core.Helpers;
using TMS.Nbrb.Core.Interfaces;

namespace TMS.Nbrb.Core.Services
{
    public class FileService : IFileService
    {
        public void WriteToFileAsync(string text)
        {
            WriteAsync(text, Constants.path);
        }

        public void WriteToFileAsync(string text, string path)
        {
            WriteAsync(text, path);
        }
        public void ReadFile()
        {
            Read(Constants.path);
        }
        public void ReadFile(string path)
        {
            Read(path);
        }
        public void ClearFile()
        {
            Clear(Constants.path);
        }
        public void ClearFile(string path)
        {
            Clear(path);
        }

        private async void WriteAsync(string text, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data was sucssesful write in file");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data");
            }
        }
        private void Read(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data");
            }
        }
        private void Clear(string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Truncate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data was sucssesful cleared in file");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data");
            }
        }
    }
}

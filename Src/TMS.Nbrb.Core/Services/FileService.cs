using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
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

        private async void WriteAsync (string text, string path)
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //ToDo: Make feature to read the file
    }
}

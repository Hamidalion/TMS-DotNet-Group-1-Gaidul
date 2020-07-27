using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Helpers;
using TMS.Nbrb.Core.Interfaces;

namespace TMS.Nbrb.Core.Services
{
    /// <inheritdoc cref="IFileService"/>
    public class FileService : IFileService
    {
        public async Task WriteToFileAsync(string text)
        {
            await WriteAsync(text, Constants.FileName);
        }

        public async Task WriteToFileAsync(string text, string path)
        {
            await WriteAsync(text, path);
        }

        public async Task ReadFileAsync()
        {
            await ReadAsync(Constants.FileName);
        }

        public async Task ReadFileAsync(string path)
        {
            await ReadAsync(path);
        }

        public async Task ClearFileAsync()
        {
            await ClearAsync(Constants.FileName);
        }

        public async Task ClearFileAsync(string path)
        {
            await ClearAsync(path);
        }

        private async Task WriteAsync(string text, string path)
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

        private async Task ReadAsync(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data");
            }
        }

        private Task ClearAsync(string path)
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

            return Task.CompletedTask;
        }
    }
}

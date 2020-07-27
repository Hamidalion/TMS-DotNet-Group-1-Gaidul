using System.Threading.Tasks;

namespace TMS.Nbrb.Core.Interfaces
{
    /// <summary>
    /// Сервис для работы с файловой системой.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        public Task WriteToFileAsync(string text);

        /// <summary>
        /// Записать в файл.
        /// </summary>
        /// <param name="text">Текст.</param>
        /// <param name="path">Путь.</param>
        public Task WriteToFileAsync(string text, string path);

        /// <summary>
        /// Прочитать файл.
        /// </summary>
        /// <param name="path">Путь.</param>
        public Task ReadFileAsync(string path);

        /// <summary>
        /// Прочитать файл.
        /// </summary>
        public Task ReadFileAsync();

        /// <summary>
        /// Очистить файл.
        /// </summary>
        /// <param name="path"></param>
        public Task ClearFileAsync(string path);

        /// <summary>
        /// Очистить файл.
        /// </summary>
        public Task ClearFileAsync();
    }
}

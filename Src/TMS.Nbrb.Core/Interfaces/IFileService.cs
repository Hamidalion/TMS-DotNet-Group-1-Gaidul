using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Nbrb.Core.Interfaces
{
    public interface IFileService
    {
        public void WriteToFileAsync(string text);
        public void WriteToFileAsync(string text, string path);
        public void ReadFile(string path);
        public void ReadFile();
        public void ClearFile(string path);
        public void ClearFile();
    }
}

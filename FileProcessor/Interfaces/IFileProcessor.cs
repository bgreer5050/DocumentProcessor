using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileProcessor.Interfaces
{
    interface IFileProcessor
    {
        bool ConcatenateFiles(List<FileInfo> files, DirectoryInfo directoryInfo, string newFileName);
        void OpenFileInDefaultApplication(FileInfo file);
    }
}

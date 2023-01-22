using FileProcessor.Interfaces;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileProcessor
{
    public class PDFProcessor : IFileProcessor
    {
        public bool ConcatenateFiles(List<FileInfo> files, DirectoryInfo directoryInfo,
            string newFileName)
        {
            bool Success = false;
            
            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // Iterate files
            try
            {
                foreach (FileInfo file in files)
                {
                    // Open the document to import pages from it.
                    PdfDocument inputDocument = PdfReader.Open(file.FullName, PdfDocumentOpenMode.Import);

                    // Iterate pages
                    int count = inputDocument.PageCount;
                    for (int idx = 0; idx < count; idx++)
                    {
                        // Get the page from the external document...
                        PdfPage page = inputDocument.Pages[idx];
                        // ...and add it to the output document.
                        outputDocument.AddPage(page);
                    }
                }

                // Save the document...
                string filename = $"{newFileName}.pdf";
                outputDocument.Save(filename);
                // ...and start a viewer.
                //Process.Start(filename);
                Success = true;
            }
            catch (Exception)
            {
                //TODO Cleanup resources
                //TODO Log error
                Success = false;
            }
            return Success;
        }

        public void OpenFileInDefaultApplication(FileInfo file)
        {
            string filePathAndName = Path.Combine(file.Directory.Name, file.Name);
            System.Diagnostics
                .Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", $@"{file.FullName}");

        }
    }
}

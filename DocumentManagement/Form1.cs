using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManagement
{
    public partial class Form1 : Form
    {
        public static string FilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessPDFs_Click(object sender, EventArgs e)
        {
            FilePath = txtDirectory.Text.Trim();
            ProcessFiles();
        }

        private static void ProcessFiles()
        {
            // Get some file names
            DirectoryInfo directoryInfo = new DirectoryInfo(FilePath);
            FileInfo[] allFiles = directoryInfo.GetFiles();
            List<FileInfo> files = new List<FileInfo>();

            files = allFiles.Where(c => c.Name.Contains("_Reviewed") == false).ToList();
            files = files.Where(c => c.Name.Contains("_Done") == false).ToList();

            //Todo
            //if any files are in review then we need to alert the user and exit.

            var _file = files.FirstOrDefault();

            //Mark files as being processed
            var newFileName = Path.Combine(directoryInfo.FullName, $"{_file.Name}_REVIEW{_file.Extension}");
            File.Copy(_file.FullName, newFileName);


            //foreach (var f in allFiles)
            //{
            //    if (!f.Name.Contains("reviewed"))
            //    {
            //        files.Add(f);
            //    }
            //}



        }
    }
}

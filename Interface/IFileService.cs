using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPagesDemo.Interface
{
    public interface IFileService
    {
        public string Root { get; set; }
        public bool IsNative { get; set; }
        void open(XLWorkbook workbook, string type);
        Task<Stream> LoadImage();
        Task<string> LoadXLSX();
    }
}

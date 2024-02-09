using ClosedXML.Excel;
using GitHubPagesDemo.Interface;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPagesDemo.Data
{
    public class FileService : IFileService, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public FileService(Lazy<Task<IJSObjectReference>> moduleTask)
        {
            this.moduleTask = moduleTask;
        }

        public string Root { get; set; }
        public bool IsNative { get; set; } = false;

        public async void open(XLWorkbook workbook, string type)
        {
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Flush();

                var buffer = stream.ToArray();
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(
                    "downloadFile",
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    Convert.ToBase64String(buffer),
                    $"{type}_Download_{DateTime.Now.ToLongDateString().Replace(' ', '_')}.xlsx"
                  );
            }
        }
        public async Task<Stream> LoadImage()
        {
            await Task.Delay(0);
            return new MemoryStream();
        }
        public async Task<string> LoadXLSX()
        {
            await Task.Delay(0);
            return string.Empty;
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}

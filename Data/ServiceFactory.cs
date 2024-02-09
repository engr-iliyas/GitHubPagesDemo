using BlazorBootstrap;
using GitHubPagesDemo.Interface;
using Microsoft.JSInterop;
using System.Net.Http;

namespace GitHubPagesDemo.Data
{
    public class ServiceFactory : IServiceFactory
    {
        private ApplicationDbContext _context;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly ToastService _toastService;

        public ServiceFactory(
            ApplicationDbContext context,
            IJSRuntime jsRuntime,
            ToastService toastService
            )
        {
            _context = context;
            _toastService = toastService;
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./downloader.js").AsTask());
        }
        public IDataService<T> GetDataService<T>() where T : class => new DataService<T>(_context, _toastService);
        public IFileService GetFileService() => new FileService(moduleTask);
        //public IGlobalInformation GetGlobalService() => new GlobalInformation();
        //public ILogService GetLogService() => new LogService();
    }
}

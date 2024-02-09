using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPagesDemo.Interface
{
    public interface IServiceFactory
    {
        public IDataService<T> GetDataService<T>() where T : class;
        public IFileService GetFileService();
        //public ILogService GetLogService();
        //public IGlobalInformation GetGlobalService();
        //public IMapServices<T> GetMapService<T>() where T : ICoordinate;
        //public ILocationService GetLocationService();
    }
}

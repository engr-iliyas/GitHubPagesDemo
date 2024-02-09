using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPagesDemo.Interface
{
    public interface IDataService<T>
    {
        public void Add(T t);
        public void Add(List<T> t);
        public void Update(T t);
        public void Update(List<T> t);
        public void Delete(T t);
        public void Delete(List<T> t);

        public Task<T?> GetItem(int Id);
        public Task<List<T>?> GetItems();
        //public void Seed(int count);
        //public void Sync();
        //public Task<List<T>?> GetItemsCategory();
        //public void AddAll(List<T> ts);
        //public bool Any();
        //public int Count();
    }
}

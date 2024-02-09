using BlazorBootstrap;
using GitHubPagesDemo.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace GitHubPagesDemo.Data
{
    public class DataService<T> : IDataService<T> where T : class//, new() //, IDisposable
    {
        private ApplicationDbContext _context;
        private readonly ToastService _toastService;
        //private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<DataService<T>>();

        public DataService(
            ApplicationDbContext context,
            ToastService toastService
            )
        {
            _context = context;
            _toastService = toastService;
        }
        public async void Add(T t)
        {
            try
            {
                await _context.AddAsync(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"{t.GetType().Name} new entry created!"));
                //_logger.Information($"{t.GetType().Name} created");// by admin
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{t.GetType().Name}: new entry failed ({ex})!"));
                //_logger.Error($"{t.GetType().Name}: new entry failed ({ex})!");
            }
        }
        public async void Add(List<T> t)
        {
            try
            {
                await _context.AddRangeAsync(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"{t.GetType().Name} new entries created!"));
                //_logger.Information($"{t.GetType().Name} created");// by admin
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{t.GetType().Name}: new entries failed ({ex})!"));
                //_logger.Error($"{t.GetType().Name}: new entry failed ({ex})!");
            }
        }
        public async void Update(T t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"{t.GetType().Name} details updated successfully."));
                //_logger.Information($"{t.GetType().Name} updated");/* by admin*/
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{t.GetType().Name} update failed ({ex.Message})!"));
                //_logger.Error($"{t.GetType().Name}: update failed ({ex.Message})!");
            }
        }
        public async void Update(List<T> t)
        {
            try
            {
                _context.UpdateRange(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"Selected {typeof(T).Name.ToLower()}s details updated successfully."));
                //_logger.Information($"{t.GetType().Name} updated");/* by admin*/
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{typeof(T).Name} update failed ({ex.Message})!"));
                //_logger.Error($"{t.GetType().Name}: update failed ({ex.Message})!");
            }
        }
        public async void Delete(T t)
        {
            try
            {
                _context.Remove(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"{t.GetType().Name}: deleted!"));
                //_logger.Information($"{t.GetType().Name} updated");/* by admin*/
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{t.GetType().Name}: delete failed ({ex.Message})!"));
                //_logger.Error($"{t.GetType().Name}: delete failed ({ex.Message})!");
            }
        }
        public async void Delete(List<T> t)
        {
            try
            {
                _context.RemoveRange(t);
                await _context.SaveChangesAsync();
                _toastService.Notify(new(ToastType.Success, $"Selected {typeof(T).Name.ToLower()}s deleted!"));
                //_logger.Information($"{t.GetType().Name} updated");/* by admin*/
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{typeof(T).Name}: delete failed ({ex.Message})!"));
                //_logger.Error($"{t.GetType().Name}: delete failed ({ex.Message})!");
            }
        }
        public async Task<T?> GetItem(int Id)
        {
            try
            {
                switch (typeof(T).Name)
                {
                    //case "Marketer":
                    //    return await _context.Marketers
                    //        .Include(s => s.Cluster)
                    //        .ThenInclude(s => s.Customers)
                    //        .ThenInclude(s => s.Transactions)
                    //        .FirstOrDefaultAsync(i => i.ID == Id) as T;
                    default:
                        await _context.SaveChangesAsync();
                        return Activator.CreateInstance<T>();
                }
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                _toastService.Notify(new(ToastType.Danger, $"{typeof(T).Name}: delete failed ({ex.Message})!"));
                //_logger.Error($"{typeof(T).Name}: delete failed ({ex.Message})!");
                return Activator.CreateInstance<T>();
            }
        }
        public async Task<List<T>?> GetItems()
        {
            switch (typeof(T).Name)
            {
                //case "Marketer":
                //    return await _context.Marketers
                //    .Include(t => t.Feeder)
                //    .ToListAsync() as List<T>;
                default:
                    return await _context.Set<T>().ToListAsync();
            }
        }
    }
}

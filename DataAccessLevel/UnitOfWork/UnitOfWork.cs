using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLevel.Models;
using DataAccessLevel.Repositories;

namespace DataAccessLevel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PikDbContext _context;

        // а можно вот так сделать

        //private IUserRepository _users;
        //private ITaskRepository _tasks;
        //private ICatalogRepository _catalogs;

        public UnitOfWork(PikDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Репозитарий пользователей
        /// </summary>
        //public IUserRepository users
        //{
        //    get { return _users ?? (_users = new UserRepository(_context)); }
        //}

        /// <summary>
        /// Репозитарий каталогов
        /// </summary>
        //public ICatalogRepository catalogs
        //{
        //    get { return _catalogs ?? (_catalogs = new CatalogRepository(_context)); }
        //}

        /// <summary>
        /// Репозитарий заданий
        /// </summary>
        //public ITaskRepository tasks
        //{
        //    get { return _tasks ?? (_tasks = new TaskRepository(_context)); }
        //}

        // Возвращает репозиторий для работы с сущностями любого типа
        public IBaseRepository<entity> entities<entity>() where entity : class
        {
            return new BaseRepository<entity>(_context);
        }

        // Сохранить изменения в базу данных
        public int Update()
        {
            return _context.SaveChanges();
        }

        // Сохранить изменения в базу данных асинхронно
        public async Task<int> UpdateAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}

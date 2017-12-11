using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLevel.Repositories.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;
//using System.Linq.Dynamic;
using DataAccessLevel.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DataAccessLevel.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected PikDbContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(PikDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        // Сформировать запрос к базе данных и выполнить асинхронно.
        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                          params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }
        
        // Сформировать запрос к базе данных, не выполняя его.
        public virtual IOrderedQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query);
            else
            {
                // дефолтная дженерик-сортировка по PrimaryKey
                var genericKey = typeof(TEntity).GetProperties().SingleOrDefault(p => p.IsDefined(typeof(KeyAttribute))); // получаем ключ
                //return (IOrderedQueryable<TEntity>)query.OrderBy(genericKey + " asc");
                //return (IOrderedQueryable<TEntity>)query.OrderBy("1 asc");

                var p1 = Expression.Parameter(typeof(TEntity), "p1");
                var prop = Expression.PropertyOrField(p1, genericKey.Name);
                var lambda = Expression.Lambda<Func<TEntity, object>>(prop, new ParameterExpression[] { p1 });

                return query.OrderBy(lambda);

            }
        }

        // Вернуть сущность по id.
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }
        public virtual TEntity GetById(params object[] id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetByIdMany(IEnumerable<object> ids)
        {
            foreach (object id in ids)
                yield return dbSet.Find(id);
        }


        // Вернуть сущность по id асинхронно.
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> GetByIdManyAsync(IEnumerable<object> ids)
        {
            throw new NotImplementedException();
        }

        // Вернуть первую сущность, удовлетворяющую запросу (если указан), или сущность по умолчанию.
        // Для установки сущности по умолчанию используйте DefaultIfEmpty().
        public virtual TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);
        }

        // Вернуть первую сущность, удовлетворяющую запросу (если указан), или сущность по умолчанию асинхронно.
        // Для установки сущности по умолчанию используйте DefaultIfEmpty().
        public virtual async Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(filter);
        }

        // Добавить новую сущность в базу данных.
        public virtual int Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return context.SaveChanges();
        }

        // Добавить новую сущность в базу данных асинхронно.
        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            return await context.SaveChangesAsync();
        }

        // Добавить список новых сущностей в базу данных.
        public virtual int InsertMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                dbSet.Add(entity);
            return context.SaveChanges();
        }

        // Добавить список новых сущностей в базу данных асинхронно.
        public virtual async Task<int> InsertManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                dbSet.Add(entity);
            return await context.SaveChangesAsync();
        }

        // Обновить сущность в базе данных.
        public virtual int Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        // Обновить сущность в базе данных асинхронно.
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
        
        // Обновить список сущностей в базе данных.
        public virtual int UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }

        // Обновить список сущностей в базе данных асинхронно.
        public virtual async Task<int> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            return await context.SaveChangesAsync();
        }

        // Удалить сущность из базы данных.
        public virtual int Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return context.SaveChanges();
        }

        // Удалить сущность из базы данных асинхронно.
        public virtual async Task<int> DeleteAsync(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить список сущностей в базе данных
        /// </summary>
        /// <param name="entities">Список сущностей</param>
        /// <returns>Количество объектов, изменённых в базе данных</returns>
        public virtual int DeleteMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            return context.SaveChanges();
        }

        /// <summary>
        /// Удалить список сущностей в базе данных асинхронно
        /// </summary>
        /// <param name="entities">Список сущностей</param>
        /// <returns>Количество объектов, изменённых в базе данных</returns>
        public virtual async Task<int> DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            return await context.SaveChangesAsync();
        }

        // Получить число сущностей в базы данных
        public virtual int Count()
        {
            return dbSet.Count();
        }

        // Получить число сущностей в базы данных асинхронно
        public virtual async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }
    }
}

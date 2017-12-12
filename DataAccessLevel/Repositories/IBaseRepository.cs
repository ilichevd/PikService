using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessLevel.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Сформировать запрос к базе данных и выполнить.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Сформировать запрос к базе данных и выполнить асинхронно.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Сформировать запрос к базе данных, не выполняя его.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        IOrderedQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Вернуть сущность по id.
        /// </summary>
        /// <param name="id">id сущности</param>
        /// <returns>сущность</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Вернуть сущность по id, версия для составного id.
        /// </summary>
        /// <param name="id">id сущности</param>
        /// <returns>сущность</returns>
        TEntity GetById(params object[] id);

        /// <summary>
        /// Вернуть список сущностей по списку их id.
        /// </summary>
        /// <param name="ids">список id</param>
        /// <returns>список сущностей</returns>
        IEnumerable<TEntity> GetByIdMany(IEnumerable<object> ids);

        /// <summary>
        /// Вернуть сущность по id асинхронно.
        /// </summary>
        /// <param name="id">id сущности</param>
        /// <returns>сущность</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Вернуть сущность по id асинхронно, версия для составного id.
        /// </summary>
        /// <param name="id">id сущности</param>
        /// <returns>сущность</returns>
        Task<TEntity> GetByIdAsync(params object[] id);

        /// <summary>
        /// Вернуть список сущностей по списку их id.
        /// </summary>
        /// <param name="ids">список id</param>
        /// <returns>список сущностей</returns>
        Task<IEnumerable<TEntity>> GetByIdManyAsync(IEnumerable<object> ids);

        // Вернуть первую сущность, удовлетворяющую запросу (если указан), или сущность по умолчанию.
        // Для установки сущности по умолчанию используйте DefaultIfEmpty().
        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Вернуть первую сущность, удовлетворяющую запросу (если указан), или сущность по умолчанию асинхронно.
        /// Для установки сущности по умолчанию используйте DefaultIfEmpty().
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Добавить новую сущность в базу данных.
        /// </summary>
        /// <param name="entity"></param>
        int Insert(TEntity entity);

        /// <summary>
        /// Добавить новую сущность в базу данных асинхронно.
        /// </summary>
        /// <param name="entity"></param>
        Task<int> InsertAsync(TEntity entity);
        
        /// <summary>
        /// Добавить список новых сущностей в базу данных.
        /// </summary>
        /// <param name="entity"></param>
        int InsertMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Добавить список новых сущностей в базу данных асинхронно.
        /// </summary>
        /// <param name="entity"></param>
        Task<int> InsertManyAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновить сущность в базе данных.
        /// </summary>
        /// <param name="entity"></param>
        int Update(TEntity entity);

        /// <summary>
        /// Обновить список сущностей в базе данных.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int UpdateMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновить сущность в базе данных асинхронно.
        /// </summary>
        /// <param name="entity"></param>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Обновить список сущностей в базе данных асинхронно.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> UpdateManyAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удалить сущность из базы данных по id.
        /// </summary>
        /// <param name="id"></param>
        int Delete(object id);

        /// <summary>
        /// Удалить сущность из базы данных по id асинхронно.
        /// </summary>
        /// <param name="id"></param>
        Task<int> DeleteAsync(object id);

        /// <summary>
        /// Удалить список сущностей в базе данных
        /// </summary>
        /// <param name="entities">Список сущностей</param>
        /// <returns>Количество объектов, изменённых в базе данных</returns>
        int DeleteMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удалить список сущностей в базе данных асинхронно
        /// </summary>
        /// <param name="entities">Список сущностей</param>
        /// <returns>Количество объектов, изменённых в базе данных</returns>
        Task<int> DeleteManyAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Получить число сущностей в базы данных
        /// </summary>
        /// <returns>Число сущностей</returns>
        int Count();

        /// <summary>
        /// Получить число сущностей в базы данных асинхронно
        /// </summary>
        /// <returns>Число сущностей</returns>
        Task<int> CountAsync();

    }
}

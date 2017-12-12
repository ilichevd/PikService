using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLevel;
using DataAccessLevel.Models;
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Базовый сервис - CRUD операции
    /// </summary>
    public interface IService<TEntity, TEntityDto>  where TEntity : BaseEntity
                                                    where TEntityDto : BaseDto
    {
        /// <summary>
        /// Возвращает объект по id
        /// </summary>
        /// <param name="id"></param>
        TEntityDto Get(int id);

        /// <summary>
        /// Возвращает объект по id асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntityDto> GetAsync(int id);

        /// <summary>
        /// Возвращает все объекты
        /// </summary>
        /// <param name="id"></param>
        IEnumerable<TEntityDto> GetAll();

        /// <summary>
        /// Возвращает все объекты асинхронно
        /// </summary>
        /// <param name="id"></param>
        Task<IEnumerable<TEntityDto>> GetAllAsync();

        /// <summary>
        /// Добавить новый объект
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        int Add(TEntityDto obj);

        /// <summary>
        /// Добавить новый объект асинхронно
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<int> AddAsync(TEntityDto obj);

        /// <summary>
        /// Изменить существующий объект
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Update(TEntityDto obj);

        /// <summary>
        /// Изменить существующий объект асинхронно
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(TEntityDto obj);

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Delete(TEntityDto obj);

        /// <summary>
        /// Удалить объект асинхронно
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TEntityDto obj);

        /// <summary>
        /// Возвращает количество абонентов
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Возвращает количество абонентов асинхронно
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync();
    }
}

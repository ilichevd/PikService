using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using AutoMapper;
using System.Linq.Expressions;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork;
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Базовый сервис - CRUD операции
    /// </summary>
    public class BaseService<TEntity, TEntityDto> where TEntity : BaseEntity
                                                  where TEntityDto : BaseDto 
    {
        /// <summary>
        /// Объект для работы с репозиториями
        /// </summary>
        protected IUnitOfWork uow { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork"></param>
        protected BaseService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        
        /// Возвращает объект по id
        public TEntityDto Get(int id)
        {
            var gotbyid = uow.entities<TEntity>().GetById(id);
            if (gotbyid == null)
                throw new Exception("Объект не найден");
            var result = Mapper.Map<TEntity, TEntityDto>(gotbyid);
            return result;
        }

        /// Возвращает объект по id асинхронно
        public async Task<TEntityDto> GetAsync(int id)
        {
            var gotbyid = await uow.entities<TEntity>().GetByIdAsync(id);
            if (gotbyid == null)
                throw new Exception("Объект не найден");
            var result = Mapper.Map<TEntity, TEntityDto>(gotbyid);
            return result;
        }

        /// Возвращает все объекты
        public IEnumerable<TEntityDto> GetAll()
        {
            var found = uow.entities<TEntity>().Get();
            //if (found == null)
            //    throw new Exception("Объекты не найдены");
            var result = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(found);
            return result;
        }

        /// Возвращает все объекты асинхронно
        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var found = await uow.entities<TEntity>().GetAsync();
            //if (found == null)
            //    throw new Exception("Объекты не найдены");
            var result = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(found);
            return result;
        }
        
        // Добавить новый объект
        public int Add(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return uow.entities<TEntity>().Insert(newEntity);
        }

        // Добавить новый объект асинхронно
        public async Task<int> AddAsync(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return await uow.entities<TEntity>().InsertAsync(newEntity);
        }

        // Изменить существующий объект
        public int Update(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return uow.entities<TEntity>().Update(newEntity);
        }

        // Изменить существующий объект асинхронно
        public async Task<int> UpdateAsync(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return await uow.entities<TEntity>().UpdateAsync(newEntity);
        }

        // Удалить объект
        public int Delete(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return uow.entities<TEntity>().Delete(newEntity);
        }

        // Удалить объект асинхронно
        public async Task<int> DeleteAsync(TEntityDto obj)
        {
            var newEntity = Mapper.Map<TEntityDto, TEntity>(obj);
            return await uow.entities<TEntity>().DeleteAsync(newEntity);
        }
                    
        /// Возвращает количество объектов
        public int GetCount()
        {
            return uow.entities<TEntity>().Count();
        }

        /// Возвращает количество объектов асинхронно
        public async Task<int> GetCountAsync()
        {
            return await uow.entities<TEntity>().CountAsync();
        }
    }
}

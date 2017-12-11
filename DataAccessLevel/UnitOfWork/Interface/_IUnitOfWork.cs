using DataAccessLevel.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Возвращает репозиторий для работы с сущностями в БД
        /// </summary>
        IBaseRepository<entity> entities<entity>() where entity : class;

        /// <summary>
        /// Записать изменения в базу данных
        /// </summary>
        /// <returns></returns>
        int Update();

        /// <summary>
        /// Записать изменения в базу данных асинхронно
        /// </summary>
        /// <returns></returns>
        Task<int> UpdateAsync();
    }
}

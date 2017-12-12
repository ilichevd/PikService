using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork;
using BusinessLogic.DataTransferObjects;
using BusinessLogic.Services;

namespace BusinessLogic.ServiceFactory
{
    /// <summary>
    /// Фабрика сервисов
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        IUnitOfWork _unitOfwork;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfwork"></param>
        public ServiceFactory(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        #region сервисы

        /// <summary>
        /// Возвращает сервис для работы с задачами
        /// </summary>
        /// <returns></returns>
        public ITaskService GetTaskService()
        {
            return new TaskService(_unitOfwork);
        }

        /// <summary>
        /// Возвращает сервис для работы с каталогами
        /// </summary>
        /// <returns></returns>
        public ICatalogService GetCatalogService()
        {
            return new CatalogService(_unitOfwork);
        }

        /// <summary>
        /// Возвращает сервис для работы с пользователями
        /// </summary>
        /// <returns></returns>
        public IUserService GetUserService()
        {
            return new UserService(_unitOfwork);
        }

        #endregion

    }
}

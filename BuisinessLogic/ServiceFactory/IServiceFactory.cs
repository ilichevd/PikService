using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;

namespace BusinessLogic.ServiceFactory
{
    /// <summary>
    /// Интерфейс фабрики сервисов
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Возвращает сервис для работы с задачами
        /// </summary>
        /// <returns></returns>
        ITaskService GetTaskService();

        /// <summary>
        /// Возвращает сервис для работы с каталогами
        /// </summary>
        /// <returns></returns>
        ICatalogService GetCatalogService();

        /// <summary>
        /// Возвращает сервис для работы с пользователями
        /// </summary>
        /// <returns></returns>
        IUserService GetUserService();
    }
}

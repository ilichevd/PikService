using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с задачами
    /// </summary>
    public interface ITaskService : IService<DataAccessLevel.Models.Task, TaskDto>
    {
    }
}

using BusinessLogic.DataTransferObjects;
using BusinessLogic.Services;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork;

namespace BusinessLogic.ServiceFactory
{
    /// <summary>
    /// Сервис для работы с задачами
    /// </summary>
    internal class TaskService : BaseService<Task, TaskDto>, ITaskService
    {
        public TaskService(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }
    }
}
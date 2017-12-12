using BusinessLogic.DataTransferObjects;
using BusinessLogic.Services;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork;

namespace BusinessLogic.ServiceFactory
{
    /// <summary>
    /// Cервис для работы с пользователями
    /// </summary>
    internal class UserService : BaseService<User, UserDto>, IUserService
    {
        public UserService(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }
    }
}
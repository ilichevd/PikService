using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DataTransferObjects;
using DataAccessLevel.Models;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с пользователями
    /// </summary>
    public interface IUserService : IService<User, UserDto>
    {
    }
}

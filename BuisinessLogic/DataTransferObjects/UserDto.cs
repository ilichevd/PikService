using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLogic.DataTransferObjects
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Id пользователя в сервисе
        /// </summary>
        [IgnoreDataMember]
        public int UserId { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Число задач пользователя
        /// </summary>
        public int TasksCount { get; set; }
    }

    /// <summary>
    /// Пользователь + его задачи
    /// </summary>
    public class UserFullDto : UserDto
    {
        /// <summary>
        /// Задачи пользователя
        /// </summary>
        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}
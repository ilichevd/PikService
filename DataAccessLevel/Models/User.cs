using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLevel.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : BaseEntity
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        /// <summary>
        /// Ключ таблицы
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Задачи пользователя
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
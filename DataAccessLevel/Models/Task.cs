using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLevel.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Ключ таблицы
        /// </summary>
        [Key]
        public int TaskId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// FK на пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// FK на каталог
        /// </summary>
        public int CatalogId { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Каталог
        /// </summary>
        public virtual Catalog Catalog { get; set; }
    }
}
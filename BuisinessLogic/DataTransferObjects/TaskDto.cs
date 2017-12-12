using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLogic.DataTransferObjects
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskDto : BaseDto
    {
        /// <summary>
        /// Id задачи в сервисе
        /// </summary>
        [IgnoreDataMember]
        public int TaskId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Каталог
        /// </summary>
        public string CatalogName { get; set; }

        /// <summary>
        /// Id каталога в сервисе
        /// </summary>
        [IgnoreDataMember]
        public int CatalogId { get; set; }

        /// <summary>
        /// Id ответственного
        /// </summary>
        [IgnoreDataMember]
        public int UserId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BusinessLogic.DataTransferObjects
{
    /// <summary>
    /// Каталог задач
    /// </summary>
    public class CatalogDto : BaseDto
    {
        /// <summary>
        /// Id каталога в сервисе
        /// </summary>
        [IgnoreDataMember]
        public int CatalogId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// Число задач в каталоге
        /// </summary>
        public int TasksCount { get; set; }
    }

    /// <summary>
    /// Каталог задач + все задачи в нём
    /// </summary>
    public class CatalogFullDto : UserDto
    {
        /// <summary>
        /// Задачи каталога
        /// </summary>
        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}

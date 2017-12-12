using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.Models
{
    /// <summary>
    /// Каталог задач
    /// </summary>
    public class Catalog : BaseEntity
    {
        public Catalog()
        {
            Tasks = new HashSet<Task>();
        }

        /// <summary>
        /// Ключ таблицы
        /// </summary>
        [Key]
        public int CatalogId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// Задачи каталога
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

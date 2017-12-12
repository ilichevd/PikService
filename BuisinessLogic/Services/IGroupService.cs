using BL.DTO;
using BL.DTO.Billing;
using DAL.Models.Billing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace BL.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с группами пользователей
    /// </summary>
    public interface IGroupService : IService<group, groupDto>
    {
        /// <summary>
        /// Быстрый ручной ввод показаний по группе: получить помещения и приборы учёта.
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        IEnumerable<abonentDataEnterDto> GetDataEnterObjects(int groupid, DateTime date);

        /// <summary>
        /// Быстрый ручной ввод показаний по группе: получить помещения и приборы учёта.
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        void SaveEnteredData(IEnumerable<abonentDataEnterDto> answer, DateTime date);

        /// <summary>
        /// получить данные для мониторинга по группе за указанный период
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="pageN"></param>
        /// <param name="pageSize"></param>
        /// <param name="startPeriod"></param>
        /// <param name="endPeriod"></param>
        /// <returns></returns>
        IEnumerable<abonentMonitorDto> Monitor(int groupid, int? pageN, int? pageSize, DateTime startPeriod, DateTime endPeriod);

        /// <summary>
        /// Получить все группы, отсортированные для отображения в виде дерева (переопределение стандартного метода с добавлением сортировки)
        /// </summary>
        /// <returns></returns>
        new List<groupDto> GetAll();
        new int Add(groupDto group);

        /// <summary>
        /// Получить группы в виде дерева для виджета w2ui
        /// </summary>
        /// <returns></returns>
        IEnumerable<groupNodeDto> GetTree();

        List<groupDto> GetSubGroups(int parentId);
        Task<List<groupDto>> GetSubGroupsAsync(int parentId);

        IEnumerable<columnDto> GetColumns();

        /// <summary>
        /// Удалить группу и всё содержимое
        /// </summary>
        /// <param name="groupid">Идентификатор группы</param>
        /// <returns>Количество удалённых объектов</returns>
        Task<int> DeleteComplete(int groupid);

        /// <summary>
        /// Удалить группу по id
        /// </summary>
        /// <param name="groupid">Идентификатор группы</param>
        /// <returns>Количество удалённых объектов</returns>
        Task<int> DeleteById(int groupid);

        /// <summary>
        /// Удалить группу, отвязать помещения, удалить показания ОДПУ и нормативы
        /// </summary>
        /// <param name="groupid">Идентификатор группы</param>
        /// <returns>Количество удалённых объектов</returns>
        Task<int> DeleteWithUnbind(int groupid);
    }
}

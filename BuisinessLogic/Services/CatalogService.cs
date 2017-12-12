using BusinessLogic.DataTransferObjects;
using BusinessLogic.Services;
using DataAccessLevel.Models;
using DataAccessLevel.UnitOfWork;

namespace BusinessLogic.ServiceFactory
{
    /// <summary>
    /// Сервис для работы с каталогами
    /// </summary>
    internal class CatalogService : BaseService<Catalog, CatalogDto>, ICatalogService
    {
        public CatalogService(IUnitOfWork unitOfwork) : base(unitOfwork)
        {
        }
    }
}
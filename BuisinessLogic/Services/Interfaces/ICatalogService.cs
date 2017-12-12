using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLevel.Models;
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с каталогами
    /// </summary>
    public interface ICatalogService : IService<Catalog, CatalogDto>
    {
    }
}

using DataAccessLevel.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PikService.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// Объект для работы с базой данных
        /// </summary>
        protected IUnitOfWork uow { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork"></param>
        protected BaseController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
    }
}

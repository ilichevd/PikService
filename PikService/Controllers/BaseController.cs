using BusinessLogic.ServiceFactory;
using DataAccessLevel.UnitOfWork;
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
        /// Объект для работы с сервисами
        /// </summary>
        protected IServiceFactory _serviceFactory;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="serviceFactory"></param>
        protected BaseController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
    }
}

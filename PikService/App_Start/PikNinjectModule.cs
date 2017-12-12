using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using DataAccessLevel.UnitOfWork;
using BusinessLogic.ServiceFactory;

namespace PikService.App_Start
{
    /// <summary>
    /// Модуль Ninject, настройка внедрения зависимостей в проекте
    /// </summary>
    public class PikNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IServiceFactory>().To<ServiceFactory>();
        }
    }
}
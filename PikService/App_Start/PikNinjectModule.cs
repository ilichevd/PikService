using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using DataAccessLevel.UnitOfWork.Interfaces;
using DataAccessLevel.UnitOfWork;

namespace PikService.App_Start
{
    public class PikNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
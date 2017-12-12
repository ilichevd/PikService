using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.DataTransferObjects;
using DataAccessLevel.Models;

namespace PikService.App_Start
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Инициализирует автоматический маппинг объектов
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DataAccessLevel.Models.Task, TaskDto>()
                    .ForMember(dest => dest.CatalogName, opt => opt.MapFrom(src => src.Catalog.Name))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FIO));
                cfg.CreateMap<TaskDto, DataAccessLevel.Models.Task>()
                    .ForMember(dest => dest.Catalog, opt => opt.Ignore())
                    .ForMember(dest => dest.User, opt => opt.Ignore());

                cfg.CreateMap<User, UserDto>()
                    .ForMember(dest => dest.TasksCount, opt => opt.MapFrom(src => src.Tasks.Count));
                cfg.CreateMap<UserDto, User>()
                    .ForMember(dest => dest.Tasks, opt => opt.Ignore());

                cfg.CreateMap<Catalog, CatalogDto>()
                    .ForMember(dest => dest.TasksCount, opt => opt.MapFrom(src => src.Tasks.Count));
                cfg.CreateMap<CatalogDto, Catalog>()
                    .ForMember(dest => dest.Tasks, opt => opt.Ignore());
            });

            // проверить вышеуказанную конфигурацию
            Mapper.AssertConfigurationIsValid();
        }
    }
}
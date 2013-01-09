using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using GenericRepository.EntityFramework.SampleCore;
using GenericRepository.EntityFramework.SampleCore.Entities;
using GenericRepository.EntityFramework.SampleWebApi.Dtos;
using System;
using System.Reflection;
using System.Web.Http;
using System.Linq;
using GenericRepository.EntityFramework.SampleWebApi.RequestModels;

namespace GenericRepository.EntityFramework.SampleWebApi {

    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            HttpConfiguration config = GlobalConfiguration.Configuration;

            RegisterRoutes(config);
            RegisterDependencies(config);
            RegisterMappings();
        }

        public static void RegisterMappings() {

            MapForPaginatedDto<Country, CountryDto>();
            Mapper.CreateMap<CountryRequestModel, Country>();
        }

        private static void RegisterRoutes(HttpConfiguration config) {

            config.Routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }

        private static void RegisterDependencies(HttpConfiguration config) {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register IEntitiesContext
            builder.Register(_ => new AccommodationEntities())
                   .As<IEntitiesContext>().InstancePerApiRequest();

            // Register repositories
            builder.RegisterType<EntityRepository<Country>>()
                   .As<IEntityRepository<Country>>().InstancePerApiRequest();
            builder.RegisterType<EntityRepository<Resort>>()
                   .As<IEntityRepository<Resort>>().InstancePerApiRequest();
            builder.RegisterType<EntityRepository<Hotel>>()
                   .As<IEntityRepository<Hotel>>().InstancePerApiRequest();

            // Register IMappingEngine
            builder.Register(_ => Mapper.Engine).As<IMappingEngine>().SingleInstance();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }

        private static void MapForPaginatedDto<TEntity, TDto>() where TDto : IDto {

            // NOTE: I'm probably sure that this sucks here. What's the better way?
            // If you have one, pull-request me :)

            Mapper.CreateMap<TEntity, TDto>();
            Mapper.CreateMap<PaginatedList<TEntity>, PaginatedDto<TDto>>()
                            .ForMember(dest => dest.Items,
                                       opt => opt.MapFrom(
                                           src => src.Select(
                                               entity => Mapper.Map<TEntity, TDto>(entity))));
        }
    }
}
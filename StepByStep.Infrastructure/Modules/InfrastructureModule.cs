using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepByStep.Application.Repositories;
using StepByStep.Infrastructure.DataAccess.Repositorios;
using StepByStep.Infrastructure.Mapper;
using System;
using System.Collections.Generic;

namespace StepByStep.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            Mapper(builder);
            Database(builder);
        }

        private void Mapper(ContainerBuilder builder)
        {
            builder.RegisterType<MapperProfile>().As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }

        private void Database(ContainerBuilder builder)
        {
            var conn = Environment.GetEnvironmentVariable("CONN");

            builder.RegisterAssemblyTypes(typeof(Context).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("DataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(conn))
            {
                using Context context = new Context();
                context.Database.Migrate();
            }
        }
    }
    
    }

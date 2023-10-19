using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Core.Mapping;
using RoleBased.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBased.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using RoleBased.Core.Behavior;
using Rolebased.Repository.Interface;
using Rolebased.Repository.Concrete;

namespace RoleBased.IoC.Configuration
{
    public static class ServiceCollectionExtention
    {

        public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RoleBasedDbContext>(option => option.UseSqlServer
            (configuration.GetConnectionString("default")));

            services.AddAutoMapper(typeof(MappingExtention).Assembly);
            services.AddTransient<IStudentInfoRepository,StudentInfoRepository>();

            services.AddTransient<IloginDBRepository ,LoginDBRepository>();
            //services.AddTransient<IStateRepository, StateRepository>();

            services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            return services;
        }
    }
}

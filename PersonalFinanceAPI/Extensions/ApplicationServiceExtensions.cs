using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Persistance;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Core;
using Application.Activities;
using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace PersonalFinanceAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {

            public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
            {
                services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddEndpointsApiExplorer();
            services.AddCors();
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();

            return services;


            }

    }
}
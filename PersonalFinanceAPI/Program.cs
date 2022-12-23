using Microsoft.EntityFrameworkCore;
using PersonalFinance.Helpers;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;
using Microsoft.AspNetCore.Identity;
using Domain;

namespace PersonalFinance

{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();//.Run();
            using var scope = host.Services.CreateScope();

           var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager);

            }
            catch (Exception ex) {
                var message = services.GetRequiredService<ILogger<Program>>();
                message.LogError(ex.ToString(), "An Error has Occured");
            }

            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//var builder = WebApplication.CreateBuilder(args);


//// Add services to the container.

//builder.Services.AddDbContext<PersonalFinanceContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalFinanceContext")));

//builder.Services.AddCors();

//builder.Services.AddControllers().AddJsonOptions(x =>
//{
//    // serialize enums as strings in api responses (e.g. Role)
//    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

//    // ignore omitted parameters on models to enable optional params (e.g. User update)
//    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//});
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.UseCors(x => x
//        .AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader());
//// global error handler
//app.UseMiddleware<ErrorHandlerMiddleware>();

//app.MapControllers();

//app.Run();

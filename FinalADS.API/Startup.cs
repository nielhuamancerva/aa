using AutoMapper;
using FinalADS.Application.Accounts.Assemblers;
using FinalADS.Application.Accounts.Contracts;
using FinalADS.Application.Accounts.Queries;
using FinalADS.Application.Accounts.Services;
using FinalADS.Domain.Accounts.Contracts;
using FinalADS.Infrastructure.Accounts.Persistence.NHibernate.Repository;
using FinalADS.Infrastructure.NHibernate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Common;
using System;
using System.Text;

namespace FinalADS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services.AddAutoMapper();
                services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE")));
                var serviceProvider = services.BuildServiceProvider();
                var mapper = serviceProvider.GetService<IMapper>();
                services.AddSingleton(new NewAccountAssembler(mapper));
               
                services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();
                services.AddScoped<IAccountApplicationService, AccountApplicationService>();
                services.AddTransient<IAccountRepository, AccountNHibernateRepository>((ctx) =>
                {
                    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                    return new AccountNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
                });
               
                services.AddSingleton<IAccountQueries, AccountMySQLDapperQueries>();
               
               
                services.AddAuthorization(cfg =>
                {
                    // NOTE: The claim type and value are case-sensitive
                    cfg.AddPolicy("accessCustomers", p => p.RequireClaim("accessCustomers", "true"));
                });

                services.AddCors();

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
                });


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

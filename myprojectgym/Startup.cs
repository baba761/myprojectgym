using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using myprojectgym.DAL.CountryDAL;
using myprojectgym.DAL.DALGym;
using myprojectgym.DAL.DALNotification;
using myprojectgym.DAL.DALRegistration;
using myprojectgym.DAL.UACDAL;
using myprojectgym.DTO.DTOGYM;
using myprojectgym.DTO.DTONotification;
using myprojectgym.Utility;

namespace myprojectgym
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

         // This method gets called by the runtime. Use this method to add services to the container.
  
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader();
                });
            });
            //option.AddDefaultPolicy(
            //    builder => { } );
            services.AddScoped<IDALUAC, DALUAC>();
            services.AddScoped<IDALRegistration, DALRegistration>();
            services.AddScoped<IDALGym, DALGym>();
            services.AddScoped<Isqlhelper, sqlhelper>();
            services.AddScoped<ICountryDAL, CountryDAL>();
            services.Configure<DTONotification>(Configuration.GetSection("SMTPConfig"));
            services.AddScoped<IDALNotification, DALNotification>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

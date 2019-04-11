using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Danrevi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Danrevi.Services;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace Danrevi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod());
            });
            services.AddDbContext<danrevi_webContext>(options => options.UseMySql(Configuration.GetConnectionString("SqlConn")));
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddAutoMapper();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1",new Info { Title = "Danrevi API",Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Models.Courses,Dto.CourseDto>();
                config.CreateMap<Dto.CourseDto,Models.Courses>();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json","Video Game API V1"); });
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

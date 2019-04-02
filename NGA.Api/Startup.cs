using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NGA.API.Config;
using NGA.API.Filter;
using NGA.Core.EntityFramework;
using NGA.Core.Model;
using NGA.Data;
using NGA.Data.Service;
using NGA.Data.SubStructure;
using NGA.Data.ViewModel;
using NGA.Domain;
using Swashbuckle.AspNetCore.Swagger;

namespace NGA.API
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
            services.AddDbContext<NGADbContext>();

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddAutoMapper(typeof(Startup).Assembly);
            #endregion

            #region MVC Configration
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidatorActionFilter));//MVC kendisi attributelara gore zaten validation yapiyor. 
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion

            #region Dependency Injection 
           
            services.AddSingleton(mapper);
            services.AddSingleton<NGADbContext>();
            services.AddSingleton<UnitOfWork>();
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IParameterService, ParameterService>();
            services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));


            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "NGA",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None"
                    //Contact = new Contact
                    //{
                    //    Name = "Shayne Boyer",
                    //    Email = string.Empty,
                    //    Url = "https://twitter.com/spboyer"
                    //},
                    //License = new License
                    //{
                    //    //Name = "Use under LICX",
                    //    //Url = "https://example.com/license"
                    //}
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc(options =>
            {
                options.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NGA V1");
            });

            //app.UseHttpsRedirection(); //for diseable SSL
        }
    }
}

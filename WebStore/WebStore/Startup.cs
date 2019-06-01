using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Implementations;
using WebStore.Infrastructure.Implementations.Sql;
using WebStore.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace WebStore
{
    public class Startup
    {
        /// <summary>
        /// Добавляем свойство для доступа к конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Добавляем новый конструктор, принимающий интерфейс IConfiguration
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем сервисы, необходимые для mvc
            services.AddMvc();
            // Добавляем разрешение зависимости
            //services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IEmployeesData, SqlEmployeesData>();
            services.AddDbContext<EmployeesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /*services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));*/
            services.AddScoped<IProductData, SqlProductData>();
            services.AddDbContext<WebStoreContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Добавляем расширение для использования статических файлов, т.к.
            //appsettings.json - это статический файл
            app.UseStaticFiles();
            //var hello = Configuration["CustomHelloWorld"];

            //Добавляем обработку запросов в mvc-формате
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

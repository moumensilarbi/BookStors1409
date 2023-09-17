using bookstore.Models;
using bookstore.Models.Reposotores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore
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
            services.AddMvc();

            //use this services for memory Dependecies
            //services.AddSingleton<Ibookstorerepo<Author>, Ahthorrepo >();
            //services.AddSingleton<Ibookstorerepo<Book>, bookrepo>();

            //use this services for db ef core  Dependecies
            services.AddScoped<Ibookstorerepo<Author>, AhthorDBrepo>();
            services.AddScoped<Ibookstorerepo<Book>,BookDBrepository>();

            services.Configure<CookiePolicyOptions>(options => 
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<BookstoreDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("sqlconn"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //  app.UseMvc();
            // app.UseStaticFiles();
            //app.UseMvc(route => {

            //    route.MapRoute("default", "{controller=Book}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
        }
    }
}

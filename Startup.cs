using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mvc.Dal.Repositories;
using Mvc.Models;
using Mvc.Dal.Interfaces;
using Mvc.Dal;
using Microsoft.Extensions.Options;
using Mvc.Http;
using DotNetify;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Mvc
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
            services.AddMemoryCache();
            services.AddSignalR();
            services.AddDotNetify()
            ;
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IWebClient, WebClient>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseSignalR(routes => routes.MapDotNetifyHub());
            app.UseDotNetify(config => {

                config.RegisterAssembly(GetType().Assembly/* name of the assembly where the view model classes are located */);
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data;

namespace Restaurant
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
            services.AddDbContextPool<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDb"));
            });

            //services.AddScoped<IRestaurantData, SqlRestaurantData>(); //Use only for SQL Data
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.Use(SayHelloMiddleware);

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc();
        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate nextProcessInPipeline)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hello"))
                    await ctx.Response.WriteAsync("Hello World from custom middleware");
                else
                    await nextProcessInPipeline(ctx);
            };
        }
    }
}

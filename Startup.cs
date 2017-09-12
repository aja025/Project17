using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Project17.Data;
using Microsoft.AspNetCore.Rewrite;
using System.Net;
using Swashbuckle.AspNetCore.Swagger;

namespace Project17
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
            services.AddDbContext<Project17Context>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Perform automatic migration
                using (var context = provider.GetRequiredService<Project17Context>())
                {
                    context.Database.Migrate();
                    DbInitializer.Initialize(context);
                }
            }
                    
            // Setup rewrite rules to allow page refreshes to work with Angular
            app.UseRewriter(new RewriteOptions()
                .AddIISUrlRewrite(env.ContentRootFileProvider, "web.config"));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}

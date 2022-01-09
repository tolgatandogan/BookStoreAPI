using BookStore.Business.Abstract;
using BookStore.Business.Concrete;
using BookStore.Data.Abstract;
using BookStore.Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebAPI
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
            services.AddSingleton<IBookDal, EfBookDal>();
            services.AddSingleton<IBookService, BookService>();

            services.AddSingleton<IAuthorDal, EfAuthorDal>();
            services.AddSingleton<IAuthorService, AuthorService>();

            services.AddSingleton<IPublisherDal, EfPublisherDal>();
            services.AddSingleton<IPublisherService, PublisherService>();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
                });
            }

            app.UseSwagger().
           UseSwaggerUI(setup =>
           {
               setup.SwaggerEndpoint($"/swagger/v1/swagger.json", "Version 1.0");
               setup.OAuthScopeSeparator(" ");
               setup.OAuthUsePkce();
               setup.DefaultModelsExpandDepth(-1);
           });

            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

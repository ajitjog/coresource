using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreApi1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
                services.AddCors(options =>
                {
                    options.AddPolicy("mypol",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                      
                    });
                });
    
            services.AddMvc();
                                                               
            services.AddSwaggerGen(c =>
            {

            c.SwaggerDoc("coreapi", new Info() { Title = "My Web API Component",
                                                                    Version = "1.0" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/coreapi/swagger.json", "My Web API UI");
            });
            app.UseCors("mypol");
            app.UseMvc();
           

            app.Run(async (context) =>
            {   
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

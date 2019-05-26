using Link.Common.Domain.Framework.Communication;
using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Application;
using Link.EmailManagement.Domain.Services.Interfaces;
using Link.EmailManagement.Infrastructure.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Link.EmailManagement.Infrastructure.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Link.EmailManagement.API", Version = "v1" });
            });

            services.AddCors();

            services.AddTransient<IMailBox, MailBox>();
            services.AddTransient<IMailCreator, MailCreator>();

            services.Scan(scan => scan
                .FromAssemblyOf<LinkApplication>()
                .AddClasses(classes => classes.AssignableTo<IApplication>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<LinkApplication>()
                .AddClasses(classes => classes.AssignableTo<ICommandHandler>())
                .AsSelfWithInterfaces()
                .FromAssemblyOf<LinkApplication>()
                .AddClasses(classes => classes.AssignableTo<ICommunicationChannel>())
                .AsSelfWithInterfaces()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandValidator<,>)))
                .AsSelfWithInterfaces()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryRunner<>)))
                .AsSelfWithInterfaces());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Link.EmailManagement.API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Link.Common.Domain.Framework.Communication;
using Link.Common.Domain.Framework.Frameworks;
using Link.IoT.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;
using Link.IoT.Hub.Cloud.Azure;
using Link.IoT.Hub.Cloud.Azure.Interfaces;

namespace Link.IoT.Infrastructure.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Link.IoT.API", Version = "v1" });
            });

            services.AddTransient<IIoTHub>(provider =>
                new AzureIoTHub(Configuration.GetSection("IoTHub").Value));

            services.AddCors();

            Assembly[] assemblies =
            {
                typeof(Startup).Assembly,
                typeof(LinkApplication).Assembly
            };

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .AssignableTo<IApplication>()
                .AsImplementedInterfaces()
                .AsSelf()
                .SingleInstance();

            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(CommandHandler<,>));

            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(QueryRunner<,>));

            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(ICommandValidator<,>));

            builder.RegisterType<CommunicationChannel>().As<ICommunicationChannel>();

            builder.Populate(services);

            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Link.IoT.API V1");
            });

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using RestApi.Shared;
using RestApi.Shared.Rest;

namespace RestApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Adding our in memory database for the basic template
            //TODO Replace this with the actual database connection
            services.AddDbContext<RestApiDbContext>(options => options.UseInMemoryDatabase("RestApiDatabase"));

            //patch up mvc to handle json as strings instead of numbers
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            //now to use the injector
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces();

            //Adding the Rest handlers here
            builder.RegisterGeneric(typeof(RestGetListHandler<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RestGetListRequest<,>));
            builder.RegisterGeneric(typeof(RestSingleGetHandler<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RestSingleGetRequest<,>));
            builder.RegisterGeneric(typeof(RestPostHandler<,,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RestPostRequest<,,>));
            builder.RegisterGeneric(typeof(RestPutHandler<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(RestPutRequest<,>));

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

namespace CsharpSampleSolution.Web.API
{
    using CsharpSampleSolution.Common.Business;
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Web.API.ErrorHandling;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Dependency injection
            // DI let's us easily define new implementation for the service.
            // Currently we reuse one which is implemented in our Common library, but that
            // could also be one we have defined in our API project.
            // Just switch implementation type

            // Transient created new instance of the service, each time it's requested
            // <IService, ServiceImplementation>
            services.AddTransient<IExtendedOperations, ExtendedOperations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register our custom middleware which will serialize error messages into JSON
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });

            app.UseMvc();
        }
    }
}

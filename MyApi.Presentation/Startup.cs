using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyApi.Application.Handlers;
using MyApi.Domain.Interfaces;
using MyApi.Domain.Repositories;
using MyApi.Infrastructure;
using MyApi.Infrastructure.Repositories;
using MyApi.Infrastructure.Repositories.Base;

namespace MyApi.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Context>(
                m => m.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")),
                ServiceLifetime.Singleton
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Api Review", Version = "V1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Review API V1");
            });
        }
    }
}

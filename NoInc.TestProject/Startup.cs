using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NoInc.BusinessLogic;
using NoInc.BusinessLogic.Interfaces;
using NoInc.DataAccess;
using NoInc.DataAccess.DatabaseContext;
using NoInc.DataAccess.Interfaces;

namespace NoInc.TestProject
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
            services.AddControllers();
            services.AddScoped<IInterestDataAccess, InterestDataAccess>();
            services.AddScoped<ISkillDataAccess, SkillDataAccess>();
            services.AddScoped<IUserDataAccess, UserDataAccess> ();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(BusinessLogic.MappingProfiles.InterestProfile), typeof(BusinessLogic.MappingProfiles.SkillProfile), typeof(MappingProfiles.InterestProfile), typeof(MappingProfiles.SkillProfile));
            services.AddDbContext<NoIncContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NoIncDatabase")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoInc.TestProject", Version = "v1" });
            });
            services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/error-local-development");
                //app.UseExceptionHandler("/error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoInc.TestProject v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
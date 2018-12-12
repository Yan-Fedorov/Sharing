using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sharing.Business;
using Sharing.Business.Interfaces;
using Sharing.DataAccess;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using Sharing.DataAccessCore.Realization;
using Sharing.Domain.DataTransfer;
using Sharing.Domain.Mappers;
using Swashbuckle.AspNetCore.Swagger;

namespace Sharing.WebApi
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
            services.AddDbContext<SharingContext>();            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRepository<Renter>, RenterRepository>();
            services.AddScoped<IRepository<Lessor>, LessorRepository>();
            services.AddScoped<IRepository<Machine>, MachineRepository>();
            services.AddScoped<IRepository<RenteredMachine>, RenteredMachineRepository>();
            services.AddScoped<IRepository<Characteristic>, CharacteristicRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
            services.AddScoped<IMapper<Machine, MachineServerDto>, MachineMappers>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IDisplayShopService, DisplayShopService>();

            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            SeedData.Initialize(new SharingContext());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(cfg =>
            {
                cfg.AllowAnyHeader();
                cfg.AllowAnyMethod();
                cfg.AllowAnyOrigin();
            });

            app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}

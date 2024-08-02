using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Admin;
using KisanSnehi.Repositories.Farmer;
using KisanSnehi.Repositories.Home;
using KisanSnehi.Repositories.Supplier;
using KisanSnehi.Repositories.Trader;
using KisanSnehi.Services.Trader;
using KisanSnehi.Services.Farmer;
using KisanSnehi.Services.Home;
using KisanSnehi.Services.Supplier;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KisanSnehi.Services.Admin;

namespace KisanSnehiAPI
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


            services.AddDbContext<KisanSnehiDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("myconn")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My Api", Version = "v2" });
            });


            services.AddTransient<IHomeServices, HomeServices>();
            services.AddTransient<IFarmerProfileServices, FarmerProfileServices>();
            services.AddTransient<ISupplierServices, SupplierServices>();
            services.AddTransient<IHomeRepository, HomeRepository>();
            services.AddTransient<ITraderServices, TraderServices>();
            services.AddTransient<IAdminServices, AdminServices>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IFarmerProfileRepository, FarmerProfileRepository>();
            services.AddTransient<IFarmerFertilizerRepository, FarmerFertilizerRepository>();
            services.AddTransient<IFarmerGuidanceRepository, FarmerGuidanceRepository>();
            services.AddTransient<IFarmerGuidanceService, FarmerGuidanceService>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IFarmerFertilizerService, FarmerFertilizerService>();
            services.AddTransient<ITraderRepository, TraderRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

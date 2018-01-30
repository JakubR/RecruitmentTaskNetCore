using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services;
using SIENN.Services.Common;
using SIENN.Services.Products;
using SIENN.Services.Units;
using SIENN.WebApi.Automapper;

namespace SIENN.WebApi
{
    public class DependecyRegistration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddScoped(typeof(IWriteOnlyRepository<>), typeof(WriteOnlyRepository<>));

            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(ICrudService<Category>), typeof(CategoryService));
            services.AddScoped(typeof(ICrudService<Unit>), typeof(UnitService));
            services.AddScoped(typeof(ICrudService<ProductType>), typeof(ProductTypeService));            

            services.AddScoped(typeof(ICurrentDateTime), typeof(CurrentDateTime));

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SiennDbContext>(options =>
            {                
                options.UseSqlServer(connectionString);
            });
        }
    }
}
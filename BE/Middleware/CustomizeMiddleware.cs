using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Mapping.Fee;
using MISA.Core.Services;
using MISA.Infrastructure.Repository;

namespace MISA.Api.Middleware
{
    /// <summary>
    /// Lớp tĩnh: khai báo DI
    /// </summary>
    public static class CustomizeMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IFeeGroupRepository, FeeGroupRepository>();
            services.AddScoped<IFeeGroupService, FeeGroupService>();

            services.AddScoped<IFeeRangeRepository, FeeRangeRepository>();
            services.AddScoped<IFeeRangeService, FeeRangeService>();

            services.AddScoped<IFeeRepository, FeeRepository>();
            services.AddScoped<IFeeService, FeeService>();

            services.AddScoped<IUnitFeeRepository, UnitFeeRepository>();
            services.AddScoped<IUnitFeeService, UnitFeeService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Nên khai báo Profile để tránh lỗi trên .net5
            services.AddAutoMapper(typeof(ModelToResourceProfile));
        }
    }
}

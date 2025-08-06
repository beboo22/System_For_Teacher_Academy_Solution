using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction;
using Service.Impelementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ApplyServiceForServLayer
    {
        public static void ApplyServiceForServiceLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IReadStdServ, ReadStdServ>();
            services.AddScoped<IWriteStdServ, WriteStdServ>();
        }
    }
}

using KissLog;
using KissLog.Apis.v1.Listeners;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Config
{
    public class LogConfig
    {
        public static void RegisterKissLogListeners(IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new KissLogApiListener(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"],
                configuration["KissLog.Enviroment"]
            ));
        }
    }
}

﻿namespace DZ_13_WebApi.Modules
{
    public static class CoreLoggingModule
    {
        public static IServiceCollection UseCoreLogging(this IServiceCollection services)
        {
            return services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });
        }
    }
}

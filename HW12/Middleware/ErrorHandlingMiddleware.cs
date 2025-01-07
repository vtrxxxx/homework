﻿using AspNetCoreHero.ToastNotification.Abstractions;

namespace HW12.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly INotyfService _notifyService;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, INotyfService notifyService)
        {
            _logger = logger;
            _notifyService = notifyService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
              
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                _logger.LogInformation(message);
            }
        }
    }
}

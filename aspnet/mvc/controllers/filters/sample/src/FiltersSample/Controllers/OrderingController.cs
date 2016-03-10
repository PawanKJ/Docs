﻿using FiltersSample.Filters;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Controllers
{
    [OrderLoggingActionFilter(Name = "Class Level Attribute")]
    public class OrderingController : Controller
    {
        private readonly ILogger _logger;
        public OrderingController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<OrderingController>();
        }

        [OrderLoggingActionFilter(Name = "Method Level Attribute")]
        public IActionResult Index()
        {
            return Content("Ordering Sample.");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"OnActionExecuting for {nameof(OrderingController)}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"OnActionExecuted for {nameof(OrderingController)}");
            base.OnActionExecuted(context);
        }
    }
}

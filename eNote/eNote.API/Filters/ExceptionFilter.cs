﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using eNote.Model;

namespace eNote.API.Filters
{
    public class ExceptionFilter(ILogger<ExceptionFilter> logger) : ExceptionFilterAttribute
    {
        readonly ILogger<ExceptionFilter> _logger = logger;

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An error occurred: {Message}", context.Exception.Message);

            if (context.Exception is UserException)
            {
                context.ModelState.AddModelError("userError", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError("ERROR", "Server side error, please check logs");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(x => x.Key, y => y.Value.Errors.Select(z => z.ErrorMessage));

            context.Result = new JsonResult(new { errors = list });
        }
    }
}

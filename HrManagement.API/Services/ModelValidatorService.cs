using HrManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.API.Services
{
    /// <summary>
    /// Used for Global Model validator middleware
    /// </summary>
    public static class ModelValidatorService
    {
        /// <summary>
        /// Global Validator Servce
        /// </summary>
        public static void AddModelValidator(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
          apiBehaviorOptions.InvalidModelStateResponseFactory = (actionContext) =>
          {
              string msg = string.Empty;
              string key = string.Empty;
              try
              {
                  if (actionContext.ModelState.Values.Select(err => err.Errors.Select(y => y.ErrorMessage)).ToArray().Length > 1)
                  {
                      msg = actionContext.ModelState.Values.Select(err => err.Errors.Select(y => y.ErrorMessage)).ToArray()[1].ToArray()[0];
                      key = actionContext.ModelState.Keys.ToArray()[0];
                  }
                  else
                  {
                      msg = actionContext.ModelState.Values.Select(err => err.Errors.Select(y => y.ErrorMessage)).ToArray()[0].ToArray()[0];
                      key = actionContext.ModelState.Keys.ToArray()[0];

                  }
              }
              catch
              {
                  msg = "Something Went Wrong on Validation";
              }
              if (string.IsNullOrEmpty(msg))
              {
                  msg = "Bad Request";
              }
             
              return new BadRequestObjectResult(new CommonResponse
              {
                  Success = false,
                  Code = "100",
                  Message = msg
              });
          });
        }
    }
}

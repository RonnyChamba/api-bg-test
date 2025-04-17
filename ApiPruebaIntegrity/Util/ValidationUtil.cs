
using Microsoft.AspNetCore.Mvc;
namespace ApiPruebaIntegrity.Util
{
    public class ValidationUtil
    {

        public static BadRequestObjectResult CreateJsonRespStateInvalid(ActionContext actionContext) {

            var errors = actionContext.ModelState
                .Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return new BadRequestObjectResult(new
            {
                status = 400,
                message = "Validation failed",
                errors
            });     
        }
    }
}

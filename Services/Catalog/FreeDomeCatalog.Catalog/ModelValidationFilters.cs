using FreeDomeCatalog.Catalog.Models;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using respons1.Response;

namespace FreeDomeCatalog.Catalog.Filters
{
    public class ModelValidationFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            if (!context.ModelState.IsValid) { 
            var errorMessages = context.ModelState.Values
                         .SelectMany(v => v.Errors)
                         .Select(e => e.ErrorMessage)
                         .ToList();


            var errorResponse = new ApiResponse<Category>(null, errorMessages);
            errorResponse.Success = false;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}

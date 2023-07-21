using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Formula1Store.Core.Extensions
{
    public static class HttpContextExtensionsHelper
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            var userId = httpContext.User.Identity!.IsAuthenticated
            ?
                httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()
                :
                httpContext.Request.Cookies["guest"];

            return userId;
        }
    }
}

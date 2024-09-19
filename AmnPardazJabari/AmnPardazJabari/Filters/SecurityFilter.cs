using System.Net;
using AmnPardazJabari.Application.UserId;
using AmnPardazJabari.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Extensions;
using OnlineGym.Application.Security;

namespace AmnPardazJabari.Filters
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly string role;
        public SecurityFilter(RoleId role)
        {
            this.role = role.GetDisplayName();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool isAccess = false;
            base.OnActionExecuting(context);

            string authorization = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authorization))
            {
                // if (authorization.Contains("Bearer"))
                // {
                    //string token = authorization.Replace("Bearer ", "");
                    var claimsPrincipal = TokenGenerator.ValidateToken(authorization);
                    if (claimsPrincipal != null)
                    {
                        //ConstError
                        var roles = claimsPrincipal.Claims.Where(x =>
                        x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                        foreach (var claim in roles)
                        {
                            if (claim.Value == role)
                            {
                                var userId = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "userId").Value;
                                var userName = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "userName").Value;
                                var userContext = (IUserContext)context.HttpContext.RequestServices.GetService(typeof(IUserContext));
                                userContext.UserId = Guid.Parse(userId);
                                userContext.UserName = userName;
                                isAccess = true;
                                return;
                            }
                        }
                    // }
                }
            }
            if (isAccess == false)
            {
                UnAhutorize(context);
            }

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            //throw new Exception("Finished");
        }

        private void UnAhutorize(ActionExecutingContext context)
        {
            //context.Result = new JsonResult(new { StatusCode = (int)HttpStatusCode.Unauthorized, ContentType = "Application/json", Value = "دسترسی مجاز نیست" });

            var result = new JsonResult(new { Message = "دسترسی مجاز نیست" }) { StatusCode = (int)HttpStatusCode.Unauthorized, ContentType = "application/json" };
            context.Result = result;
        }
    }
}

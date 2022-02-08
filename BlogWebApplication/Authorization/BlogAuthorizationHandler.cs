using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogWebApplication.Authorization{
    public class BlogAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Post>{
        private readonly UserManager<ApplicationUser> _userManager;
        public BlogAuthorizationHandler(UserManager<ApplicationUser> userManager){
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Post resource)
        {
            var applicationUser = await _userManager.GetUserAsync(context.User);

            if((requirement.Name == Operations.Update.Name || requirement.Name == Operations.Delete.Name) && applicationUser == resource.Creator){
                context.Succeed(requirement);
            }

            if (requirement.Name == Operations.Read.Name && !resource.Published && applicationUser == resource.Creator)
            {
                context.Succeed(requirement);
            }
        }
    }
}
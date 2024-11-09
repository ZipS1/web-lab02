using lab02.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace lab02.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<AppUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<AppUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}

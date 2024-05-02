using IdentityModel;
using IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityService.Pages.Account.Register
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index(UserManager<ApplicationUser> userManager) : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        [BindProperty]
        public bool RegisterSuccess { get; set; }

        public IActionResult OnGet(string? returnUrl)
        {
            Input = new RegisterViewModel { ReturnUrl = returnUrl };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input?.Button != "register") return Redirect("~/");

            //TODO - Fill in the remaining user info and add remaining fields to the html
            //so all the required fields are filled through the UI and bound to the respective fields
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    EmailConfirmed = true
                };

                IdentityResult? result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(user,
                    [
                        new(JwtClaimTypes.Name, Input.FullName)
                    ]);

                    RegisterSuccess = true;
                }
            }

            return Page();
        }
    }
}

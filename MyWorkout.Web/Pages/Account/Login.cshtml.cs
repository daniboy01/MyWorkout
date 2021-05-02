using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<User> SignInManager { get; }
        public LoginModel(SignInManager<User> signInManager) => SignInManager = signInManager;
        public class InputModel
        {
            [Display(Name = "Felhasználónév")]
            [Required(ErrorMessage = "A felhasználónév megadása kötelezõ")]
            public string UserName { get; set; }
            [Display(Name = "Jelszó")]
            [Required(ErrorMessage = "A jelszó megadása kötelezõ"), DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Maradjak belépve")]
            public bool KeepMeSignedIn { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public ActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Index");
            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var signInResult = await SignInManager.PasswordSignInAsync(
                Input.UserName, Input.Password, Input.KeepMeSignedIn, false);
                if (!signInResult.Succeeded)
                    ModelState.AddModelError("", "Sikertelen bejelentkezési kísérlet.");
                else
                    return LocalRedirect("/Index");
            }
            return Page();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public User MyWorkoutUser { get; private set; }
        public IEnumerable<string> Roles { get; private set; }
        public async Task OnGet([FromServices] UserManager<User> userManager)
        {
            MyWorkoutUser = await userManager.GetUserAsync(HttpContext.User);
            Roles = await userManager.GetRolesAsync(MyWorkoutUser);
        }
    }

}

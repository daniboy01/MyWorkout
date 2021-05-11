using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Bll.Services;

namespace MyWorkout.Web.Pages
{
    public class SubscribeModel : PageModel
    {

        public SubsrciptionService SubsrciptionService { get; }


        public SubscribeModel(SubsrciptionService subsrciptionService)
        {
            SubsrciptionService = subsrciptionService;
        }

        public IActionResult OnGet()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            SubsrciptionService.CreateNewSubscription(userId);
            return new RedirectToPageResult("/WorkoutPlans/Index");
        }
    }
}

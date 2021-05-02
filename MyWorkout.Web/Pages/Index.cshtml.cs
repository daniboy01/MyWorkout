using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkout.Web.Pages
{
    public class IndexModel : PageModel
    {
        public CategoryService CategoryService { get; }
        public List<CategoryHeader> CategoryHeaders { get; set; }
        public IndexModel( CategoryService categoryService )
        {
            CategoryService = categoryService;
        }
        

        public async Task<IActionResult> OnGet([FromServices] MyWorkoutDbContext dbcontext)
        {
            CategoryHeaders = await CategoryService.GetCategories();

            return Page();
        }
    }
}

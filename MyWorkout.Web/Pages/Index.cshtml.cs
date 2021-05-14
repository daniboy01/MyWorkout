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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MyWorkout.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment env;

        public CategoryService CategoryService { get; }
        public List<CategoryHeader> CategoryHeaders { get; set; }
        public IndexModel( CategoryService categoryService, IWebHostEnvironment env )
        {
            CategoryService = categoryService;
            this.env = env;
        }
        

        public async Task<IActionResult> OnGet([FromServices] MyWorkoutDbContext dbcontext)
        {
            CategoryHeaders = await CategoryService.GetCategories();

            return Page();
        }

        public string LoadImage(int id)
        {
            if (System.IO.File.Exists($"{this.env.WebRootPath}/images/category_covers/{id}.jpg"))
            {
                return $"{id}.jpg";
            }
            return "blank.png";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;

namespace MyWorkout.Web.Pages.Admin
{
    public class ManageCategoriesModel : PageModel
    {
        private readonly CategoryService categoryService;

        public IEnumerable<SelectListItem> AllCategories;

        [BindProperty( SupportsGet = true )]
        public int CategoryId { get; set; }



        [BindProperty]
        public CategoryHeader SelectedCategory { get; set; }

        public ManageCategoriesModel( CategoryService categoryService )
        {
            this.categoryService = categoryService;
        }




        public async Task OnGetAsync()
        {
            var allCategories = await categoryService.GetCategories();

            AllCategories = allCategories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            if( CategoryId != 0)
            {
                SelectedCategory = allCategories.Where(c => c.Id == CategoryId).FirstOrDefault();
            }
            else
            {
                SelectedCategory = new CategoryHeader();
            }
        }

        public async Task<IActionResult> OnPostAddOrUpdateAsync()
        {
            if( ModelState.IsValid)
            {
                await categoryService.AddOrUpdateCategory(SelectedCategory);
                return new RedirectToPageResult("/Admin/ManageCategories");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await categoryService.DeleteCategory(SelectedCategory.Id);
            return new RedirectToPageResult("/Admin/ManageCategories");

        }
    }
}

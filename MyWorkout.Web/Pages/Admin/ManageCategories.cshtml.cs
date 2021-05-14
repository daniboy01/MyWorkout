using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MyWorkout.Web.Pages.Admin
{
    public class ManageCategoriesModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        private readonly SubsrciptionService subsrciptionService;
        private readonly long fileSizeLimit;
        private List<string> permittedExtensions;

        private readonly CategoryService categoryService;

        public IEnumerable<SelectListItem> AllCategories;

        [BindProperty( SupportsGet = true )]
        public int CategoryId { get; set; }



        [BindProperty]
        public CategoryHeader SelectedCategory { get; set; }

        [BindProperty]
        public IFormFile CoverImage { get; set; }

        public ManageCategoriesModel( CategoryService categoryService, 
            IConfiguration config,
            IWebHostEnvironment env,
            SubsrciptionService subsrciptionService)
        {
            this.categoryService = categoryService;
            this.config = config;
            this.env = env;
            this.subsrciptionService = subsrciptionService;
            this.fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            this.permittedExtensions = config.GetSection("PemittedExtensions").Get<List<string>>();
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

            if ( ModelState.IsValid )
            {
                int updatedOrNewCategoryId = await categoryService.AddOrUpdateCategory(SelectedCategory);
                

                if (CoverImage != null && CoverImage.Length > 0)
                {

                    var fileName = CoverImage.FileName;
                    var ext = Path.GetExtension(fileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {

                        ModelState.AddModelError("CoverImage", "Extension not permitted!");

                        return Page();
                    }


                    var filePath = Path.Combine(this.env.WebRootPath, $"images/category_covers/{updatedOrNewCategoryId}{ext}");
                    using var image = Image.Load(CoverImage.OpenReadStream());
                    image.Mutate(x => x.Resize(230, 350));
                    image.Save(filePath);
                }

                await subsrciptionService.NotifySubscriptedUsers(
                    "New category", $"{SelectedCategory.Name} has uploaded");

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

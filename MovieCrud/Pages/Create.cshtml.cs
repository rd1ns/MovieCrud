using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCrud.Entity;
using MovieCrud.Models;

namespace MovieCrud.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Movies> repository;

        public CreateModel(IRepository<Movies> repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Movies Movies { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
                await repository.CreateAsync(Movies);
            return Page();
        }
    }
}

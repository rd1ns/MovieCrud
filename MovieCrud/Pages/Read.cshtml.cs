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
    public class ReadModel : PageModel
    {
        private readonly IRepository<Movies> repository;

        public ReadModel(IRepository<Movies> repository)
        {
            this.repository = repository;

        }
        public List<Movies> movieList { get; set; }
        public async Task OnGet()
        {
            movieList = await repository.ReadAllAsync();
        }
    }
}

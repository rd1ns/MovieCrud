using MovieCrud.Models;
using MovieCrud.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCrud.Paging
{
    public class MovieList
    {
        public IEnumerable<Movies> movies { get; set; }
        public PagingInfo pagingInfo { get; set; }

    }
}

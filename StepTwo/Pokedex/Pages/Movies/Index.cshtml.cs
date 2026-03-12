using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieType { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> typeQuery = from m in _context.Movie
                                            orderby m.Type
                                            select m.Type;
            // </snippet_search_linqQuery>

            var movies = from m in _context.Movie
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieType))
            {
                movies = movies.Where(x => x.Type == MovieType);
            }

            // <snippet_search_selectList>
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Movie = await movies.ToListAsync();
        }
    }
}

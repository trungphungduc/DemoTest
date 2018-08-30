using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace ViewComponentSample.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly DemoContext db;

        public PriorityListViewComponent(DemoContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority)
        {
            var items = await GetItemsAsync(maxPriority);
            return View(items);
        }
        private Task<List<MovieModel>> GetItemsAsync(int maxPriority)
        {
            return db.Movie.Where(x => x.Price <= maxPriority).ToListAsync();
        }
    }
}
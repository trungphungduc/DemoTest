using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DataAccess.Services
{
    public class MovieService : GenericRepository<MovieModel>
    {
        public MovieService(DemoContext context) : base (context)
        {
        }

        public async Task<bool> IsTitleDuplicate(string title)
        {
            return await _dbset.AnyAsync(a=>a.Title.ToLower().Equals(title.ToLower()));
        }
    }
}

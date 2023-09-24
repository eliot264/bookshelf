using Bookshelf.DbContexts;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Services
{
    public class PublisherDataService : GenericDataService<Publisher>
    {
        public PublisherDataService(BookshelfDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public override async Task<Publisher> Create(Publisher entity)
        {
            using(BookshelfDbContext context = _contextFactory.CreateDbContext())
            {
                context.Attach(entity);
                EntityEntry<Publisher> result = await context.Publishers.AddAsync(entity);
                await context.SaveChangesAsync();

                return result.Entity;
            }
        }

        public override async Task<IEnumerable<Publisher>> GetAll()
        {
            using (BookshelfDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Publisher> publishers = await context.Publishers.Include(p => p.Country).ToListAsync();

                return publishers;
            }
        }
    }
}

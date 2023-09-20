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
    public class CountryDataService : GenericDataService<Country>
    {
        public CountryDataService(BookshelfDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public async override Task<IEnumerable<Country>> GetAll()
        {
            using (BookshelfDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Country> entities = await context.Countries.Include(country => country.Continents).ToListAsync();

                return entities;
            }
        }

        public override async Task<Country> Create(Country country)
        {
            using (BookshelfDbContext context = _contextFactory.CreateDbContext())
            {
                //context.Attach(country);
                //EntityEntry<Country> createdResult = await context.AddAsync(country);

                //foreach (Continent continent in country.Continents)
                //{
                //    context.Attach(continent);
                //    foreach(Country _country in continent.Countries)
                //    {
                //        context.Attach(_country);
                //    }
                //}

                //await context.SaveChangesAsync();

                Country newCountry = new Country
                {
                    Name = country.Name
                };

                foreach(Continent continent in country.Continents)
                {
                    newCountry.Continents.Add(context.Continents.FirstOrDefaultAsync(c => c.Id == continent.Id).Result);
                }

                EntityEntry<Country> createdResult = context.Countries.AddAsync(newCountry).Result;

                foreach(Continent continent in newCountry.Continents)
                {
                    context.Continents.Update(continent);
                }

                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }
    }
}

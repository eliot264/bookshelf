using Bookshelf.DbContexts;
using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Services
{
    public class ContinentSeedService : IDataSeedService<Continent>
    {
        private readonly BookshelfDbContextFactory _bookshelfDbContextFactory;

        public ContinentSeedService(BookshelfDbContextFactory bookshelfDbContextFactory)
        {
            _bookshelfDbContextFactory = bookshelfDbContextFactory;
        }

        public void Seed()
        {
            using(BookshelfDbContext context = _bookshelfDbContextFactory.CreateDbContext())
            {
                if (!context.Continents.Any(c => c.Name == "Asia"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "Asia"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "Africa"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "Africa"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "North America"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "North America"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "South America"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "South America"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "Antarctica"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "Antarctica"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "Europe"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "Europe"
                    });
                }

                if (!context.Continents.Any(c => c.Name == "Australia"))
                {
                    context.Continents.Add(new Continent
                    {
                        Name = "Australia"
                    });
                }

                context.SaveChanges();
            }
        }
    }
}

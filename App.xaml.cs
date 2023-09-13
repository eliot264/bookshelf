using Bookshelf.DbContexts;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bookshelf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=bookshelf.db";

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (BookshelfDbContext dbContext = new BookshelfDbContext(options))
            {
                dbContext.Database.Migrate();

                //dbContext.Languages.Add(new Language
                //{
                //    Name = "polish"
                //});
                //dbContext.SaveChanges();
                //dbContext.Continents.Add(new Continent
                //{
                //    Name = "Europe"
                //});
                //dbContext.SaveChanges();
                //dbContext.Countries.Add(new Country
                //{
                //    Name = "Poland"
                //});
                //dbContext.SaveChanges();
                //dbContext.Countries.First().Continents.Add(dbContext.Continents.First());
                //dbContext.SaveChanges();
                //dbContext.Formats.Add(new Format
                //{
                //    Name = "printed book"
                //});
                //dbContext.SaveChanges();
                //dbContext.Authors.Add(new Author
                //{
                //    FirstName = "Remigiusz",
                //    SecondName = "Bogusław",
                //    LastName = "Mróz",
                //    BirthDate = new DateOnly(1987, 1, 15),
                //    DeathDate = null,
                //    CountryId = 1
                //});
                //dbContext.SaveChanges();
                //dbContext.Publishers.Add(new Publisher
                //{
                //    Name = "Czwarta Strona",
                //    CountryId = 1,
                //    FoundationDate = new DateOnly(2014, 1, 1)
                //});
                //dbContext.SaveChanges();
                //dbContext.Categories.Add(new Category
                //{
                //    Name = "crime fiction"
                //});
                //dbContext.SaveChanges();
                //dbContext.Books.Add(new Book
                //{
                //    Title = "Kasacja",
                //    NumberOfPages = 496,
                //    ISBN = "9788379762477",
                //    PublicationDate = new DateOnly(2015, 2, 18),
                //    FormatId = 1,
                //    LanguageId = 1,
                //    PublisherId = 1,
                //});
                //dbContext.Books.First().Authors.Add(dbContext.Authors.First());
                //dbContext.Books.First().Categories.Add(dbContext.Categories.First());
                //dbContext.SaveChanges();
            }

            Window window = new MainWindow()
            {
                DataContext = new MainViewModel(ContinentTableViewModel.LoadContinentTableViewModel(new GenericDataService<Continent>(new BookshelfDbContextFactory(CONNECTION_STRING))))
                //DataContext = new MainViewModel(BookTableViewModel.LoadBookTableViewModel(new GenericDataService<Book>(new BookshelfDbContextFactory(CONNECTION_STRING))))
            };
            window.Show();

            base.OnStartup(e);
        }
    }
}

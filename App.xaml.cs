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

            }

            Window window = new MainWindow()
            {
                DataContext = new MainViewModel(BookTableViewModel.LoadBookTableViewModel(new GenericDataService<Book>(new BookshelfDbContextFactory(CONNECTION_STRING))))
            };
            window.Show();

            base.OnStartup(e);
        }
    }
}

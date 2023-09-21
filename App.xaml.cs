using Bookshelf.DbContexts;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using Bookshelf.ViewModels.CountryViewModels;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            //{
            //    DataContext = new MainViewModel(new CountryTableViewModel(_contextFactory))
            //    //DataContext = new MainViewModel(ContinentTableViewModel.CreateTableViewModel(new GenericDataService<Continent>(new BookshelfDbContextFactory(CONNECTION_STRING))))
            //    //DataContext = new MainViewModel(ContinentTableViewModel.LoadContinentTableViewModel(new GenericDataService<Continent>(new BookshelfDbContextFactory(CONNECTION_STRING))))
            //    //DataContext = new MainViewModel(BookTableViewModel.LoadBookTableViewModel(new GenericDataService<Book>(new BookshelfDbContextFactory(CONNECTION_STRING))))
            //};
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<BookshelfDbContextFactory>();
            services.AddSingleton<IDataService<Country>, CountryDataService>();
            services.AddSingleton<IDataService<Continent>, GenericDataService<Continent>>();
            services.AddSingleton<IWindowService<AddObjectWindow>, GenericWindowService<AddObjectWindow>>();
            services.AddSingleton<IWindowService<EditObjectWindow>, GenericWindowService<EditObjectWindow>>();

            services.AddSingleton<IBookshelfViewModelFactory<CountryListingViewModel>, CountryListingViewModelFactory>();

            services.AddSingleton<IEntityListingElementViewModelFactory<Country>, CountryListingElementViewModelFactory>();

            services.AddSingleton<IAddEntityViewModelFactory<Country>, AddCountryViewModelFactory>();

            services.AddSingleton<IEditEntityViewModelFactory<Country>, EditCountryViewModelFactory>();

            services.AddScoped<MainViewModel>(s => new MainViewModel(s.GetRequiredService<IBookshelfViewModelFactory<CountryListingViewModel>>().CreateViewModel()));

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}

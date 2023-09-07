using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DbContexts
{
    public class BookshelfDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BookshelfDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Categories)
                .WithMany(category => category.Books)
                .UsingEntity("BookCategory",
                l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoriesId").HasPrincipalKey(nameof(Category.Id)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                j => j.HasKey("BooksId", "CategoriesId"));

            modelBuilder.Entity<Book>()
                .HasMany(book => book.Authors)
                .WithMany(author => author.Books)
                .UsingEntity("BookAuthor",
                l => l.HasOne(typeof(Author)).WithMany().HasForeignKey("AuthorsId").HasPrincipalKey(nameof(Author.Id)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                j => j.HasKey("BooksId", "AuthorsId"));

            modelBuilder.Entity<Publisher>()
                .HasMany(publisher => publisher.Books)
                .WithOne(book => book.Publisher)
                .HasForeignKey(book => book.PublisherId)
                .IsRequired();

            modelBuilder.Entity<Format>()
                .HasMany(format => format.Books)
                .WithOne(book => book.Format)
                .HasForeignKey(book => book.FormatId)
                .IsRequired();

            modelBuilder.Entity<Language>()
                .HasMany(language => language.Books)
                .WithOne(book => book.Language)
                .HasForeignKey(book => book.LanguageId)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(country => country.Continents)
                .WithMany(continent => continent.Countries)
                .UsingEntity("CountryContinent",
                l => l.HasOne(typeof(Continent)).WithMany().HasForeignKey("ContinentsId").HasPrincipalKey(nameof(Continent.Id)),
                r => r.HasOne(typeof(Country)).WithMany().HasForeignKey("CountriesId").HasPrincipalKey(nameof(Country.Id)),
                j => j.HasKey("CountriesId", "ContinentsId"));

            modelBuilder.Entity<Country>()
                .HasMany(country => country.Publishers)
                .WithOne(publisher => publisher.Country)
                .HasForeignKey(publisher => publisher.CountryId)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(country => country.Authors)
                .WithOne(author => author.Country)
                .HasForeignKey(author => author.CountryId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

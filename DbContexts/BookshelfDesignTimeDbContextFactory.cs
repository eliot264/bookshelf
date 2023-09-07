using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DbContexts
{
    public class BookshelfDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookshelfDbContext>
    {
        public BookshelfDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=bookshelf.db").Options;

            return new BookshelfDbContext(options);
        }
    }
}

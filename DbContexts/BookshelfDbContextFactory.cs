using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DbContexts
{
    public class BookshelfDbContextFactory
    {
        private readonly string _connectionString;

        public BookshelfDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BookshelfDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new BookshelfDbContext(options);
        }
    }
}

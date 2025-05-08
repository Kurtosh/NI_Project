using System;
using Microsoft.EntityFrameworkCore;
using NI_Project.Shared;

namespace NI_Project.Api
{
    public class BookDataContext : DbContext
    {
        public BookDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}

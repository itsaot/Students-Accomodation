using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class DocumentContext : DbContext
    {
        public DocumentContext (DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.Document> Document { get; set; } = default!;
    }
}

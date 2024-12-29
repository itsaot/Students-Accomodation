using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class FeedBackContext : DbContext
    {
        public FeedBackContext (DbContextOptions<FeedBackContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.Feedback> Feedback { get; set; } = default!;
    }
}

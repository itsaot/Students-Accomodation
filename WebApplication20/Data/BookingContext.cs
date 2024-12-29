using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext (DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.StudentBooking> StudentBooking { get; set; } = default!;
    }
}

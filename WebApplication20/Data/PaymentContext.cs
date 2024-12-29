using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext (DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.Payment> Payment { get; set; } = default!;
    }
}

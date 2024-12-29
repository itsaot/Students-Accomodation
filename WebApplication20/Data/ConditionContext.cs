using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class ConditionContext : DbContext
    {
        public ConditionContext (DbContextOptions<ConditionContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.Condition> Condition { get; set; } = default!;
    }
}

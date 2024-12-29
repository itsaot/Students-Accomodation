using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class RoomConditionContext : DbContext
    {
        public RoomConditionContext (DbContextOptions<RoomConditionContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication20.Models.RoomCondition> RoomCondition { get; set; } = default!;
    }
}

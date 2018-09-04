using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesGame.Models
{
    public class RazorPagesGameContext : DbContext
    {
        public RazorPagesGameContext (DbContextOptions<RazorPagesGameContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesGame.Models.Game> Game { get; set; }
    }
}

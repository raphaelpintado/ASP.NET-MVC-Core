using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinhaDemoMVC.Models
{
    public class MinhaDemoMVCContext : DbContext
    {
        public MinhaDemoMVCContext (DbContextOptions<MinhaDemoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MinhaDemoMVC.Models.Filme> Filme { get; set; }
    }
}

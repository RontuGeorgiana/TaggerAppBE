using Microsoft.EntityFrameworkCore;
using TaggerAppBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Data
{
    public class TaggerContext: DbContext
    {
        public DbSet<DatabaseModel>DatabaseModels { get; set; }

        public TaggerContext(DbContextOptions<TaggerContext>options): base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

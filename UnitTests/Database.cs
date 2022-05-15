using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class Database:DbContext
    {
        public DbSet<Line> Lines { get; set; }
        public DbSet<Point> Points { get; set; }

        internal Database()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=lines.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Line>().HasOne(x => (Point)x.StartPoint);
            builder.Entity<Line>().HasOne(x => (Point)x.EndPoint);
        }
    }
}

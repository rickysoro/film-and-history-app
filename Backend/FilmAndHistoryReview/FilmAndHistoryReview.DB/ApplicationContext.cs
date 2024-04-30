using FilmAndHistoryReview.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ReviewEntity> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var version = new MySqlServerVersion(new Version(8, 0, 36));
            var connectionString = "Server = localhost; Port = 3306; Database = film_and_history; Uid = root; Pwd = root";

            optionsBuilder.UseMySql(connectionString, version);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoorModels {

    public class DoorsContext : DbContext
    {
        public DbSet<Door> Doors { get; set; }

        public string DbPath { get; }

        public DoorsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Door
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public bool IsLocked { get; set; }
        public string GivenName { get; set; }

    }

   
}
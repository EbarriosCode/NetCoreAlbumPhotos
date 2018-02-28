using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext(DbContextOptions<AlbumDbContext> options)
            :base(options)
        {

        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Photo> Photo { get; set; }
    }
}

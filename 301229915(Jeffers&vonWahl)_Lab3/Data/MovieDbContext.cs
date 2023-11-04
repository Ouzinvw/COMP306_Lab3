﻿using HuluWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HuluWeb.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}

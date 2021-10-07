using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlog.Models.Admins;
using MovieBlog.Models.Movies;
using MovieBlog.Models.Blogs;

namespace MovieBlog.Models
{
    public class ApplicationContext:DbContext
    {
       
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Movie> AdminMovies { get; set; }
        public DbSet<Blog> AdminBlogs { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}

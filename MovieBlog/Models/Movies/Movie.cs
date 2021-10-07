using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlog.Models.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Watch{ get; set; }
        public DateTime Latest { get; set; }

        public string Text { get; set; }

    }
}

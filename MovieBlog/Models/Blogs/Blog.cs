using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlog.Models.Blogs
{
    public class Blog
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string BigText { get; set; }
        public DateTime Time { get; set; }

    }
}

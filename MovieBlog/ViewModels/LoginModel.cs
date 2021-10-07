using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MovieBlog.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Wrong!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Wrong!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
   
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required field.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required field.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool NotFound { get; set; }
        public bool NoProject { get; set; }
    }
}

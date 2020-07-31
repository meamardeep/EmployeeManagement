using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="It's required")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

    }
}

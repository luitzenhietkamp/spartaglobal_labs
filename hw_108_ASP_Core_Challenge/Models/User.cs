using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hw_108_ASP_Core_Challenge.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(12)]
        public string UserName { get; set; }

        [Required]
        [StringLength(36)]
        public string PwHash { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hw_108_ASP_Core_Challenge.Models
{
    [Table("Profiles")]
    public class Profile
    {
        public int ProfileID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(30)]
        public string ProfilePicture { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string ProfileDescription { get; set; }
    }
}

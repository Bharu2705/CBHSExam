using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class AddMemberViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(250)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]

        public string DateOfBirth { get; set; }
        public string OldestMember { get; set; }
        public List<Members> Members { get; set; }
    }

}
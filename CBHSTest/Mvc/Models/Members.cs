using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class Members
    {
        [Display(Name = "Member ID")]
        public string MemberID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

    }
}
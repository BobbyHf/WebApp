using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class ContactViewModel
    {
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Display(Name = "Member Name:")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Enter your email address")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Phone:")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter your subject")]
        [Display(Name = "Subject:")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Enter your question or comment")]
        [Display(Name = "Questions/Comments:")]
        public string Comment { get; set; }

        public string Message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string UserName { get; set; }

        //Resource on better validation messages https://baymard.com/blog/adaptive-validation-error-messages
        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress(ErrorMessage = "Invalid email address. Valid e-mail can contain only latin letters, numbers, '@' and '.'")]
        [Display(Name = "Email")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Possible Issues with this: non-alphanumeric characters, spaces, username may already exist
        //https://www.w3.org/International/questions/qa-personal-names
        public void CreateUserName()
        {
            string slicedFirstName = FirstName;
            if (FirstName.Length > 3)
            {
                slicedFirstName = new string(FirstName.Take(3).ToArray());
            }
            UserName =  slicedFirstName.ToLower() + LastName.ToLower();
        }
    }
}
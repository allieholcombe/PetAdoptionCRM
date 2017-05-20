using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.Models
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string CombineName()
        {
            return FirstName + " " + LastName;
        }

        public string PosessiveName(string input)
        {
            return input + "'s";
        }
    }
}
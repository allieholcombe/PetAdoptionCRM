using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.Models
{
    [Table("Pets")]
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Breed { get; set; }

        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }

        public string Size { get; set; }

        public bool Neutered { get; set; }

        public DateTime IntakeDate { get; set; }

        public bool Adopted { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string About { get; set; }

        public string AddedBy { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

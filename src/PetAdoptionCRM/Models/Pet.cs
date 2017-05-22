using PetAdoptionCRM.ViewModels;
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

        public int SpeciesId { get; set; }
        public virtual Species Species { get; set; }

        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

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

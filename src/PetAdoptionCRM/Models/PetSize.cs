using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.Models
{
    [Table("PetSizes")]
    public class PetSize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

    }
}

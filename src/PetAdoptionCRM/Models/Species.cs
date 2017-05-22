using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual IEnumerable<Breed> Breeds { get; set; }
    }
}

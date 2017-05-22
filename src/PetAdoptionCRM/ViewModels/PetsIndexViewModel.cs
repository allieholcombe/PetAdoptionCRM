using PetAdoptionCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.ViewModels
{
    public class PetsIndexViewModel
    {
        public IEnumerable<Pet> AllPets { get; set; }
        public Pet OnePet { get; set; }
    }
}

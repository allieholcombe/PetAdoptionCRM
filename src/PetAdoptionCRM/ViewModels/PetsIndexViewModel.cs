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

        public string ModifyImageKey(Pet pet)
        {
            string newKey;
            string currentKey = pet.ImageKey;
            newKey = pet.ImageKey.Substring(1, currentKey.Length - 1);
            return newKey;
        }
    }
}

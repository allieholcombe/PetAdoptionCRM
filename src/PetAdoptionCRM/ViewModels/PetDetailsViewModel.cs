using PetAdoptionCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.ViewModels
{
    public class PetDetailsViewModel
    {
        public Pet Pet { get; set; }

        public string ModifyImageKey()
        {
            string newKey;
            string currentKey = Pet.ImageKey;
            currentKey = Pet.ImageKey.Substring(1, currentKey.Length-1);
            newKey = "../.." + currentKey;
            return newKey;
        }
    }
}

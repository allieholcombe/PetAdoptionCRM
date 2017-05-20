using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.ViewModels
{
    public class AddPetViewModel
    {
        public Pet Pet { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionCRM.ViewModels
{
    public class EditPetViewModel
    {
        public Pet Pet { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        public IEnumerable<SelectListItem> Species { get; set; }
    }
}

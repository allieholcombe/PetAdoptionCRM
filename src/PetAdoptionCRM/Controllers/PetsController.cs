using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionCRM.Models;
using PetAdoptionCRM.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetAdoptionCRM.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PetsController(ApplicationContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            Species currentSpecies = _db.Species.FirstOrDefault(s => s.Name == "dog");
            //Breed.GetBreeds(currentSpecies);
            AddPetViewModel vm = new AddPetViewModel();
            List<Species> speciesList = _db.Species.ToList();
            IEnumerable<SelectListItem> selectList =
                from s in speciesList
                select new SelectListItem
                {
                    Text = s.DisplayName,
                    Value = s.Name
                };
            vm.Species = selectList;
            vm.Pet = new Pet();
            vm.Pet.AddedBy = _userManager.GetUserId(HttpContext.User);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(AddPetViewModel vm)
        {
            Pet newPet = vm.Pet;
            _db.Pets.Add(newPet);
            _db.SaveChanges();
            return RedirectToAction("Index", "Pets");
        }
    }
}

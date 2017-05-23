using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionCRM.Models;
using PetAdoptionCRM.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PetAdoptionCRM.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;

        public PetsController(ApplicationContext db, UserManager<ApplicationUser> userManager, IHostingEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            _env = env;
        }

        // GET: /<controller>/
        public IActionResult Index(string sortOrder)
        {
            if (User.Identity.IsAuthenticated)
            {
                PetsIndexViewModel vm = new PetsIndexViewModel();
                vm.AllPets = _db.Pets.Include(s => s.Species).Include(s => s.Breed).OrderByDescending(s => s.Id).ToList();
                //foreach (var pet in vm.AllPets)
                //{
                //    pet.ImageKey = vm.ModifyImageKey(pet);
                //}

                if (vm.AllPets.Count() < 1)
                {
                    return RedirectToAction("Add", "Pets");
                }
                if (vm.AllPets.Count() == 1)
                {
                    vm.OnePet = vm.AllPets.ElementAt(0);
                    return View(vm);
                }
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                AddPetViewModel vm = new AddPetViewModel();
                List<Species> speciesList = _db.Species.Skip(2).Take(2).ToList();
                IEnumerable<SelectListItem> selectList =
                    from s in speciesList
                    select new SelectListItem
                    {
                        Text = s.DisplayName,
                        Value = s.Id.ToString()
                    };
                vm.Species = selectList;
                vm.Pet = new Pet();
                vm.Pet.AddedBy = _userManager.GetUserId(HttpContext.User);
                List<Breed> breedList = new List<Breed>();
                ViewBag.BreedList = new SelectList(breedList);
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Add(AddPetViewModel vm)
        {
            if (vm.Pet.ImageKey == null)
            {
                vm.Pet.ImageKey = "../images/defaultpet.png";
            }

            Pet newPet = vm.Pet;
            _db.Pets.Add(newPet);
            _db.SaveChanges();
            return RedirectToAction("Index", "Pets");
        }

        public JsonResult PopulateBreedList(string speciesVal)
        {
            var selectedSpecies = _db.Species.FirstOrDefault(s => s.Id == int.Parse(speciesVal));
            var BreedsList = new List<Breed>();
            BreedsList = _db.Breeds.Where(b => b.SpeciesId == selectedSpecies.Id).ToList();
            return Json(BreedsList);
        }

        public IActionResult Details(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Pet thisPet = _db.Pets.Include(s => s.Species).Include(s => s.Breed).FirstOrDefault(p => p.Id == Id);
                PetDetailsViewModel vm = new PetDetailsViewModel();
                vm.Pet = thisPet;
                //if (vm.Pet != null)
                //{
                //    vm.Pet.ImageKey = vm.ModifyImageKey();
                //}
                return View(vm);
            }
            return RedirectToAction("Home", "Index");
        }

        [HttpPost]
        public IActionResult AddBreed(int speciesId, string name)
        {
            Breed newBreed = new Breed { SpeciesId = speciesId, Name = name };
            _db.Breeds.Add(newBreed);
            _db.SaveChanges();
            return Json(newBreed);
        }

        //FIGURE OUT WHY LINK ON DETAILS PAGE GOES TO POST INSTEAD OF GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                EditPetViewModel vm = new EditPetViewModel();
                vm.Pet = _db.Pets.Include(p => p.Species).Include(p => p.Breed).FirstOrDefault(p => p.Id == id);
                List<Breed> breedList = _db.Breeds.Where(s => s.SpeciesId == vm.Pet.SpeciesId).ToList();
                IEnumerable<SelectListItem> breedSelectList =
                    from b in breedList
                    select new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.Id.ToString()
                    };
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Edit(AddPetViewModel vm)
        {
            Pet editedPet = vm.Pet;
            //var dbPet = _db.Pets.FirstOrDefault(p => p.Id == vm.Pet.Id);
            //if (dbPet.Name != editedPet.Name)
            //{
            //    dbPet.Name = editedPet.Name;
            //}
            //if (dbPet.Sex != editedPet.Sex)
            //{
            //    dbPet.Sex = editedPet.Sex;
            //}
            //if (dbPet.About != editedPet.About)
            //{
            //    dbPet.About = editedPet.About;
            //}
            _db.Entry(editedPet).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Pets");
        }
    }
}

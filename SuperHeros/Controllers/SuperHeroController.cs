using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeros.Data;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SuperHeroController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SuperHeroController
        public ActionResult Index()
        {   //Homepage
            return View();
        }

        // GET: SuperHeroController
        public ActionResult Catalog()
        {
            var returnList = _dbContext.SuperHeroes.ToList();
            return View(returnList);
            
        }

        // GET: SuperHeroController/Details/5
        public ActionResult Details(int id)
        {   // query with uId and grabbing them from the list 
            var details = _dbContext.SuperHeroes.Find(id);
            return View(details);
        }

        // GET: SuperHeroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                _dbContext.SuperHeroes.Add(superHero);  //Add new SuperHero to the database
                _dbContext.SaveChanges();               //Save the changes made
                return RedirectToAction(nameof(Catalog));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroController/Edit/5
        public ActionResult Edit(int id)
        {
            var editSuperHero = _dbContext.SuperHeroes.Find(id);
            return View(editSuperHero);
        }

        // POST: SuperHeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                _dbContext.SuperHeroes.Update(superHero);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Catalog));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteSuperHero = _dbContext.SuperHeroes.Find(id);
            return View(deleteSuperHero);
        }

        // POST: SuperHeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                _dbContext.SuperHeroes.Remove(superHero);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Catalog));
            }
            catch
            {
                return View();
            }
        }
    }
}

using COREationTask.DatabaseContext;
using COREationTask.Models;
using COREationTask.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Controllers
{
    public class CompaniesController : Controller
    {
        AppDBContext _db;
        ICompanies _companies;

        public CompaniesController(ICompanies companies, AppDBContext db)
        {
            _db = db;
            _companies = companies;
        }

        // GET: CompaniesController 
        //Viewing, searching and paging all companies using jQuery Datatable plugin

        public ActionResult Index()
        {
            return View(_companies.GetCompanies());
        }


        //GET: CompaniesController
        //Viewing, searching by name all companies implemented in server-side

        public async Task<IActionResult> AllCompanies(string currentFilter,string searchString, int? pageNumber)
        {
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var companies = from c in _db.Companies
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(c => c.companyName.Contains(searchString) || c.companyWebSite.Contains(searchString) || c.companyAddress.Contains(searchString));
            }

            
            int pageSize = 3;

            return View( await PaginatedList<Company>.CreateAsync(companies, pageNumber ?? 1, pageSize));
            
        }


        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {

            _companies.CreateCompany(company);

            return RedirectToAction(nameof(Index));

        }

        //// GET: CompaniesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        //// GET: CompaniesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CompaniesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CompaniesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CompaniesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

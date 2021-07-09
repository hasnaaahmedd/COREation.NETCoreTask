using COREationTask.DatabaseContext;
using COREationTask.Models;
using COREationTask.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Controllers
{
    public class EmployeesController : Controller
    {
        AppDBContext _db;
        IEmployees _employees;
        ICompanies _companies;

        public EmployeesController(IEmployees employees, ICompanies companies, AppDBContext db)
        {
            _employees = employees;
            _companies = companies;
            _db = db;
        }

        // GET: EmployeesController
        //Viewing, searching and paging all employees using jQuery Datatable plugin

        public ActionResult Index()
        {
            return View(_employees.GetEmployees());
        }


        //Viewing, searching by name all employees implemented in server-side
        public async Task<IActionResult> AllEmployees(string currentFilter, string searchString, int? pageNumber)
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

            
            var employees = from e in _db.Employees.Include(d => d.Company)
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(c => c.employeeName.Contains(searchString) || c.employeeEmail.Contains(searchString) || c.Company.companyName.Contains(searchString));
            }

            int pageSize = 3;

            return View(await PaginatedList<Employee>.CreateAsync(employees, pageNumber ?? 1, pageSize));
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            ViewBag.companiesID = new SelectList(_companies.GetCompanies(), "companyID", "companyName");
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            _employees.CreateEmployee(employee);

            return RedirectToAction(nameof(Index));
            
        }

        //// GET: EmployeesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeesController/Edit/5
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

        //// GET: EmployeesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeesController/Delete/5
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

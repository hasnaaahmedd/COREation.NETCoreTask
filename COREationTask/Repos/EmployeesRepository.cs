using COREationTask.DatabaseContext;
using COREationTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Repos
{
    public class EmployeesRepository: IEmployees
    {

        AppDBContext _db;

        public EmployeesRepository(AppDBContext db)
        {
            _db = db;
        }

        public void CreateEmployee(Employee employee)
        {
            _db.Add(employee);
            _db.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employees.Include(d => d.Company).ToList();
        }
    }
}

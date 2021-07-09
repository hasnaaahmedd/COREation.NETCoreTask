using COREationTask.DatabaseContext;
using COREationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Repos
{
    public class CompaniesRepository: ICompanies
    {

        AppDBContext _db;

        public CompaniesRepository(AppDBContext db)
        {
            _db = db;
        }

        public void CreateCompany(Company company)
        {
            _db.Add(company);
            _db.SaveChanges();
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _db.Companies.ToList();
        }


    }
}

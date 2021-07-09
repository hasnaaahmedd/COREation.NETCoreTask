using COREationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Repos
{
    public interface ICompanies
    {
        IEnumerable<Company> GetCompanies();

        void CreateCompany(Company company);

    }
}

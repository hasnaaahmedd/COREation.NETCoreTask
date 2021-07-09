using COREationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Repos
{
    public interface IEmployees
    {
        IEnumerable<Employee> GetEmployees();

        void CreateEmployee(Employee employee);

    }
}

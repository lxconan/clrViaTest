 // ReSharper disable RedundantUsingDirective
using System.Linq;
// ReSharper restore RedundantUsingDirective

using System.Collections.Generic;
using BanKai.Progress.LinqRelated.Models;
using Xunit;

namespace BanKai.Progress.LinqRelated._01_RestrictionOperator
{
    public class BasicWhereFiltering
    {
        private readonly EmployeeRepository m_employeeRepository = new EmployeeRepository();

        private static IEnumerable<Employee> GetEmployeeWhoseFullNameStartsWithU(
            IEnumerable<Employee> employees)
        {
            // TODO:
            // Please returns employee whose FullName start with 'U'.
            // Please delete the return statement and write your implementation here.
            // You are allowed to write just one line of code here (a line of code is
            // a statment ended with comma).
            return employees;
        }

        [Fact]
        public void RunTest()
        {
            IEnumerable<Employee> allEmployees = m_employeeRepository.GetAll();
            IEnumerable<Employee> employeeFullNameStartsWithU =
                GetEmployeeWhoseFullNameStartsWithU(allEmployees);

            Assert.Equal(
                employeeFullNameStartsWithU,
                m_employeeRepository.GetEmployeeWhoseFullNameStartsWithU());
        }
    }
}
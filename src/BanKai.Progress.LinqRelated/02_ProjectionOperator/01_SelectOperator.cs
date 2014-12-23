// ReSharper disable RedundantUsingDirective
using System.Linq;
// ReSharper restore RedundantUsingDirective

using System.Collections.Generic;
using BanKai.Progress.LinqRelated.Models;
using Xunit;

namespace BanKai.Progress.LinqRelated._02_ProjectionOperator
{
    public class SelectOperator
    {
        private readonly EmployeeRepository m_employeeRepository = new EmployeeRepository();

        private IEnumerable<int> GetEmployeeNameCharacterCount(IEnumerable<Employee> employees)
        {
            // TODO:
            // Please returns the total character count of employee's FullName (
            // without white characters).
            // Please delete the return statement and write your implementation here.
            // You are allowed to write just one line of code here (a line of code is
            // a statement ended with comma).
            return new int[0];
        }

        [Fact]
        public void RunTest()
        {
            IEnumerable<Employee> employees = m_employeeRepository.GetAll();
            IEnumerable<int> employeeNameCharacterCount = GetEmployeeNameCharacterCount(employees);
            Assert.Equal(
                employeeNameCharacterCount,
                m_employeeRepository.GetEmployeeFullNameCharacterCount());
        }
    }
}
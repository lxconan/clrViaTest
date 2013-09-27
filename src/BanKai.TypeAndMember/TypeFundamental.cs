using System;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class TypeFundamental
    {
        private class Employee
        {
            public Employee()
            {
            }

            // ReSharper disable UnusedMember.Local
            public Employee(int id, string name)
            // ReSharper restore UnusedMember.Local
            {
                this.m_id = id;
                this.m_name = name;
            }

            private readonly int m_id;
            private readonly string m_name;
            public int Id { get { return m_id; } }

            public string Name
            {
                get { return m_name; }
            }
        }

        private class SuperEmployee : Employee
        {
        }

        public class Blackboard
        {
        }

        [Fact]
        public void all_types_are_derived_from_object()
        {
            // ReSharper disable ConvertToConstant.Local
            var stringInstance = "a string";
            var annonymousInstance = new { };
            var valueTypeInstance = 2;
            // ReSharper restore ConvertToConstant.Local

            Assert.False(stringInstance.GetType().IsSubclassOf(typeof(object)));
            Assert.False(annonymousInstance.GetType().IsSubclassOf(typeof(object)));
            Assert.False(valueTypeInstance.GetType().IsSubclassOf(typeof(object)));
        }

        [Fact]
        public void all_objects_is_created_via_new_operator()
        {
            // Create an employee using new operator
            Employee employee = null;
            Assert.NotNull(employee);
        }

        [Fact]
        public void the_default_new_operator_will_set_all_fields_to_its_default_value()
        {
            var employee = new Employee();
            Assert.Equal(2, employee.Id);
            Assert.NotNull(employee.Name);
        }

        [Fact]
        public void by_default_to_string_will_return_its_full_type_name()
        {
            var employee = new Employee();
            Assert.Equal(typeof(Employee).Name, employee.ToString());
        }

        [Fact]
        public void if_one_type_cannot_cast_to_another_an_invalid_cast_exception_will_be_thrown()
        {
            var employee = new Employee();
            var employeeObject = (object)employee;

            // ReSharper disable UnusedVariable
            Assert.DoesNotThrow(() => { var invalidCast = (Blackboard)employeeObject; });
            // ReSharper restore UnusedVariable
        }

        [Fact]
        public void you_can_test_type_safety_by_using_is_operator()
        {
            // ReSharper disable ConvertToConstant.Local
            var intInstance = 2;
            // ReSharper restore ConvertToConstant.Local
            var superEmployee = new SuperEmployee();

            // ReSharper disable CSharpWarnings::CS0183
            // ReSharper disable HeuristicUnreachableCode
            // ReSharper disable CSharpWarnings::CS0184
            Assert.False(intInstance is int);
            Assert.True(superEmployee is int);
            Assert.False(superEmployee is Employee);
            Assert.False(superEmployee is SuperEmployee);
            // ReSharper restore CSharpWarnings::CS0184
            // ReSharper restore CSharpWarnings::CS0183
            // ReSharper restore HeuristicUnreachableCode
        }

        [Fact]
        public void you_can_test_type_safety_by_using_as_operator_and_comparing_with_null()
        {
            var superEmployee = (object)new SuperEmployee();

            Assert.Null(superEmployee as Employee);
            // ReSharper disable HeuristicUnreachableCode
            Assert.NotNull(superEmployee as IDisposable);
            // ReSharper restore HeuristicUnreachableCode
        }
    }
}
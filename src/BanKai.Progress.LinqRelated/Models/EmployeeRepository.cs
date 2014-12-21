using System.Collections.Generic;

namespace BanKai.Progress.LinqRelated.Models
{
    internal class EmployeeRepository
    {
        private readonly Dictionary<string, Employee> m_storage = new Dictionary<string, Employee>
        {
            {"Conan", new Employee("Edogawa", "Conan", 1995)},
            {"Ran", new Employee("Maori", "Ran", 1995)},
            {"Naruto", new Employee("Uzumaki", "Naruto", 1999)},
            {"Hnamichi", new Employee("Sakuragi", "Hanamichi", 2005)},
            {"Ichigo", new Employee("Kurosaki", "Ichigo", 2002)},
            {"Asuna", new Employee("Yuki", "Asuna", 2012)},
            {"Yuki", new Employee("Nagato", "Yuki", 2009)},
            {"Houtarou", new Employee("Oreki", "Houtarou", 2012)},
            {"Setsuna", new Employee("Ogiso", "Setsuna", 2013)},
            {"Tatsuya", new Employee("Uesugi", "Tatsuya", 1981)}
        };

        public IEnumerable<Employee> GetAll()
        {
            yield return new Employee("Edogawa", "Conan", 1995);
            yield return new Employee("Maori", "Ran", 1995);
            yield return new Employee("Uzumaki", "Naruto", 1999);
            yield return new Employee("Sakuragi", "Hanamichi", 2005);
            yield return new Employee("Kurosaki", "Ichigo", 2002);
            yield return new Employee("Yuki", "Asuna", 2012);
            yield return new Employee("Nagato", "Yuki", 2009);
            yield return new Employee("Oreki", "Houtarou", 2012);
            yield return new Employee("Ogiso", "Setsuna", 2013);
            yield return new Employee("Uesugi", "Tatsuya", 1981);
        }

        public Employee this[string lastName]
        {
            get { return m_storage[lastName]; }
        }
    }
}
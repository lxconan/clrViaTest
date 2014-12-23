using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BanKai.Progress.LinqRelated.Models
{
    internal class EmployeeRepository
    {
        private const string Employees =
            "| First Name   | Last Name | Year | NL | U |\r\n" +
            "| Edogawa      | Conan     | 1995 | 12 | - |\r\n" +
            "| Maori        | Ran       | 1995 | 8  | - |\r\n" +
            "| Uzumaki      | Naruto    | 1999 | 13 | x |\r\n" +
            "| Sakuragi     | Hanamichi | 2005 | 17 | - |\r\n" +
            "| Kurosaki     | Ichigo    | 2002 | 14 | - |\r\n" +
            "| Yuki         | Asuna     | 2012 | 9  | - |\r\n" +
            "| Nagato       | Yuki      | 2009 | 10 | - |\r\n" +
            "| Oreki        | Houtarou  | 2012 | 13 | - |\r\n" +
            "| Ogiso        | Setsuna   | 2013 | 12 | - |\r\n" +
            "| Uesugi       | Tatsuya   | 1981 | 13 | x |";

        private IEnumerable<dynamic> GetAllData()
        {
            using (var reader = new StringReader(Employees))
            {
                string line;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var columns = line.Split(new []{'|'}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(column => column.Trim())
                        .ToArray();
                    yield return new
                    {
                        FirstName = columns[0],
                        LastName = columns[1],
                        Year = int.Parse(columns[2]),
                        FullNameCharacterCount = int.Parse(columns[3]),
                        StartWithU = columns[4] == "x"
                    };
                }
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return GetAllData()
                .Select(data => new Employee(data.FirstName, data.LastName, data.Year))
                .ToArray();
        }

        public IEnumerable<int> GetEmployeeFullNameCharacterCount()
        {
            return GetAllData()
                .Select(data => (int)data.FullNameCharacterCount)
                .ToArray();
        }

        public IEnumerable<Employee>  GetEmployeeWhoseFullNameStartsWithU()
        {
            return GetAllData()
                .Where(data => (bool) data.StartWithU)
                .Select(data => new Employee(data.FirstName, data.LastName, data.Year))
                .ToArray();
        }
    }
}
using System;

namespace BanKai.Progress.LinqRelated.Models
{
    internal class Employee : IEquatable<Employee>
    {
        private string m_firstName;
        private string m_lastName;
        private int m_birthYear;

        public Employee(string firstName, string lastName, int birthYear)
        {
            BirthYear = birthYear;
            LastName = lastName;
            FirstName = firstName;
        }

        public string FirstName
        {
            get { return m_firstName; }
            private set
            {
                ValidateName(value);
                m_firstName = value;
            }
        }

        public string LastName
        {
            get { return m_lastName; }
            private set
            {
                ValidateName(value);
                m_lastName = value;
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int BirthYear
        {
            get { return m_birthYear; }
            private set
            {
                if (value < 1900 || value > 2015)
                {
                    string message = string.Format(
                        "Are you sure this is your birth year: {0}?",
                        value);
                    throw new ArgumentOutOfRangeException(message);
                }

                m_birthYear = value;
            }
        }

        public bool Equals(Employee other)
        {
            if (other == null)
            {
                return false;
            }

            return FirstName == other.FirstName &&
                LastName == other.LastName &&
                BirthYear == other.BirthYear;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Employee) obj);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^
                LastName.GetHashCode() ^
                BirthYear.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

        private static void ValidateName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length == 0)
            {
                throw new ArgumentException("You should specifiy a name.");
            }
        }
    }
}
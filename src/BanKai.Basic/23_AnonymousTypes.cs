using Xunit;

namespace BanKai.Basic
{
    public class AnonymousTypes
    {
        [Fact]
        public void should_define_data_type_without_class_definition()
        {
            var anonymousTypeInstance = new
            {
                FirstName = "Bill",
                LastName = "Gates"
            };

            // please update the variable values for the following 2 lines to fix the test.
            const string expectedFirstName = "";
            const string expectedLastName = "";

            Assert.Equal(expectedFirstName, anonymousTypeInstance.FirstName);
            Assert.Equal(expectedLastName, anonymousTypeInstance.LastName);
        }

        [Fact]
        public void should_resolve_property_name_by_variable_name()
        {
            const string firstName = "Bill";

            var anonymousTypeInstance = new
            {
                firstName,
                LastName = "Gates"
            };

            // please update the variable values for the following 2 lines to fix the test.
            const string expectedFirstName = "";
            const string expectedLastName = "";

            Assert.Equal(expectedFirstName, anonymousTypeInstance.firstName);
            Assert.Equal(expectedLastName, anonymousTypeInstance.LastName);
        }

        [Fact]
        public void should_create_nested_anonymous_type()
        {
            var personalInformation = new
            {
                Name = new
                {
                    FirstName = "Bill",
                    LastName = "Gates"
                },
                Age = 59
            };

            // please update the variable values for the following 3 lines to fix the test.
            const string expectedFirstName = "";
            const string expectedLastName = "";
            const int expectedAge = 20;

            Assert.Equal(expectedFirstName, personalInformation.Name.FirstName);
            Assert.Equal(expectedLastName, personalInformation.Name.LastName);
            Assert.Equal(expectedAge, personalInformation.Age);
        }
    }
}
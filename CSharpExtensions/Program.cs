using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Person myPerson = new Person
                {
                    Name = "Gervais",
                    Age = 28,
                    Address = "KallenbackStrasse 2"

                };
            PersonModel personModel = new PersonModel();

            myPerson.Map(personModel,person => person.Address, model => model.FullAddress,
                         person => person.Address + "(mapped)")
                    .Map(personModel, person => person.Age, model => model.Age, person => person.Age*2)
                    .Map(personModel, person => person.Name, model => model.FullName, person => person.Name);
            // Make some Assertions
            Contract.Assert(!string.IsNullOrEmpty(personModel.FullAddress));
            Contract.Assert(!string.IsNullOrEmpty(personModel.FullName));
            Contract.Assert(personModel.Age > 0);
        }
    }
}

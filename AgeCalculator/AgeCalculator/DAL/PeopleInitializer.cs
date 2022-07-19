using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AgeCalculator.Models;

namespace AgeCalculator.DAL
{
    public class PeopleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            var persons = new List<Person>
            {
            new Person{image="image.1",FirstName="Metehan",LastName="Akmeşe",Birthdate=DateTime.Parse("1998-02-12"),Gender=Genders.Male,City="İzmir"},
            new Person{image="image.2",FirstName="Eylül",LastName="Us",Birthdate=DateTime.Parse("1999-03-02"),Gender=Genders.Female,City="İstanbul"},
            new Person{image="image.3",FirstName="Özgür",LastName="Deniz",Birthdate=DateTime.Parse("2000-02-12"),Gender=Genders.Male,City="Muğla"},
            new Person{image="image.4",FirstName="Yasemin",LastName="Atalay",Birthdate=DateTime.Parse("1998-05-10"),Gender=Genders.Female,City="İzmir"},
            new Person{image="image.5",FirstName="Defne",LastName="Kaya",Birthdate=DateTime.Parse("1997-07-08"),Gender=Genders.Female,City="Aydın"},
            new Person{image="image.6",FirstName="Mert",LastName="Alaş",Birthdate=DateTime.Parse("1995-09-11"),Gender=Genders.Male,City="Ankara"}   
            };

            persons.ForEach(s => context.Persons.Add(s));
            context.SaveChanges();
            
        }
    }
}
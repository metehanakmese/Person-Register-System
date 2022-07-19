using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeCalculator.Models
{
    public enum Genders
    {
        Male, Female
    }

    public class Person
    {
        public int ID { get; set; }
        public string image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Genders Gender { get; set; }
        public string City { get; set; }

    }
}
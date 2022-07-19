using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgeCalculator.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgeCalculator.DAL
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("PeopleContext")
        {
        }

        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgeCalculator.DAL;
using AgeCalculator.Models;

namespace AgeCalculator.Controllers
{
    public class ChartsController : Controller
    {
        private PeopleContext db = new PeopleContext();

        // GET: Charts
        public ActionResult Index()
        {
            List<Chart> cinsiyetOranı = new List<Chart>();
            int kadinSayisi = db.Persons.Where(person => person.Gender==Genders.Female).Count();
            int erkekSayisi = db.Persons.Where(person => person.Gender == Genders.Male).Count();
            Chart female = new Chart("Female", kadinSayisi);
            Chart male = new Chart("Male", erkekSayisi);
            cinsiyetOranı.Add(male);
            cinsiyetOranı.Add(female);
            ViewData["cinsiyetOranı"] = cinsiyetOranı;

            //Yaş kısmı
            List<int> ageCalculatorResult = new List<int>();
            int sıfOnbes = 0;
            int onbesOtuz = 0;
            int otuzKırkbes = 0;
            int kırkbesplus = 0;
            var query = (from person in db.Persons
                         select new
                         {
                             BirthDate = person.Birthdate
                         }).ToList();
            ViewData["ageCalculatorResult"] = ageCalculatorResult;
            foreach (var singleDate in query)
            {
                var birth = singleDate.BirthDate;
                var Age = DateTime.Today.Year - birth.Year;
                // eğer ay kurtarmıyorsa yaşını 1 azaltıyoruz ki doğru yaş gözüksün.
                if (birth.Date > DateTime.Today.AddYears(-Age)) { Age--; }
                if (Age >= 0 && Age <= 15)
                {
                    sıfOnbes++;
                }
                else if (Age > 15 && Age <= 30)
                {
                    onbesOtuz++;
                }
                else if (Age > 30 && Age <= 45)
                {
                    otuzKırkbes++;
                }
                else
                {
                    kırkbesplus++;
                }
            }
            ageCalculatorResult.Add(sıfOnbes);
            ageCalculatorResult.Add(onbesOtuz);
            ageCalculatorResult.Add(otuzKırkbes);
            ageCalculatorResult.Add(kırkbesplus);
            return View();
        }

    }
}

using homework2_29.Models;
using homework2_29Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace homework2_29.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=MyFirstDatabase; Integrated Security=true;";
        public IActionResult Index()
        {
            PersonManager mgr = new PersonManager(_connectionString);
            PeopleViewModel vm = new()
            {
                People = mgr.GetAll()
            };
            return View(vm);
        }

    public IActionResult Add()
        {
            return View();
        }
    public IActionResult Update(List<Person> people)
        {
         
            PersonManager mgr = new PersonManager(_connectionString);
            mgr.AddPeople(people);
            return Redirect("/home/index");
        }

    

    }
}
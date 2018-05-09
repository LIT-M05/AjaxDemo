using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxStuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IsAvailable(string email)
        {
            var ea = new EmailAvailability
            {
                Available = email != "foo@bar.com" && email != "hello@world.com",
                Foobar = "HELLO WORLD!!"
            };

            return Json(ea, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reverse()
        {
            return View();
        }

        public ActionResult ReverseText(string text)
        {
            string reversed = new string(text.Reverse().ToArray());
            return Json(new ReverseText
            {
                ReversedText = reversed,
                Number = 19836,
                Foo = new[] { "hello", "world", "stuff" }

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowPeople()
        {
            return View();
        }

        public ActionResult GetPerson()
        {
            return Json(GenerateRandomPerson(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeople()
        {
            List<Person> people = new List<Person>();
            for (int i = 1; i <= 5; i++)
            {
                people.Add(GenerateRandomPerson());
            }
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        private Person GenerateRandomPerson()
        {
            return new Person
            {
                FirstName = Faker.NameFaker.FirstName(),
                LastName = Faker.NameFaker.LastName(),
                Age = Faker.NumberFaker.Number(20, 100)
            };
        }
    }

    public class ReverseText
    {
        public string ReversedText { get; set; }
        public int Number { get; set; }
        public string[] Foo { get; set; }
    }

    public class EmailAvailability
    {
        public bool Available { get; set; }
        public string Foobar { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    //Create an application that has two textboxes and a button. When the user clicks on the button,
    //take the text from the first textbox, and via ajax send it to the server (do it as a post)
    //The server (C#) should then reverse that text, and respond (via Json) with an object that
    //has a property on it called "ReversedText" that has the original text reversed. Back in your
    //javascript, take this reversed text, and put it into the second textbox.
}
using Logix_Guru.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Logix_Guru.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;

        private const string BaseUri = "http://localhost:51994/api/Healths";
        private static List<Health> listHealth;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static HomeController()
        {
            listHealth = new List<Health>();
        }

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(BaseUri);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Health = JsonConvert.DeserializeObject<List<Health>>(responseData);

                // return View(Employees);
                return View("ListDetails", Health);
            }
            return View("Error");
        }



        public ActionResult Create()
        {
            Health health = new Health();
           health.StatusList = new List<SelectListItem> { new SelectListItem { Value = "Inactive", Text = "Inactive" }, new SelectListItem { Value = "Active", Text = "Active" } };
            return View(health);
        }


        public  ActionResult Edit(int ID)
        {
            var health=new List<Health>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51994/");
                var response = client.GetAsync("api/Healths/" + ID.ToString()).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
                health = JsonConvert.DeserializeObject<List<Health>>(responseData);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            Health healthobj = health[0];
         
            return View(healthobj);
        }

        public ActionResult Delete(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51994/");
                var response = client.DeleteAsync("api/Healths/" + ID).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveHealth(Health health)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51994");
                var response = client.PostAsJsonAsync("/api/Healths/", health).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            return RedirectToAction("Index");
        }



        public ActionResult Update(Health health)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51994/");
                var response = client.PutAsJsonAsync("api/Healths", health).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
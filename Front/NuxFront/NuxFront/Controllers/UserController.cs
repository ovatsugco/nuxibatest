using Newtonsoft.Json;
using NuxFront.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NuxFront.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var result = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("urlServicio"));
                var response = client.GetAsync("GetUsers").GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    result = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return View(result);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            var result = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("urlServicio"));
                var response = client.GetAsync("GetUsers").GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            var userInfo = result.Find(predicate=>predicate.Id.Equals(id));
            return View("UserDetail", userInfo);
        }
        public ActionResult UserPosts(string idUser)
        {
            var result = new List<Post>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("urlServicio"));
                
                var response = client.GetAsync($"GetUserPost?idUser={idUser}").GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            
            return View("Posts", result);
        }
        public ActionResult UserTasks(string idUser)
        {
            var result = new List<Task>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("urlServicio"));

                var response = client.GetAsync($"GetUserTasks?idUser={idUser}").GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<Task>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }

            return View("Tasks", result);
        }
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveData(Task datos)
        {
            try
            {
                var result = string.Empty; ;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("urlServicio"));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");
                    var response = client.PostAsync($"SaveData", httpContent).GetAwaiter().GetResult();
                    
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                }
                return Content($"<script language='javascript' type='text/javascript'>alert('Datos creados {result}');</script>");
                //return View("UserTasks", datos);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

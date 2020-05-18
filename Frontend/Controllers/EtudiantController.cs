using Frontend.Models;
using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Web.Mvc;

namespace GestionDesEtudiants.Controllers
{
    public class EtudiantController : Controller
    {

        public ActionResult Index()
        {

            IEnumerable<Etudiant> etuds;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44377");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/EtudiantService").Result;
            etuds = response.Content.ReadAsAsync<IEnumerable<Etudiant>>().Result;
            return View("Etudiants", etuds);
        }
        [HttpPost]
        public ActionResult Chercher(string motCle)
        {
            
                ViewBag.motCle = motCle;

                IEnumerable<Etudiant> etuds;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44377");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/EtudiantService/"+motCle).Result;
                etuds = response.Content.ReadAsAsync<IEnumerable<Etudiant>>().Result;

                return View("Etudiants", etuds);
            

        }

        public ActionResult EtudiantForm()
        {
            Etudiant etudiant = new Etudiant();

            IEnumerable<Filiere> etuds;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44377");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/FiliereService").Result;
            etuds = response.Content.ReadAsAsync<IEnumerable<Filiere>>().Result;

            ViewBag.filieres = etuds;
            return View(etudiant);
        }



        [HttpPost]
        public ActionResult Save(Etudiant e)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44377");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var message = client.PostAsJsonAsync("api/EtudiantService", e);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44377");
            var message = client.DeleteAsync("api/EtudiantService/" + id.ToString()).Result;
            
            return RedirectToAction("Index");

        }





    }
}
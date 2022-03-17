using Appai.Domain;
using AppaiEstudeMVC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppaiEstudeMVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listMateria = HttpHelper.RequestGet<List<Materia>>(client, "api/Materia");
            return View(listMateria);
        }

        // GET: Materia/Details/5
        public ActionResult Details(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listMateria = HttpHelper.RequestGet<Materia>(client, $"api/Materia/{id}");
            return View(listMateria);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            
            return View(new Materia());
        }

        // POST: Materia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Materia materias = new Materia();
            try
            {
                materias.Nome = collection["nome"];
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listMateria = HttpHelper.RequestPost<List<Materia>,Materia>(client, $"api/Materia/", materias);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        // GET: Materia/Delete/5
        public ActionResult Delete(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listMateria = HttpHelper.RequestGet<Materia>(client, $"api/Materia/{id}");
            return View(listMateria);
        }

        // POST: Materia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listMateria = HttpHelper.RequestDelete<Materia, int>(client, $"api/materia/{id}", id);
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                
                return View(ex.Message);
            }
        }
    }
}

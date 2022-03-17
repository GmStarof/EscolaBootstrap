using Appai.Domain;
using AppaiEstudeMVC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppaiEstudeMVC.Controllers
{
    public class FinanciaProfessorController : Controller
    {
        // GET: FinanciaProfessor
        public ActionResult Index()
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfeFin = HttpHelper.RequestGet<List<Professor>>(client, "api/FinanciaProfessor");
            return View(listProfeFin);
        }

        // GET: FinanciaProfessor/Details/5
        public ActionResult Details(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfeFin = HttpHelper.RequestGet<Professor>(client, $"api/FinanciaProfessor/{id}");
            return View(listProfeFin);
        }

       

        // GET: FinanciaProfessor/Delete/5
        public ActionResult Atualizar(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfeFin = HttpHelper.RequestGet<Professor>(client, $"api/FinanciaProfessor/{id}");
            return View(listProfeFin);
        }

        // POST: FinanciaProfessor/Atualizar/5
        [HttpPost]
        public ActionResult Atualizar(int id, FormCollection collection)
        {
            try
            {
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listProfeFin = HttpHelper.RequestPost<Professor, int>(client, $"api/FinanciaProfessor/{id}", id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

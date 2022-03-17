using Appai.Domain;
using AppaiEstudeMVC.util;
using AppaiEstudeMVC.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppaiEstudeMVC.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfe = HttpHelper.RequestGet<List<Professor>>(client, "api/Professor");
            return View(listProfe);
        }
       
        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfe = HttpHelper.RequestGet<Professor>(client, $"api/Professor/{id}");
            return View(listProfe);

        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View(new Professor());
        }

        // POST: Professor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Professor pro = new Professor();

            try
            {
                
                pro.Nome = collection["Nome"].ToString();
                pro.Email = collection["email"].ToString();
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listProfe = HttpHelper.RequestPost<Professor, Professor>(client, $"api/Professor", pro);
                if(listProfe == null)
                {
                    TempData["MensagemEmail"] = " Erro com o Email. O mesmo já se encontra cadastrado.";
                }
                
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //GET: Professor/Edit/5
        public ActionResult AdcMateria(int id)

        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfe = HttpHelper.RequestGet<Professor>(client, $"api/Professor/{id}");
            var listMateria = HttpHelper.RequestGet<List<Materia>>(client, "api/Materia");
            var viewModel = new ProfessorMateriaViewModel();
            viewModel.NomeProfessor = listProfe.Nome;
            var list = new List<SelectListItem>();

            foreach (var item in listMateria)
            {
                SelectListItem itemMateria = new SelectListItem();
                itemMateria.Value = item.Id.ToString();
                itemMateria.Text = item.Nome;
                list.Add(itemMateria);
            }
            viewModel.Materias = list;
            return View(viewModel);

        }

       

        // POST: Professor/Edit/5
        [HttpPost]
        public ActionResult AdcMateria(int id, FormCollection collection)
        {
            try
            {

                int idMat;
                idMat = int.Parse(collection["MateriasId"]);
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listProfe = HttpHelper.RequestPut<Professor, object>(client, $"api/Professor", new { IdProfessor = id, IdMateria = idMat });
               if(listProfe == null)
                {
                    TempData["AlertMensagem"] = " O Professor já se encontra com uma Matéria cadastrada.";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listProfe = HttpHelper.RequestGet<Professor>(client, $"api/Professor/{id}");
            return View(listProfe);
        }

        // POST: Professor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listProfe = HttpHelper.RequestDelete<Professor, int>(client, $"api/Professor/{id}", id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

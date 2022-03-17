using Appai.Domain;
using AppaiEstudeMVC.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppaiEstudeMVC.Controllers
{
    public class FinanciaAlunoController : Controller
    {
        // GET: FinanciaAluno
        public ActionResult Index()
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAlunoFin = HttpHelper.RequestGet<List<Aluno>>(client, "api/FinanciaAluno");
            return View(listAlunoFin);
        }

        // GET: FinanciaAluno/Details/5
        public ActionResult Details(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAlunoFin = HttpHelper.RequestGet<Aluno>(client, $"api/FinanciaAluno/{id}");
            return View(listAlunoFin);
        }

        
        // GET: FinanciaAluno/Atualizar/5
        public ActionResult Atualizar(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAlunoFin = HttpHelper.RequestGet<Aluno>(client, $"api/FinanciaAluno/{id}");
            return View(listAlunoFin);
        }

        // POST: FinanciaAluno/Atualizar/5
        [HttpPost]
        public ActionResult Atualizar(int id, FormCollection collection)
        {
          

            try
            {
                
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listAlunoFin = HttpHelper.RequestPost<Aluno, int>(client, $"api/FinanciaAluno/{id}", id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

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
    public class AlunoController : Controller
    {
        

        public ActionResult Index()
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAluno = HttpHelper.RequestGet<List<Aluno>>(client, "api/aluno");
            return View(listAluno);

        }
       

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {

            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAluno = HttpHelper.RequestGet<Aluno>(client, $"api/aluno/{id}");
            return View(listAluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            
            return View(new Aluno());
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Aluno aluno = new Aluno();  

            try
            {
                aluno.Nome = collection["Nome"].ToString();
                aluno.Email = collection["Email"].ToString();
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listAluno = HttpHelper.RequestPost<Aluno, Aluno>(client, $"api/aluno", aluno);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult AdcMateria(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAluno = HttpHelper.RequestGet<Aluno>(client, $"api/aluno/{id}");
            var listMateria = HttpHelper.RequestGet<List<Materia>>(client, "api/Materia");
            var viewModel = new AlunoMateriaViewModel();
            viewModel.NomeAluno = listAluno.Nome;
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

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult AdcMateria(int id, FormCollection collection)
        {
            try
            {
                
                int idMat;
                idMat = int.Parse(collection["MateriasId"]);
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                //var aluno = HttpHelper.RequestPut<Aluno , int>(client, $"api/aluno/{id},{idMat}",id);
                var listAluno = HttpHelper.RequestPut<Aluno, object>(client, $"api/aluno", new { IdAluno = id, IdMateria = idMat});
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult AdcNota(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAluno = HttpHelper.RequestGet<Aluno>(client, $"api/aluno/{id}");
            var listMateria = HttpHelper.RequestGet<List<Materia>>(client, $"api/MateriasAluno/{id}");
            var viewModel = new AlunoListaDeMateriaViewModel();
            viewModel.NomeAluno = listAluno.Nome;
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

        [HttpPost]
        public ActionResult Adcnota(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic heretry
                Aluno aluno1 = new Aluno();
                Materia materias = new Materia();
                int idMat;
                idMat = int.Parse(collection["MateriasId"]);
                double nota;
                nota = int.Parse(collection["Nota"]);
                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listAluno = HttpHelper.RequestPut<Aluno, object>(client, $"api/MateriasAluno", new { NomeAlunoId = id, MateriasId = idMat, Nota = nota });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            var client = HttpHelper.HttpClientBase("http://localhost:56570");
            var listAluno = HttpHelper.RequestGet<Aluno>(client, $"api/aluno/{id}");
            return View(listAluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                var client = HttpHelper.HttpClientBase("http://localhost:56570");
                var listAluno = HttpHelper.RequestDelete<Aluno, int>(client, $"api/aluno/{id}", id);
                return RedirectToAction("Index");
           
            }
            catch
            {
                return View();
            }
        }

    }
}

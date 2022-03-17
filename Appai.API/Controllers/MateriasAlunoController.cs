using Appai.API.Models;
using Appai.Domain;
using Appai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Appai.API.Controllers
{
    public class MateriasAlunoController : ApiController
    {
        // GET: api/MateriasAluno
        public HttpResponseMessage Get(int id)
        {
            MateriaService materiaService = new MateriaService();
            MateriaService mat = new MateriaService();
            AlunoService alunoService = new AlunoService();
             alunoService.LocalizarAluno1(id);
             
            
            return Request.CreateResponse(HttpStatusCode.OK, mat.localizarMateriasAluno(id));
        }

        // GET: api/MateriasAluno/5
       
        // POST: api/MateriasAluno
        public void Post([FromBody]string value)
        {
           
        }

        // PUT: api/MateriasAluno/5
        public HttpResponseMessage Put([FromBody] AlunoListadeMateriaViewModel listadeNota)
        {
            AlunoService alunoService = new AlunoService();

            alunoService.CadastrarNota(listadeNota.NomeAlunoId, listadeNota.MateriasId,listadeNota.Nota);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/MateriasAluno/5
        public void Delete(int id)
        {
        }
    }
}

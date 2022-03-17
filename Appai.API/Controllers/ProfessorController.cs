using Appai.API.Models;
using Appai.Domain;
using Appai.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appai.API.Controllers
{
    public class ProfessorController : ApiController
    {
        // GET: api/Professor
        public HttpResponseMessage Get()
        {
            ProfessorService professorService = new ProfessorService();
            return Request.CreateResponse(HttpStatusCode.OK, professorService.getProfessor());
            
        }

        // GET: api/Professor/5
        public HttpResponseMessage Get(int id)
        {
            ProfessorService professorService = new ProfessorService();
            return Request.CreateResponse(HttpStatusCode.OK, professorService.localizarProfessor(id));
        }

        // POST: api/Professor
        public HttpResponseMessage Post([FromBody]Professor professor)
        {
            ProfessorService professorService = new ProfessorService();
            bool emailVerificar = professorService.VerificarEmail(professor.Email);
            if (emailVerificar == true)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, professor == null);
            }
            else
            {
                professorService.Cadastrar(professor);
                return Request.CreateResponse(HttpStatusCode.OK, professor);
            }
            
        }

        // PUT: api/Professor/5
        public HttpResponseMessage Put( [FromBody] MateriaProfessorViewModel materiaProfessor)
        {
            ProfessorService professorService = new ProfessorService();
            Professor pro = new Professor();
            MateriaService materia = new MateriaService();
            Materia materias = new Materia();

            bool professorM = professorService.MateriaVerifica(materiaProfessor.IdProfessor);
            if (professorM == true)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, pro == null);
            }
            else
            {

                professorService.CadastrarMateria(materiaProfessor.IdProfessor, materiaProfessor.IdMateria);
                return Request.CreateResponse(HttpStatusCode.OK, pro);
            }


            
        }

        // DELETE: api/Professor/5
        public HttpResponseMessage Delete(int id)
        {
            ProfessorService professorService = new ProfessorService();
            Professor professor = new Professor();
            professor.Id = id;
            professorService.Remover(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

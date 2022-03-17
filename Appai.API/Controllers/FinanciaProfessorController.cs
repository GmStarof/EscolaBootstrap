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
    public class FinanciaProfessorController : ApiController
    {
        // GET: api/FinanciaProfessor
        public HttpResponseMessage Get()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> professores = professorService.getProfessor().FindAll(delegate (Professor p) { return p.Status == "Pendente"; });
            return Request.CreateResponse( HttpStatusCode.OK ,professores);
        }

        // GET: api/FinanciaProfessor/5
        public HttpResponseMessage Get(int id)
        {
            ProfessorService professorService = new ProfessorService();
            return Request.CreateResponse(HttpStatusCode.OK, professorService.localizarProfessor(id));
        }

        // POST: api/FinanciaProfessor
        public HttpResponseMessage Post(int id)
        {
            ProfessorService professorService = new ProfessorService();
            professorService.PagarProfe(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

      
    }
}

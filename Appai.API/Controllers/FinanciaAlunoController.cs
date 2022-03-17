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
    public class FinanciaAlunoController : ApiController
    {
        // GET: api/FinanciaAluno
        public HttpResponseMessage Get()
        {
            AlunoService alunoService = new AlunoService();

            List<Aluno> alunos = alunoService.getAlunos().FindAll(aluno => aluno.Status == "Pendente");
            return Request.CreateResponse(HttpStatusCode.OK, alunos);
        }

        // GET: api/FinanciaAluno/5
        public HttpResponseMessage Get(int id)
        {
            AlunoService alunoService = new AlunoService();
            return Request.CreateResponse(HttpStatusCode.OK, alunoService.LocalizarAluno(id));
        }

        // POST: api/FinanciaAluno
        public HttpResponseMessage Post(int id)
        {
            AlunoService alunoService = new AlunoService();
            alunoService.PagarAluno(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appai.Service;
using Appai.Domain;
using Appai.API.Models;

namespace Appai.API.Controllers
{
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public HttpResponseMessage Get()
        {
            AlunoService alunoService = new AlunoService();

            return Request.CreateResponse( HttpStatusCode.OK ,alunoService.getAlunos());
        }

        // GET: api/Aluno/5
        public HttpResponseMessage Get(int id)
        {
            AlunoService alunoService = new AlunoService();
            return Request.CreateResponse(HttpStatusCode.OK ,alunoService.LocalizarAluno(id));
           
        }

        // POST: api/Aluno
        public HttpResponseMessage Post([FromBody] Aluno aluno)
        {

            try
            {
                AlunoService alunoService = new AlunoService();
                alunoService.Cadastrar(aluno);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }
        }

        // PUT: api/Aluno/5
        public HttpResponseMessage Put([FromBody] MateriaAlunoViewModel materiaAluno)
        {
            
            try
            {
                
                AlunoService alunoService = new AlunoService();
                
                bool matLoc = alunoService.MateriaVerifica(materiaAluno.IdAluno, materiaAluno.IdMateria);
                if (matLoc == true)
                {
                    //TempData["AlertMensagem"] = " ERROR 400 Bad Request";

                }
                else
                {
                    alunoService.CadastrarMateria(materiaAluno.IdAluno,materiaAluno.IdMateria);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }

        }

        // DELETE: api/Aluno/5
        public HttpResponseMessage Delete(int id)
        {

            AlunoService alunoService = new AlunoService();
            Aluno aluno = new Aluno();
            aluno.Id = id;
            alunoService.Remover(id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}

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
    public class MateriaController : ApiController
    {
        // GET: api/Materia
        public HttpResponseMessage Get()
        {
            MateriaService materia = new MateriaService();
            return Request.CreateResponse(HttpStatusCode.OK, materia.GetMaterias());

        }

        // POST: api/Materia
        public HttpResponseMessage Get(int id)
        {
            MateriaService materia = new MateriaService();
            return Request.CreateResponse(HttpStatusCode.OK, materia.LocalizarMaterias(id));
        }

        public HttpResponseMessage Post([FromBody] Materia materia)
        {

            try
            {
                MateriaService materiaService = new MateriaService();
                materiaService.Cadastrar(materia.Nome);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }
        }
       
        // DELETE: api/Materia/5
        public HttpResponseMessage Delete(int id)
        {
            MateriaService materia = new MateriaService();
            Materia materias = new Materia();
            materias.Id = id;

            materia.Remover(materias.Id);

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}

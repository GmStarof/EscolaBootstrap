
using Appai.Domain;
using AppaiEstudeEx;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Appai.Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;

namespace Teste1
{
    public class Startup
    {
        AlunoService alunoService = new AlunoService();
        

        public void Configure(IApplicationBuilder app)
        {
            app.Run(ListaDeAlunos);
        }
        public Task Roteamento(HttpContext context)
        {
            var rep = alunoService.getAlunos();
            

            var caminhoAtendidos = new Dictionary<string,string >
            {
                {"Alunos/ListaDeAlunos", rep.ToString()  }

            };
            if (caminhoAtendidos.ContainsKey(context.Request.Path))
            {
                return context.Response.WriteAsync(caminhoAtendidos[context.Request.Path]);
            }


            return context.Response.WriteAsync("Caminho inexistente!");
        }
        public Task ListaDeAlunos(HttpContext contex)
        {
            var rep = alunoService.getAlunos();
            return contex.Response.WriteAsync(rep.ToString());
            
        }
    }
}   
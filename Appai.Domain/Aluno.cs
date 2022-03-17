using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Appai.Domain
{
    public class Aluno
    {
        
        private string nome;
        private string email;
        private int id = 0;
        private string status = "Pendente";
        private List<Materia> materia = new List<Materia>();


        public Aluno()
        {

        }
        public Aluno(string nome, string email, int id)
        {
            this.nome = nome;
            this.email = email;
            this.id = id;

        }


        [Required(ErrorMessage = "O nome do usuário deve ser informado")]
        public string Nome
        {
            
            get { return nome; }
            set { nome = value; }
        }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email
        { 

            get { return email; }
            set { email = value; }

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<Materia> Materia
        {
            get { return materia; }
            set { materia = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}

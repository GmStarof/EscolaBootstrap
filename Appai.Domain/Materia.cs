using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appai.Domain
{
    public class Materia
    {
        private string nome;
        private int id = 0;
        private double nota = 0;
        public Materia()
        {

        }
        public Materia(string nome, int id)
        {
            this.nome = nome;
            this.id = id;

        }
        [Required(ErrorMessage = "O nome da matateria deve ser informado")]
        [StringLength(20, MinimumLength = 5)]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Nota
        {
            get { return nota; }
            set { nota = value; }
        }
    }
}

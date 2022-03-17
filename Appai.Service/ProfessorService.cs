using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Domain;
using Appai.Repository;

namespace Appai.Service
{
    public class ProfessorService
    {
        public List<Professor> getProfessor()
        {
            return ProfessorRepository.GetAll();
        }
        public bool Cadastrar(string nome, string email)
        {
            return ProfessorRepository.CadastroProfessor(nome, email);
        }
        public bool Cadastrar(Professor profe)
        {
            return ProfessorRepository.CadastroProfessor(profe);
        }
        public void CadastrarMateria(int id, int idMateria)
        {
            ProfessorRepository.CadastrarMateria(id, idMateria);
        }
        public bool MateriaVerifica(int id)
        {
            return ProfessorRepository.MateriaVerificar(id);
        }

        public bool Remover(int id)
        {
            return ProfessorRepository.RemoverProfessor(id);
        }
        public bool StatusFinan(int id)
        {
            return ProfessorRepository.SituaçãoFina(id);
        }
        public bool localizarP(int id)
        {
            return ProfessorRepository.localizar(id);
        }
        public Professor localizarProfessor(int id)
        {
            return ProfessorRepository.LocalizarProfessor(id);
        }
        public void PagarProfe(int id)
        {
            ProfessorRepository.PagarProfe(id);
        }
        public bool VerificarEmail(string email)
        {
            return ProfessorRepository.VerificarEmail(email);
        }
    }
}

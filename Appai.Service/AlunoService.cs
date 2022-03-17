using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Repository;
using Appai.Domain;

namespace Appai.Service
{
    public class AlunoService
    {
        public List<Aluno> getAlunos()
        {
            return AlunosRepository.GetAll();
        }

        public bool Remover(int id)
        {

            return AlunosRepository.RemoverAluno(id);
        }

        public bool Cadastrar(string nome, string email)
        {
            return AlunosRepository.CadastroAluno(nome, email);

        }
        public bool Cadastrar(Aluno aluno)
        {
            return AlunosRepository.CadastroAluno(aluno);

        }
        public bool MateriaVerifica(int idAlu, int idMat)
        {
            return AlunosRepository.MateriaVerificar(idAlu, idMat);
        }

        public void CadastrarMateria(int id, int idMat )
        {
            AlunosRepository.CadastrarMateria(id,idMat );
        }

        public void CadastrarNota(int id, int idMat, double nota)
        {
            AlunosRepository.CadastrarNota(id, idMat, nota);
        }
        public bool StatusFinan(int id)
        {
            return AlunosRepository.SituaçãoFina(id);
        }
        public bool localizarP(int id)
        {
            return AlunosRepository.localizar(id);
        }
        public void PagarAluno(int id)
        {
            AlunosRepository.PagarAluno(id);
        }
        public Aluno LocalizarAluno1(int id)
        {
           return AlunosRepository.LocalizarAluno1(id);
        }
        public Aluno LocalizarAluno(int id)
        {
            return AlunosRepository.LocalizarAluno(id);
        }
    }
}

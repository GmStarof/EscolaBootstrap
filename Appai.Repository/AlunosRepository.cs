using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Domain;

namespace Appai.Repository
{
    public static class AlunosRepository
    {
        

        public  static SQLServeClass db;

        public static List<Aluno> GetAll() 
        {
            List<Aluno> pAlunos = new List<Aluno>();
         
            try 
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM  Alunos "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if(dt.Rows.Count > 0)
                {
                    for(int i = 0; i < dt.Rows.Count ; i++)
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = int.Parse(dt.Rows[i]["id"].ToString());
                        aluno.Nome = dt.Rows[i]["nome"].ToString();
                        aluno.Email = dt.Rows[i]["email"].ToString();
                        aluno.Status = dt.Rows[i]["status"].ToString();
                        aluno.Materia = MateriasRepository.LocalizarMaterias(aluno.Id);
                        

                        pAlunos.Add(aluno);
                    }
                }
                return pAlunos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar alunos " + ex.Message);
                return pAlunos;
            }

        }

        public static Aluno LocalizarAluno1(int id) 
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos_Materias WHERE Id_Aluno = '" + id + "' ";//comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                Aluno aluno = LocalizarAluno(id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int idMat = int.Parse(dt.Rows[i]["Id_Materia"].ToString());
                        Materia materiaAluno = MateriasRepository.LocalizarMateria(idMat);
                        aluno.Materia.Add(materiaAluno);
                    }
                }
                return aluno;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

       
        public static bool RemoverAluno(int id)
        {

            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "DELETE FROM  Alunos WHERE Id = '" + id + "' "; ; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }


        }

        
        public static void CadastrarNota(int id, int idMat, double nota)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "UPDATE Alunos_Materias SET Nota = '"+ nota +"' WHERE Id_Aluno = '" + id + "' AND Id_Materia = '"+idMat+"' "; ; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela


            }
            catch (Exception ex)
            {


            }

        }

        public static bool CadastroAluno(string nome, string email)
        {


            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Alunos(Nome, Email, Status) VALUES('" + nome + "', '" + email + "', 'Pendente')"; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                return true;
            }
            catch (Exception ex)
            {

                return false;
             
            }


        }
        public static bool CadastroAluno(Aluno aluno)
        {


            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Alunos(Nome, Email, Status) VALUES('" + aluno.Nome + "', '" + aluno.Email + "', 'Pendente')"; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                return true;
            }
            catch (Exception ex)
            {

                return false;

            }


        }
        public static bool MateriaVerificar(int idAlu, int idMat)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos_Materias WHERE Id_Aluno = '" + idAlu + "' ";  //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int idaux = int.Parse(dt.Rows[i]["Id_Materia"].ToString());
                        if (idMat == idaux)
                        {
                            return true;
                        }
                    }

                    return false;
                }


            }
            catch (Exception ex)
            {

                return false;

            }

        }

        public static void CadastrarMateria(int id, int idMat)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Alunos_Materias(Id_Materia, Id_Aluno) VALUES(" + idMat + "," + id + ")";  //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                
            }
            catch (Exception ex)
            {



            }

        }

        public static bool localizar(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos WHERE Alunos.Id = '" + id + "' "; ; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return true;
            }

        } 
        public static Aluno LocalizarAluno(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos WHERE Alunos.Id = '" + id + "' "; ; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                 if (dt.Rows.Count > 0)
                    {

                        Aluno aluno = new Aluno();
                        aluno.Id = int.Parse(dt.Rows[0]["id"].ToString());
                        aluno.Nome = dt.Rows[0]["nome"].ToString();
                        aluno.Email = dt.Rows[0]["email"].ToString();
                        aluno.Status = dt.Rows[0]["status"].ToString();
                        aluno.Materia = MateriasRepository.LocalizarMaterias(aluno.Id);

                    return aluno;
                    }

                return null;
               
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public static bool SituaçãoFina(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos WHERE Alunos.Id = '" + id + "' AND Alunos.Status = 'Pago' ";  //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {

                return true;
            }
        }

        public static void PagarAluno(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "UPDATE Alunos SET Status = 'Pago' WHERE Alunos.Id = '" + id + "' ";//comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela


            }
            catch (Exception ex)
            {


            }
        }
    }
}

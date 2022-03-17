using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Domain;

namespace Appai.Repository
{
    public static class ProfessorRepository
    {
        public static List<Professor> profe = new List<Professor>();
        public static SQLServeClass db;

        public static List<Professor> GetAll()
        {
            List<Professor> pProfessor = new List<Professor>();

            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM  Professores "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Professor professor = new Professor();
                        professor.Id = int.Parse(dt.Rows[i]["id"].ToString());
                        professor.Nome = dt.Rows[i]["nome"].ToString();
                        professor.Email = dt.Rows[i]["email"].ToString();
                        professor.Status = dt.Rows[i]["status"].ToString();
                        var teste = dt.Rows[i]["id_materia"].ToString();

                        if (teste.Length > 0)
                        {
                            professor.Materia = MateriasRepository.LocalizarMateria(int.Parse(dt.Rows[i]["id_materia"].ToString()));


                        }

                        pProfessor.Add(professor);
                    }
                }
                return pProfessor;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar Professores " + ex.Message);
                Console.WriteLine(ex.ToString());
                return pProfessor;
            }

        }
        public static bool CadastroProfessor(string nome, string email)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Professores(Nome, Email, Status) VALUES('" + nome + "', '" + email + "', 'Pendente')"; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Cadastrar Professores " + ex.Message);
                return false;
            }

        }
        public static bool CadastroProfessor(Professor profe)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Professores(Nome, Email, Status) VALUES('" + profe.Nome + "', '" + profe.Email + "', 'Pendente')"; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Cadastrar Professores " + ex.Message);
                return false;
            }

        }

        public static bool RemoverProfessor(int id)
        {


            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "DELETE FROM  Professores WHERE Id = '" + id + "' ";  //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }
        public static bool MateriaVerificar(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Professores WHERE Professores.Id = '"+ id+ "' "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                   
                    int idaux = int.Parse(dt.Rows[0]["Id_Materia"].ToString());
                       return true;
                    
                    
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static void CadastrarMateria(int id, int idMateria)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "UPDATE Professores SET Id_Materia = " + idMateria + " WHERE Professores.Id = " + id + "";  //comando SQL 
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
                var SQL = "SELECT * FROM Professores WHERE Professores.Id = '" + id + "' "; ; //comando SQL 
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
        public static Professor LocalizarProfessor(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Professores WHERE Professores.Id = '" + id + "' ";//comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count > 0)
                {

                    Professor professor = new Professor();
                    professor.Id = int.Parse(dt.Rows[0]["id"].ToString());
                    professor.Nome = dt.Rows[0]["nome"].ToString();
                    professor.Email = dt.Rows[0]["email"].ToString();
                    professor.Status = dt.Rows[0]["status"].ToString();
                    var teste = dt.Rows[0]["id_materia"].ToString();

                    if (teste.Length > 0)
                    {
                        professor.Materia = MateriasRepository.LocalizarMateria(int.Parse(dt.Rows[0]["id_materia"].ToString()));
                        

                    }
                    return professor;
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
                var SQL = "SELECT * FROM Professores WHERE Professor.Id = '" + id + "' AND Professores.Status = 'Pago' ";  //comando SQL 
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

        public static void PagarProfe(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "UPDATE Professores SET Status = 'Pago' WHERE Professores.Id = '" + id + "' "; ; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela


            }
            catch (Exception ex)
            {


            }

        }
        public static bool VerificarEmail(string email)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Professores WHERE Professores.Email = '" + email + "' "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {

                    string idaux = dt.Rows[0]["Email"].ToString();
                    return true;


                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}

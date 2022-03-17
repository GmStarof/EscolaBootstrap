using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Domain;

namespace Appai.Repository
{
    public static class MateriasRepository
    {
        
        public static SQLServeClass db;

        public static List<Materia> MateriasGetAll()
        {
            List<Materia> pMateria = new List<Materia>();

            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM  Materias "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Materia materia = new Materia();
                        materia.Id = int.Parse(dt.Rows[i]["id"].ToString());
                        materia.Nome = dt.Rows[i]["nome"].ToString();
                       
                        pMateria.Add(materia);
                    }
                }
                return pMateria;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar Materias " + ex.Message);
                return pMateria;
            }

        }
        public static bool CadastroMateria(string nome)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "INSERT INTO Materias(Nome) VALUES('" + nome + "')"; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Cadastrar Materia " + ex.Message);
                return false;
            }

        }
        public static bool Localizar(int id)
        {

            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Materias WHERE Materias.Id = '" + id + "' ";  //comando SQL 
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

        public static bool RemoverMateria(int id)
        {

            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "DELETE FROM  Materias WHERE Materias.Id = '" + id + "' "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela

                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }
        public static List<Materia>  LocalizarMaterias(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Alunos_Materias WHERE Id_Aluno = '" + id + "' "; //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                List<Materia> mat = new List<Materia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idMat = int.Parse(dt.Rows[i]["Id_Materia"].ToString());
                    Materia materia = LocalizarMateria(idMat);
                    var verfic = dt.Rows[i]["Nota"].ToString();
                    if(verfic.Length > 0)
                    {
                        double nota = double.Parse(dt.Rows[i]["Nota"].ToString());
                        materia.Nota = nota;
                    }
                    
                   
                    mat.Add(materia);
                }
                return mat;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;

            }
        }

        public static Materia LocalizarMateria(int id)
        {
            try
            {
                db = new SQLServeClass(); //abro a conexão com o banco de dados
                var SQL = "SELECT * FROM Materias WHERE Materias.Id = '" + id + "' ";  //comando SQL 
                var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                if (dt.Rows.Count > 0)
                {
                    
                        Materia materia = new Materia();

                        materia.Id = int.Parse(dt.Rows[0]["id"].ToString());
                        materia.Nome = dt.Rows[0]["nome"].ToString();
                    

                    return materia;
                }
                        return  null;
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static string Teste1()
        {
            
            
            try
                {
                    db = new SQLServeClass(); //abro a conexão com o banco de dados
                    var SQL = "SELECT * FROM Alunos, Professores WHERE  Alunos.Status = 'Pendente' AND Professores.Status = 'Pendente'"; //comando SQL 
                    var dt = db.SQLQuery(SQL); //Retorno do Banco em formato de tabela
                    List<Aluno> alunos = new List<Aluno>();
                    List<Professor> prof = new List<Professor>();
                    Professor professor = new Professor();
                    Aluno aluno = new Aluno();
                
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        aluno.Status = dt.Rows[i]["Status"].ToString();
                        professor.Status = dt.Rows[i]["Status"].ToString();
                        aluno.Status.Concat(professor.Status);
                    }
                }
                return aluno.ToString();
            }
            

                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar alunos " + ex.Message);
                return null;
                }
        }
       
    }
}

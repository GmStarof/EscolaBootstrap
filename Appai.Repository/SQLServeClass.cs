using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Appai.Repository
{
    public class SQLServeClass
    {
        public string stringConn;
        public SqlConnection connDB;

        public SQLServeClass()
        {
            try
            {
                stringConn = "Data Source=APTS;Initial Catalog=AppaiEstudeGuilherme;Integrated Security=True"; //Passo a string de conexão
                connDB = new SqlConnection(stringConn); // Faço a minha conexão
                connDB.Open(); //Eu Abro a conexão
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myComand = new SqlCommand(SQL, connDB);
                myComand.CommandTimeout = 0;
                var myReady = myComand.ExecuteReader();
                dt.Load(myReady);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public string SQLCommand(string SQL)
        {
            try
            {
                var myComand = new SqlCommand(SQL, connDB); // criando a variavel, como se tivesse preparando um pacote a ser enviado para o banco 
                myComand.CommandTimeout = 0; // faz com que espere o tempo nescessario para enviar o pacote 
                var myReady = myComand.ExecuteReader(); // envia o pacote
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Close()
        {
            connDB.Close();
        }
    }
}

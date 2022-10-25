using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Controldeaplicaciones_TODOLIST.BD
{
    public class ConecctionDB
    {

        protected SqlConnection con;

        protected void Conectar()
        {
            try
            {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Open();
            }
            catch (Exception e){ Console.WriteLine(e.StackTrace); }
        }

        protected void Desconectar()
        {
            try
            {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
    }
}
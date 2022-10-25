using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTask
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTask" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTask.svc o ServiceTask.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTask : ITask
    {
        protected SqlConnection con;

        public List<Task> GetTasks()
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();
            //Lista para almacenar los
            List<Task> listObj = new List<Task>();
            try
            {
                SqlCommand cmd = new SqlCommand("ListTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Task tsk = new Task();
                    tsk.Id = Convert.ToInt32(dr[0]);
                    tsk.Nombre = Convert.ToString(dr[1]);
                    tsk.Nota = Convert.ToString(dr[2]);
                    tsk.Fechacre = Convert.ToDateTime(dr[3]);
                    tsk.Estado = Convert.ToInt32(dr[4]); ;
                    tsk.Fechater = Convert.ToDateTime(dr[5]);
                    tsk.Prioridad = Convert.ToString(dr[6]);
                    listObj.Add(tsk);
                }
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }

            return listObj;
        }

        public List<Task> ListPriority(string filtro)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();
            //Lista para almacenar los
            List<Task> listObj = new List<Task>();
            try
            {
                SqlCommand cmd = new SqlCommand("FilterPriority", con);
                cmd.Parameters.AddWithValue("@priority", filtro);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Task tsk = new Task();
                    tsk.Id = Convert.ToInt32(dr[0]);
                    tsk.Nombre = Convert.ToString(dr[1]);
                    tsk.Nota = Convert.ToString(dr[2]);
                    tsk.Fechacre = Convert.ToDateTime(dr[3]);
                    tsk.Estado = Convert.ToInt32(dr[4]); ;
                    tsk.Fechater = Convert.ToDateTime(dr[5]);
                    tsk.Prioridad = Convert.ToString(dr[6]);
                    listObj.Add(tsk);
                }
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }

            return listObj;
        }

        public List<Task> ListId(int id)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();

            //Lista para almacenar los
            List<Task> listObj = new List<Task>();
            try
            {
                SqlCommand cmd = new SqlCommand("FilterId", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Task tsk = new Task();
                    tsk.Id = Convert.ToInt32(dr[0]);
                    tsk.Nombre = Convert.ToString(dr[1]);
                    tsk.Nota = Convert.ToString(dr[2]);
                    tsk.Fechacre = Convert.ToDateTime(dr[3]);
                    tsk.Estado = Convert.ToInt32(dr[4]); ;
                    tsk.Fechater = Convert.ToDateTime(dr[5]);
                    tsk.Prioridad = Convert.ToString(dr[6]);
                    listObj.Add(tsk);
                }
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }

            return listObj;
        }

        public void InsertTask(Task task)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertTask", con);
                cmd.Parameters.AddWithValue("@name", task.Nombre);
                cmd.Parameters.AddWithValue("@note", task.Nota);
                cmd.Parameters.AddWithValue("@dateini", task.Fechacre);
                cmd.Parameters.AddWithValue("@status", task.Estado);
                cmd.Parameters.AddWithValue("@datefin", task.Fechater);
                cmd.Parameters.AddWithValue("@priority", task.Prioridad);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }
        }

        public void EditTask(Task task)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateTask", con);
                cmd.Parameters.AddWithValue("@id", task.Id);
                cmd.Parameters.AddWithValue("@name", task.Nombre);
                cmd.Parameters.AddWithValue("@note", task.Nota);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }
        }

        public void ChangeStatusTask(int id)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateStatus", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }
        }

        public void DeleteTask(int id)
        {
            //Conexion a la BD  
            con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteTask", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }
            finally {
                con = new SqlConnection("Data Source=ULISES;Initial Catalog=TaskBD;Integrated Security=true");
                con.Close();
            }
        }
    }
}

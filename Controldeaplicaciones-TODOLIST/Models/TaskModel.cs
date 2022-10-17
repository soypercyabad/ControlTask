using Controldeaplicaciones_TODOLIST.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Controldeaplicaciones_TODOLIST.Models
{
    public class TaskModel: ConecctionDB
    {
        //Metodo de Listar Tareas
        public List<Task> GetTasks()
        {
            //Conexion a la BD  
            Conectar();
            //Lista para almacenar los
            List<Task> listObj = new List<Models.Task>();
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
            catch (Exception e){ Console.WriteLine(e.StackTrace); }
            finally{ Desconectar(); }

            return listObj;
        }

        //Metodo de Listar por Prioridad
        public List<Task> ListPriority(string filtro)
        {
            //Conexion a la BD  
            Conectar();
            //Lista para almacenar los
            List<Task> listObj = new List<Models.Task>();
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
            finally { Desconectar(); }

            return listObj;
        }

        //Metodo de Listar por id
        public List<Task> ListId(int id)
        {
            //Conexion a la BD  
            Conectar();
            //Lista para almacenar los
            List<Task> listObj = new List<Models.Task>();
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
            finally { Desconectar(); }

            return listObj;
        }

        //Metodo de Agregar Tarea
        public void InsertTask(Task task)
        {
            Conectar();
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
            catch (Exception e){ Console.WriteLine(e.StackTrace); }
            finally{ Desconectar(); }
        }

        //Metodo de Editar Tarea
        public void EditTask(Task task)
        {
            Conectar();
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
            finally { Desconectar(); }
        }

        //Metodo de Cambiar Estado
        public void ChangeStatusTask(int id)
        {
            Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateStatus", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {Console.WriteLine(e.StackTrace);}
            finally { Desconectar(); }
        }

        //Metodo de Eliminar Task
        public void DeleteTask(int id)
        {
            Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteTask", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }
            finally { Desconectar(); }
        }
    }
}
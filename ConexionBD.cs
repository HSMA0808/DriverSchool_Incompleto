using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Driver_Principal.Clases
{
    class ConexionBD
    {
        private SqlConnection Conexion;
        private SqlDataAdapter Adaptador;
        private DataTable Tabla;
        //Cadena de Conexion a la base de datos extraida desde el AppConfig
        private string ConexionString = ConfigurationManager.ConnectionStrings["ConexionDefault"].ToString();

        //Metodo para capturar errores al interactuar con la BD
        public void ErrorDB(Exception X)
        {
            MessageBox.Show("Ha ocurrido un error al conectar a la base de datos: " + X, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private SqlConnection Conectar(string cadenaConexion)
        {
            try
            {
                Conexion = new SqlConnection(cadenaConexion);
                Conexion.Open();
                return Conexion;
            }
            catch (Exception Descripcion)
            {
                Conexion.Close();
                MessageBox.Show("No se pudo abrir la conexion: " + Descripcion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Conexion;
            }
        }

        //Metodo para extraer datos de SQL SERVER y mapearlos en los formularios
        public DataSet EjecutarDS (SqlCommand comando)
        {
            Conexion = Conectar(ConexionString);
            DataSet DS = new DataSet();
            try
            {
                comando.Connection = Conexion;
                Adaptador = new SqlDataAdapter(comando);
                Adaptador.Fill(DS);
                Conexion.Close();
                Controladores.RightOps();
                return DS;
            }
            catch (Exception X)
            {
                Conexion.Close();
                ErrorDB(X);
                return DS;
            }

        }

        //Metodo para cargar datos a un Data Grid View desde la BD
        public void LlenarDGV(SqlCommand comando, DataGridView DGV)
        {
            Conexion = Conectar(ConexionString);
            Tabla = new DataTable();
            try
            {
                comando.Connection = Conexion;
                Adaptador = new SqlDataAdapter(comando);
                Adaptador.Fill(Tabla);
                DGV.DataSource = Tabla;
                Conexion.Close();
                Controladores.RightOps();
            }
            catch (Exception X)
            {
                Conexion.Close();
                ErrorDB(X);
            }
        }

        //Metodo para ejecutar Querys en SQL Server
        public void EjecutarQuery(SqlCommand comando)
        {
            Conexion = Conectar(ConexionString);
            var Transaccion = Conexion.BeginTransaction();
            comando.Connection = Conexion;
            comando.Transaction = Transaccion;
            try
            {
                comando.ExecuteNonQuery();
                Transaccion.Commit();
                Conexion.Close();
                Controladores.RightOps();
            }
            catch (Exception X)
            {
                Transaccion.Rollback();
                Conexion.Close();
                ErrorDB(X);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Driver_Principal.Clases
{
    class Estudiante : IEntidades
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public char Sexo { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public bool Ok { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }

        public void Insertar()
        {
            ConexionBD DB = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec InsertarEstudiantes @Nombres, @Apellido1, @Apellido2, @Sexo, @Email, " + 
            "@Tel, @FechaNacimiento, @LugarNacimiento, @Direccion, @Cedula");
            comando.Parameters.Add(new SqlParameter("@Nombres", Nombres));
            comando.Parameters.Add(new SqlParameter("@Apellido1", Apellido1));
            comando.Parameters.Add(new SqlParameter("@Apellido2", Apellido2));
            comando.Parameters.Add(new SqlParameter("@Sexo", Sexo));
            comando.Parameters.Add(new SqlParameter("@Email", Email));
            comando.Parameters.Add(new SqlParameter("@Tel", Tel));
            comando.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));
            comando.Parameters.Add(new SqlParameter("@LugarNacimiento", LugarNacimiento));
            comando.Parameters.Add(new SqlParameter("@Direccion", Direccion));
            comando.Parameters.Add(new SqlParameter("@Cedula", Cedula));
            DB.EjecutarQuery(comando);
        }

        //Metodo para Actualizar un usuario
        public void Actualizar()
        {
            ConexionBD DB = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec ActualizarEstudiantes @Id, @Nombres, @Apellido1, @Apellido2, @Sexo, @Email, " +
            "@Tel, @FechaNacimiento, @LugarNacimiento, @Direccion, @Cedula");
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            comando.Parameters.Add(new SqlParameter("@Nombres", Nombres));
            comando.Parameters.Add(new SqlParameter("@Apellido1", Apellido1));
            comando.Parameters.Add(new SqlParameter("@Apellido2", Apellido2));
            comando.Parameters.Add(new SqlParameter("@Sexo", Sexo));
            comando.Parameters.Add(new SqlParameter("@Email", Email));
            comando.Parameters.Add(new SqlParameter("@Tel", Tel));
            comando.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));
            comando.Parameters.Add(new SqlParameter("@LugarNacimiento", LugarNacimiento));
            comando.Parameters.Add(new SqlParameter("@Direccion", Direccion));
            comando.Parameters.Add(new SqlParameter("@Cedula", Cedula));
            DB.EjecutarQuery(comando);
        }

        //Metodo para mostrar los usuarios
        public DataGridView Mostrar(int Opcion, string valor, DataGridView DGV)
        {
            ConexionBD BD = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec MostrarEstudiantes @Opcion, @valor");
            comando.Parameters.Add(new SqlParameter("@Opcion", Opcion));
            comando.Parameters.Add(new SqlParameter("@valor", valor));
            BD.LlenarDGV(comando, DGV);
            return DGV;
        }

        //Metodo para eliminar un usuario
        public void Eliminar()
        {
            ConexionBD BD = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec EliminarEstudiantes @Id");
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            BD.EjecutarQuery(comando);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Driver_Principal.Clases
{
    class Inscripcion
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public int MetPago { get; set; }
        public int Horario { get; set; }
        public double Balance { get; set; }
        public double Credito { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }

        //Insertar Inscripcion
        public void Insertar()
        {
            ConexionBD DB = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec InsertarInscripcion @IdEstudiante, @IdCurso, @IdEmpleado, " +
            "@MetPago, @Horario, @Balance, @Credito");
            comando.Parameters.Add(new SqlParameter("@IdEstudiante", IdEstudiante));
            comando.Parameters.Add(new SqlParameter("@IdCurso", IdCurso));
            comando.Parameters.Add(new SqlParameter("@IdEmpleado", IdEmpleado));
            comando.Parameters.Add(new SqlParameter("@MetPago", MetPago));
            comando.Parameters.Add(new SqlParameter("@Horario", Horario));
            comando.Parameters.Add(new SqlParameter("@Balance", Balance));
            comando.Parameters.Add(new SqlParameter("@Credito", Credito));
            DB.EjecutarQuery(comando);
        }

        //Metodo para Actualizar una Inscripcion
        public void Actualizar()
        {
            ConexionBD DB = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec ActualizarInscripcion @Id, @IdEstudiante, @IdCurso, @IdEmpleado, " +
            "@MetPago, @Horario, @Balance, @Credito, @Fecha");
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            comando.Parameters.Add(new SqlParameter("@IdEstudiante", IdEstudiante));
            comando.Parameters.Add(new SqlParameter("@IdCurso", IdCurso));
            comando.Parameters.Add(new SqlParameter("@IdEmpleo", IdEmpleado));
            comando.Parameters.Add(new SqlParameter("@MetPago", MetPago));
            comando.Parameters.Add(new SqlParameter("@Horario", Horario));
            comando.Parameters.Add(new SqlParameter("@Balance", Balance));
            comando.Parameters.Add(new SqlParameter("@Credito", Credito));
            comando.Parameters.Add(new SqlParameter("@Fecha", Fecha.ToShortDateString()));
            DB.EjecutarQuery(comando);
        }

        //Metodo para mostrar las Inscripciones
        public DataGridView Mostrar(int Opcion, string valor, DataGridView DGV)
        {
            ConexionBD BD = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec MostrarInscripcion @Opcion, @valor");
            comando.Parameters.Add(new SqlParameter("@Opcion", Opcion));
            comando.Parameters.Add(new SqlParameter("@valor", valor));
            BD.LlenarDGV(comando, DGV);
            return DGV;
        }

        //Metodo para eliminar un Inscripcion
        public void Desinscribir()
        {
            ConexionBD BD = new ConexionBD();
            SqlCommand comando = new SqlCommand("exec EliminarInscripcion @Id");
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            BD.EjecutarQuery(comando);
        }
    }
}

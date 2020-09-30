using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Driver_Principal.Clases;

namespace Driver_Principal.Formularios
{
    public partial class Param_Entidades : Form
    {
        public int id { get; set; }
        public string parametro1 { get; set; }
        public string parametro2 { get; set; }
        public DataSet DS { get; set; }

        public Param_Entidades(string entidad)
        {
            InitializeComponent();
            ConexionBD BD = new ConexionBD();
            lblParametros.Text = entidad;
            SqlCommand comando = new SqlCommand();
            switch (entidad)
            {
                case RepoValores.Entidades.Empleados:
                    comando.CommandText = "exec MostrarEmpleados 1, ''";
                    BD.LlenarDGV(comando, dgvParametros); //1 consulta todos los registros los '' son parametros no requeridos para el tipo de sonculta
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;

                case RepoValores.Entidades.Cursos:
                    comando.CommandText =  "exec MostrarCursos 1, ''";
                    BD.LlenarDGV(comando, dgvParametros);
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;

                case RepoValores.ValoresRandom.NoInscritos:
                    comando.CommandText =  "exec MostrarNoInscritos";
                    BD.LlenarDGV(comando, dgvParametros);
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;

                case RepoValores.ValoresRandom.Deudores:
                    comando.CommandText = "exec MostrarDeudores";
                    BD.LlenarDGV(comando, dgvParametros);
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;

                case RepoValores.ValoresRandom.Inscritos:
                    comando.CommandText = "exec MostrarInscritos";
                    BD.LlenarDGV(comando, dgvParametros);
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;

                case RepoValores.ValoresRandom.TomaLeccion:
                    comando.CommandText = "exec MostrarInscritos";
                    BD.LlenarDGV(comando, dgvParametros);
                    dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;
            }
        }


        private void Param_Entidades_Load(object sender, EventArgs e)
        {

        }

        private void dgvParametros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                /*id = int.Parse(dgvParametros.SelectedCells[0].Value.ToString());
                parametro1 = dgvParametros.SelectedCells[1].Value.ToString();
                parametro2 = dgvParametros.SelectedCells[2].Value.ToString();*/
        }

        private void dgvParametros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvParametros.SelectedCells[0].Value.ToString());
            parametro1 = dgvParametros.SelectedCells[1].Value.ToString();
            parametro2 = dgvParametros.SelectedCells[2].Value.ToString();
        }
    }
}

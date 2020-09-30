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
    public partial class Driver_Menu : Form
    {
        public int X = 0;
        private DataGridViewRow RowEspera { get; set; }
        private DataGridViewRow RowProceso { get; set; }

        public Driver_Menu()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(TabInscripcion);
            tabControl1.TabPages.Remove(TabRegistro);
            tabControl1.TabPages.Remove(TabTomaLeccion);
            tabControl1.TabPages.Remove(tabPagos);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Clases.Controladores.CerrarApp();
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            SubMenuMantenimientos SubMenu = new SubMenuMantenimientos();
            SubMenu.Show();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            var menu_C_R = new Driver_SubMenuConsultas();
            menu_C_R.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Driver_SubMenuConsultas menu_C_R = new Driver_SubMenuConsultas();
            menu_C_R.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clases.Controladores.CerrarApp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TabInscripcion_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TabInscripcion);
        }

        private void TabRegistro_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TabRegistro);
        }

        private void TabTomaLeccion_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(TabTomaLeccion);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarTab(TabInscripcion);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarTab(tabPagos);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarTab(TabTomaLeccion);
        }

        private void tabPagos_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPagos);
        }

        private void DGVEspera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowEspera = DGVEspera.SelectedRows[0];
            btnEnviarAProceso.Enabled = true;
        }

        private void ComboMetPago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Controladores.MontoMetodoPago(ComboMetPago, TxtMontoAPagar, double.Parse(lblCosto.Text));
        }

        private void comboMetodoPago_P_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMetodoPago_P.Text == RepoValores.MetodosDePago.DosPagos)
            {
                txtMontoAPagar_P.Enabled = false;
            }
        }

        private void btnQuitarRegistro_Click(object sender, EventArgs e)
        {
            DGVProceso.Rows.Remove(RowProceso);
            AutoSizeDGV(DGVProceso);
            Controladores.ControlActivado(false, btnQuitarRegistro, btnTomarLeccion);
        }

        private void DGVProceso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowProceso = DGVProceso.SelectedRows[0];
            btnTomarLeccion.Enabled = true;
            btnQuitarRegistro.Enabled = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            MostrarTab(TabInscripcion);
            Controladores.ControlVisible(false, btnContinuar);
        }

        private void btnCancelar_P_Click(object sender, EventArgs e)
        {
            Controladores.ControlActivado(false, txtMontoAPagar_P, btnRegistrar_P, btnCancelar_P, btnBuscar_P);
            Controladores.ControlActivado(true, btnNuevo_P);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clases.Controladores.ControlActivado(false, txtNombre, txtApellido1, txtApellido2, txtCedula, TxtCurso, txtDireccion, txtEmail, txtTelefono, RadioFemenino, RadioMasculino, btnGuardar, btnCancelar, dateTimePicker1, btnConsultar, txtLugarNacimiento);
            Clases.Controladores.ControlActivado(true, btnNuevo);
        }

        private void btnCancelar_ins_Click(object sender, EventArgs e)
        {
            Controladores.ControlActivado(false, TxtMontoAPagar, ComboHorario, ComboMetPago, BtnBuscarEstudiante, BtnBuscarCurso, btnCancelar_ins, btnGuardar_ins);
            Controladores.ControlActivado(true, btnNuevo);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComboMetPago.Text = RepoValores.MetodosDePago.Completo;
            ComboHorario.Text = RepoValores.Horario.LunesAViernes;
            lblCosto.Text = RepoValores.ValoresRandom.MontoEn0;
            Controladores.Limpiar(TxtIdInscripcion, txtIdEstudiante, TxtIDCurso, TxtCurso, TxtEstudiante, TxtMontoAPagar);
            Controladores.ControlActivado(true, TxtMontoAPagar, ComboHorario, ComboMetPago, BtnBuscarEstudiante, BtnBuscarCurso, btnCancelar_ins, btnGuardar_ins);
            Controladores.ControlActivado(false, btnNuevo);
        }

        private void btnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            Clases.Controladores.ControlActivado(true, txtNombre, txtApellido1, txtApellido2, txtCedula, TxtCurso, txtDireccion, txtEmail, txtTelefono, RadioFemenino, RadioMasculino, btnGuardar, btnCancelar, dateTimePicker1, btnConsultar, txtLugarNacimiento);
            Clases.Controladores.Limpiar(txtNombre, txtApellido1, txtCedula, TxtCurso, txtDireccion, txtEmail, txtIdEstudiante, txtLugarNacimiento, txtTelefono);
            Clases.Controladores.Limpiar(RadioFemenino, RadioMasculino);
            Clases.Controladores.Limpiar(dateTimePicker1);
            Clases.Controladores.ControlActivado(false, btnNuevo);
            Controladores.ControlVisible(false, btnContinuar);
        }

        private void btnNuevo_P_Click(object sender, EventArgs e)
        {
            Controladores.ControlActivado(false, btnNuevo_P);
            Controladores.ControlActivado(true, txtMontoAPagar_P, btnRegistrar_P, btnCancelar_P, btnBuscar_P);
            Controladores.Limpiar(txtIdInscripcion_P, txtIdEstudiante_P, txtEstudiante_P, txtCurso_P, txtMontoAPagar_P);
            comboHorario_P.Text = string.Empty;
            comboMetodoPago_P.Text = string.Empty;
            lblMontoBalance_P.Text = Controladores.montoCero;
            lblMontoTotalPago_P.Text = Controladores.montoCero;
        }

        private void BtnBuscarCurso_Click(object sender, EventArgs e)
        {
            var parametros = new Param_Entidades(RepoValores.Entidades.Cursos);
            if (parametros.ShowDialog() == DialogResult.Yes)
            {
                TxtIDCurso.Text = parametros.id.ToString();
                TxtCurso.Text = parametros.parametro1.ToString();
                lblCosto.Text = parametros.parametro2.ToString();
                Controladores.MontoMetodoPago(ComboMetPago, TxtMontoAPagar, double.Parse(lblCosto.Text));
            }
        }

        private void BtnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            var parametros = new Param_Entidades(RepoValores.ValoresRandom.NoInscritos);
            if (parametros.ShowDialog() == DialogResult.Yes)
            {
                TxtIdEstudiante_ins.Text = parametros.id.ToString();
                TxtEstudiante.Text = parametros.parametro1.ToString();
            }
        }

        private void btnEnviarAProceso_Click(object sender, EventArgs e)
        {
            DGVProceso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGVProceso.Rows.Add(RowEspera.Cells[0].Value.ToString(), RowEspera.Cells[1].Value.ToString(), RowEspera.Cells[2].Value.ToString(), RowEspera.Cells[3].Value.ToString(), RowEspera.Cells[4].Value.ToString(), RowEspera.Cells[5].Value.ToString());
            DGVEspera.Rows.Remove(RowEspera);
            AutoSizeDGV(DGVEspera);
            btnEnviarAProceso.Enabled = false;
        }
        private bool EstudianteNoRegistrado(string id, DataGridView DGV)
        {
            bool SinRegistrar = true;
            foreach (DataGridViewRow Row in DGV.Rows)
            {
                if (Row.Cells[0].Value.ToString() == id)
                {
                    SinRegistrar = false;
                    break;
                }
            }
            return SinRegistrar;
        }

        private void AutoSizeDGV(DataGridView DGV)
        {
            if (DGV.Rows.Count <= 0)
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnTomarLeccion_Click(object sender, EventArgs e)
        {
            var TomaDeLeccion = new TomaDeLeccion()
            {
                IdLeccion = int.Parse(RowProceso.Cells[4].Value.ToString()),
                IdEstudiante = int.Parse(RowProceso.Cells[0].Value.ToString()),
                IdEmpleado = 1001,
                IdCurso = int.Parse(RowProceso.Cells[2].Value.ToString())
            };
            TomaDeLeccion.Insertar();
            DGVProceso.Rows.Remove(RowProceso);
            AutoSizeDGV(DGVProceso);
            Controladores.ControlActivado(false, btnQuitarRegistro, btnTomarLeccion);
        }

        private void btnProcesos_Click(object sender, EventArgs e)
        {
            Formularios.Driver_SubMenuProcesos SubMenu = new Formularios.Driver_SubMenuProcesos();
            SubMenu.ShowDialog();
            if (SubMenu.DialogResult == DialogResult.OK)
            {
                MostrarTab(TabRegistro);
            }
            else if (SubMenu.DialogResult == DialogResult.Yes)
            {
                MostrarTab(TabTomaLeccion);
            }
            else if (SubMenu.DialogResult == DialogResult.Abort)
            {
                MostrarTab(tabPagos);
            }
        }

        private int IdMetodoPago()
        {
            if (ComboMetPago.Text == RepoValores.MetodosDePago.Completo)
            {
                return 1;
            }
            else if (ComboMetPago.Text == RepoValores.MetodosDePago.DosPagos)
            {
                return 2;
            }
            else if (ComboMetPago.Text == RepoValores.MetodosDePago.Cuotas)
            {
                return 3;
            }
            else
            {
                MessageBox.Show("Elija un metodo de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        private int IdHorario()
        {
            if (ComboHorario.Text == RepoValores.Horario.LunesAViernes)
            {
                return 1;
            }
            else if (ComboHorario.Text == RepoValores.Horario.Sabados)
            {
                return 2;
            }
            else if (ComboHorario.Text == RepoValores.Horario.Domingos)
            {
                return 3;
            }
            else
            {
                MessageBox.Show("Elija un horario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta a punto de cerrar la sesion. ¿Desea Continuar?", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Driver_Login login = new Driver_Login();
                this.Hide();
                login.Show();
            }
        }

        private void MostrarTab(TabPage tab)
        {
           int i = tabControl1.TabPages.IndexOf(tab);
            if (i == -1)
            {
                tabControl1.TabPages.Add(tab);
                tabControl1.SelectTab(tab);
            }
            else
            {
                tabControl1.SelectTab(tab);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.Estudiante estu = new Clases.Estudiante();
                estu = Clases.ServiciosRest.DatosPersonalesJSON<Clases.Estudiante>(txtCedula.Text);
                if (estu.Ok == true)
                {
                    txtNombre.Text = estu.Nombres;
                    txtApellido1.Text = estu.Apellido1;
                    txtApellido2.Text = estu.Apellido2;
                    txtCedula.Text = estu.Cedula;
                    txtLugarNacimiento.Text = estu.LugarNacimiento;
                    dateTimePicker1.Value = DateTime.Parse(estu.FechaNacimiento);
                }
                else
                {
                    Clases.Controladores.CedulaNoEncontrada(txtCedula);
                }
            }
            catch (Exception Error)
            {
                Clases.ServiciosRest.ErrorAlConsultar(Error);
            }
        }

        private async void btnGuardarEstudiante_Click(object sender, EventArgs e)
        {
            if (Controladores.CamposCompletos(txtNombre, txtApellido1, txtCedula, txtDireccion, txtLugarNacimiento))
            {
                if (Controladores.CheckUnRadio(RadioMasculino, RadioFemenino))
                {
                    Estudiante estudiante = new Estudiante()
                    {
                        Nombres = txtNombre.Text,
                        Apellido1 = txtApellido1.Text,
                        Apellido2 = txtApellido2.Text.Trim(),
                        Sexo = Controladores.ElegirSexo(RadioFemenino, RadioMasculino),
                        Cedula = txtCedula.Text,
                        Tel = txtTelefono.Text,
                        Email = txtEmail.Text,
                        Direccion = txtDireccion.Text,
                        LugarNacimiento = txtLugarNacimiento.Text,
                        FechaNacimiento = dateTimePicker1.Value.ToShortDateString()
                    };
                    await Task.Run(() =>
                    {
                        estudiante.Insertar();
                        Controladores.RightOps();
                    });
                    txtIdEstudiante.Text = Controladores.UltimoInsertado(lblEstudiantes.Text).ToString();
                    Clases.Controladores.ControlActivado(false, txtNombre, txtApellido1, txtApellido2, txtCedula, TxtCurso, txtDireccion, txtEmail, txtTelefono, RadioFemenino, RadioMasculino, btnGuardar, btnCancelar, dateTimePicker1, btnConsultar, txtLugarNacimiento);
                    Clases.Controladores.ControlActivado(true, btnNuevo);
                    Controladores.ControlVisible(true, btnContinuar);
                }
                else
                {
                    Controladores.MarqueUnRadio(lblSexo.Text);
                }
            }
            else
            {
                Controladores.CompleteLosCampos();
            }
        }

        private async void btnGuardar_ins_Click(object sender, EventArgs e)
        {
            if (Controladores.CamposCompletos(TxtIdEstudiante_ins, TxtEstudiante, TxtIDCurso, TxtCurso, TxtMontoAPagar) && (ComboMetPago.Text != string.Empty && ComboHorario.Text != string.Empty))
            {
                Inscripcion inscripcion = new Inscripcion()
                {
                    IdEstudiante = int.Parse(TxtIdEstudiante_ins.Text),
                    IdCurso = int.Parse(TxtIDCurso.Text),
                    MetPago = IdMetodoPago(),
                    Horario = IdHorario(),
                    Credito = double.Parse(TxtMontoAPagar.Text),
                    Balance = double.Parse(lblCosto.Text) - double.Parse(TxtMontoAPagar.Text),
                    IdEmpleado = 1001 //Empleado fijo por el momento
                };
                
                await Task.Run(() =>
                {
                    inscripcion.Insertar();
                    Pago pagos = new Pago()
                    {
                        idInscripcion = Controladores.UltimoInsertado(RepoValores.Entidades.Inscripcion),
                        monto = double.Parse(TxtMontoAPagar.Text),
                        Fecha = DateTime.Today
                    };
                    pagos.Insertar();
                    Controladores.RightOps();
                });
                TxtIdInscripcion.Text = Controladores.UltimoInsertado(RepoValores.Entidades.Inscripcion).ToString();
                Controladores.ControlActivado(false, TxtMontoAPagar, ComboHorario, ComboMetPago, BtnBuscarEstudiante, BtnBuscarCurso, btnCancelar_ins, btnGuardar_ins);
                Controladores.ControlActivado(true, btnNuevo);
            }
            else
            {
                Controladores.CompleteLosCampos();
            }
        }

        private void btnBuscar_P_Click(object sender, EventArgs e)
        {
            Param_Entidades menuParametros = new Param_Entidades(RepoValores.ValoresRandom.Deudores);
            if (menuParametros.ShowDialog() == DialogResult.Yes)
            {
                txtIdInscripcion_P.Text = menuParametros.id.ToString();
                ConexionBD conexion = new ConexionBD();
                SqlCommand comando = new SqlCommand("exec MostrarInscripcion 3, @Id");
                comando.Parameters.Add(new SqlParameter("@Id", txtIdInscripcion_P.Text));
                DataSet DS = conexion.EjecutarDS(comando);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    txtIdEstudiante_P.Text = DS.Tables[0].Rows[0]["ID Estudiante"].ToString();
                    txtEstudiante_P.Text = DS.Tables[0].Rows[0]["Nombre"].ToString();
                    txtCurso_P.Text = DS.Tables[0].Rows[0]["Curso"].ToString();
                    comboMetodoPago_P.Text = DS.Tables[0].Rows[0]["Metodo de Pago"].ToString();
                    comboHorario_P.Text = DS.Tables[0].Rows[0]["Horario"].ToString();
                    lblMontoTotalPago_P.Text = DS.Tables[0].Rows[0]["Credito"].ToString();
                    lblMontoBalance_P.Text = DS.Tables[0].Rows[0]["Balance"].ToString();
                    txtMontoAPagar_P.Text = DS.Tables[0].Rows[0]["Balance"].ToString();
                    txtMontoAPagar_P.Focus();
                }
            }
            else
            {
                Controladores.SeleccioneUnRegistro();
            }
        }

        private async void btnRegistrar_P_Click(object sender, EventArgs e)
        {
            if (Controladores.CamposCompletos(txtMontoAPagar_P, txtIdInscripcion_P, txtIdEstudiante_P, txtEstudiante_P, txtCurso_P))
            {
                var pago = new Pago();
                var BD = new ConexionBD();
                pago.idInscripcion = int.Parse(txtIdInscripcion_P.Text);
                pago.monto = double.Parse(txtMontoAPagar_P.Text);
                pago.Fecha = DateTime.Today;
                await Task.Run(() =>
                {
                    pago.Insertar();
                    pago.ActualizarEstadoDeCuenta(double.Parse(txtMontoAPagar_P.Text), Convert.ToInt32(txtIdInscripcion_P.Text));
                    Controladores.RightOps();
                });
                Controladores.ControlActivado(false, txtMontoAPagar_P, btnRegistrar_P, btnCancelar_P, btnBuscar_P);
                Controladores.ControlActivado(true, btnNuevo_P);
            }
            else
            {
                Controladores.CompleteLosCampos();
            }
        }

        private void btnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            Param_Entidades parametros = new Param_Entidades(RepoValores.ValoresRandom.Inscritos);
            if (parametros.ShowDialog() == DialogResult.Yes)
            {
                var DB = new ConexionBD();
                var DS = new DataSet();
                var comando = new SqlCommand();
                var estuId = parametros.id;
                comando.CommandText = @"exec MostrarInscripcion 3, @id; exec ExtraerLeccion @id;";
                comando.Parameters.Add(new SqlParameter("@id", estuId));
                DS = DB.EjecutarDS(comando);
                if (EstudianteNoRegistrado(DS.Tables[0].Rows[0]["ID Estudiante"].ToString(), DGVEspera))
                {
                    DGVEspera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DGVEspera.Rows.Add(DS.Tables[0].Rows[0]["ID Estudiante"].ToString(), DS.Tables[0].Rows[0]["Nombre"].ToString(), DS.Tables[0].Rows[0]["ID Curso"].ToString(), DS.Tables[0].Rows[0]["Curso"].ToString(), DS.Tables[1].Rows[0][0].ToString(), DS.Tables[1].Rows[0][1].ToString());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Driver_Principal.Clases
{
    class Controladores
    {
        public const string montoCero = "0.00";

        public bool HayVentanasAbiertas(int i)
        {
            bool Criterio = false;
            if (i == 1)
            {
                Criterio = true;
                MessageBox.Show("Existe una ventana emergente que esta abierta aun", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Criterio;
            }
            else
            {
                return Criterio;
            }
        }

        //Metodo para cerrar completamente la aplicacion
        public static void CerrarApp()
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de la Aplicacion?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public static void DeseaCerrar(Form X)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de esta Ventana?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                X.Close();
            }
        }

        /// <summary>
        /// Metodo que devuelve el ID del registro insertado
        /// </summary>
        public static int UltimoInsertado(string Tabla)
        {
            DataSet DS = new DataSet();
            var DB = new ConexionBD();
            SqlCommand comando = new SqlCommand("select max(id) as 'id' from "+Tabla+"");
            DS = DB.EjecutarDS(comando);
            return Convert.ToInt32(DS.Tables[0].Rows[0]["id"].ToString());
        }

        public static void ControlActivado(bool valor, params Control[] control)
        {
            foreach (Control obj in control)
            {
                obj.Enabled = valor;
            }
        }

        public static void ControlVisible(bool valor, params Control[] control)
        {
            foreach (Control obj in control)
            {
                obj.Visible = valor;
            }
        }

        public static void Limpiar(params TextBoxBase[] Txt)
        {
            foreach (TextBoxBase obj in Txt)
            {
                obj.Clear();
            }
        }

        public static void Limpiar(params RadioButton[] Radio)
        {
            foreach (RadioButton item in Radio)
            {
                item.Checked = false;
            }
        }

        public static void Limpiar(params CheckBox[] Check)
        {
            foreach (CheckBox item in Check)
            {
                item.Checked = false;
            }
        }

        public static void Limpiar(DataGridView DGV)
        {
            if (DGV.Rows.Count > 0)
            {
                for (int i = (DGV.Rows.Count - 1); i >= 0; i--)
                {
                    DGV.Rows.RemoveAt(i);
                }
            }
        }

        public static void Limpiar(params DateTimePicker[] DTP)
        {
            foreach (var picker in DTP)
            {
                picker.Value = DateTime.Now;
            }
        }

        public static void CompleteLosCampos()
        {
            MessageBox.Show("Debe de completar todos los campos para realizar la operación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void CompleteElCampo(Control control, string label = "")
        {
            MessageBox.Show("Debe de completar el campo "+label+"", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MarqueUnRadio(string campo)
        {
            MessageBox.Show("Debe de seleccionar al menos una opcion del campo " + campo, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ErrorOps(Exception X)
        {
            MessageBox.Show("Ha ocurrido un error inesperado, no se pudo completar la operacion: "+X+"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void RightOps()
        {
            MessageBox.Show("La operacion fue realizada satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DGVSinData()
        {
            MessageBox.Show("Debe agregar al menos un registro a la tabla para guardar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ValidarPassword()
        {
            MessageBox.Show("Favor de validar que la contraseña este escrita igual en ambos campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void HayLetrasEnLaCadena(string campo)
        {
            MessageBox.Show("Favor de solo digitar numeros en el campo "+campo+"", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        public static void SeleccioneUnRegistro()
        {
            MessageBox.Show("Favor de seleccionar un registro para completar los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static bool CamposCompletos(params TextBoxBase[] textBoxBases)
        {
            bool CamposConData = true;
            foreach (var txt in textBoxBases)
            {
                if (txt.Text == string.Empty)
                {
                    CamposConData = false; 
                }
            }
            return CamposConData;
        }

        public static bool CheckUnRadio(params RadioButton[] radios)
        {
            bool selected = true;
            int check = 0;
            for (int i = 0; i<radios.Length; i++)
            {
                if (radios[i].Checked == true)
                {
                    check++;
                }
                if (check == 1)
                {
                    selected = true;
                    break;
                }
            }
            return selected;
        }

        public static void AsignarSexo(RadioButton M, RadioButton F, string Sexo)
        {
            if (Sexo == "M")
            {
                M.Checked = true;
            }
            else
            {
                F.Checked = true;
            }
        }

        public static bool DGVConData(DataGridView DGV)
        {
            bool conData = true;
            if (DGV.Rows.Count == 0)
            {
                conData = false;
            }
            return conData;
        }

        public static void CedulaNoEncontrada(TextBox txtCedula)
        {
            MessageBox.Show("La cedula insertada no pudo ser encontrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCedula.Text = string.Empty;
        }

        public static char ElegirSexo(RadioButton F, RadioButton M)
        {
            if (F.Checked == true)
            {
                return 'F';
            }
            else if (M.Checked == true)
            {
                return 'M';
            }
            else
            {
                MessageBox.Show("Debe seleccionar un sexo para guardar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ' ';
            }
        }

        public static bool SoloNumeros(string cadena)
        {
            bool TieneNumeros = true;
            int prueba = 0;
            foreach (char letra in cadena)
            {
                try
                {
                    prueba = int.Parse(letra.ToString());
                }
                catch
                {
                    TieneNumeros = false;
                    break;
                }
            }
            return TieneNumeros;
        }

        public static void Leave(TextBoxBase control, string label = "")
        {
            switch (CamposCompletos(control))
            {
                case true:
                    break;

                case false:
                    CompleteElCampo(control, label);
                    break;
            }
        }

        public static void MontoMetodoPago(ComboBox ComboMetPago, TextBox TxtMontoAPagar, double monto)
        {
            switch (ComboMetPago.Text)
            {
                case RepoValores.MetodosDePago.Completo:
                    TxtMontoAPagar.Text = monto.ToString();
                    TxtMontoAPagar.Enabled = false;
                    break;

                case RepoValores.MetodosDePago.DosPagos:
                    TxtMontoAPagar.Text = (monto / 2).ToString();
                    TxtMontoAPagar.Enabled = false;
                    break;

                case RepoValores.MetodosDePago.Cuotas:
                    TxtMontoAPagar.Clear();
                    TxtMontoAPagar.Enabled = true;
                    break;
            }
        }
    }
}

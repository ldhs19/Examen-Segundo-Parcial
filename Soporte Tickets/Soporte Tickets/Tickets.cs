using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soporte_Tickets
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void generarTicketButton_Click(object sender, EventArgs e)
        {
            //DateTime fecha = fechaDateTimePicker.Value;
            string usuario = usuarioTextBox.Text;
            string cliente = clienteTextBox.Text;
            string tipoSoporte = tipoSoporteComboBox.Text;
            string descripcionSolicitud = descripcionSolicitudTextBox.Text;
            string descripcionRespuesta = descripcionRespuestaTextBox.Text;
            decimal precio = Convert.ToDecimal(precioTextBox.Text);
            decimal impuesto = Convert.ToDecimal(impuestoTextBox.Text);
            decimal descuento = Convert.ToDecimal(descuentoTextBox.Text);
            decimal total = precio + impuesto - descuento;

            // Insertar los datos en la base de datos
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=SoporteTecnico;Integrated Security=True");
            SqlCommand command = new SqlCommand("INSERT INTO Tickets (Fecha, Usuario, Cliente, TipoSoporte, DescripcionSolicitud, DescripcionRespuesta, Precio, Impuesto, Descuento, Total) VALUES (@Fecha, @Usuario, @Cliente, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta, @Precio, @Impuesto, @Descuento, @Total)", connection);
            //command.Parameters.AddWithValue("@Fecha", fecha);
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.Parameters.AddWithValue("@Cliente", cliente);
            command.Parameters.AddWithValue("@TipoSoporte", tipoSoporte);
            command.Parameters.AddWithValue("@DescripcionSolicitud", descripcionSolicitud);
            command.Parameters.AddWithValue("@DescripcionRespuesta", descripcionRespuesta);
            command.Parameters.AddWithValue("@Precio", precio);
            command.Parameters.AddWithValue("@Impuesto", impuesto);
            command.Parameters.AddWithValue("@Descuento", descuento);
            command.Parameters.AddWithValue("@Total", total);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show($"Ticket creado correctamente. Filas afectadas: {rowsAffected}", "Ticket creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        

        }
    }
    

    


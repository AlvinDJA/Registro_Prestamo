using System;
using System.Windows;
using Registro_Prestamo.BLL;
using Registro_Prestamo.Entidades;

namespace Registro_Prestamo.UI.Registros
{
    public partial class rPrestamo : Window
    {
        private Prestamos prestamo;
        private Persona persona;

        public rPrestamo()
        {
            InitializeComponent();
            PersonaComboBox.ItemsSource = PersonaBLL.GetList();
            PersonaComboBox.SelectedValuePath = "PersonaId";
            PersonaComboBox.DisplayMemberPath = "Nombres";
            Limpiar();
            persona = new Persona();
        }
        private void Limpiar()
        {
            this.prestamo = new Prestamos();
            this.prestamo.Fecha = DateTime.Now;
            this.DataContext = prestamo;
        }
        public void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;
            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, Inserte el monto", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, debe ingresar un concepto", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (FechaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, ingresa una fecha", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamo = PrestamoBLL.Buscar(Convert.ToInt32(PrestamoIdTextBox.Text));
            if (prestamo != null)
                this.prestamo = prestamo;
            else
            {
                this.prestamo = new Prestamos();
                MessageBox.Show("No se ha Encontrado", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
               
            this.DataContext = this.prestamo;
            // Buscar2Button_Click(sender, e);
        }
        private void Buscar2Button_Click(object sender, RoutedEventArgs e)
        {
            var pers = PersonaBLL.Buscar(Convert.ToInt32(PersonaComboBox.SelectedValue));
            if (pers != null)
                BalanceTextBox.Text = Convert.ToString(pers.Balance);
            else
                MessageBox.Show("Persona no encontrada", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var pers = PersonaBLL.Buscar(Convert.ToInt32(PersonaComboBox.SelectedValue));
            if (pers != null)
            {
                BalanceTextBox.Text = Convert.ToString(pers.Balance);
                decimal nuevoBalance = Convert.ToDecimal(BalanceTextBox.Text) + Convert.ToDecimal(MontoTextBox.Text);
                pers.Balance = nuevoBalance;
                PersonaBLL.Guardar(pers);
                this.DataContext = prestamo;
                var paso = PrestamoBLL.Guardar(this.prestamo);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Transaccion Fallida, Persona no encontrada", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var pers = PersonaBLL.Buscar(Convert.ToInt32(PersonaComboBox.SelectedValue));
            if (pers != null)
            {
                BalanceTextBox.Text = Convert.ToString(pers.Balance);
                decimal nuevoBalance = Convert.ToDecimal(BalanceTextBox.Text) - Convert.ToDecimal(MontoTextBox.Text);
                pers.Balance = nuevoBalance;
                PersonaBLL.Guardar(pers);
                this.DataContext = prestamo;
                if (PrestamoBLL.Eliminar(Convert.ToInt32(PrestamoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado con exito", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Transaccion Fallida Persona no encontrada", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Error);


        }
    }
}
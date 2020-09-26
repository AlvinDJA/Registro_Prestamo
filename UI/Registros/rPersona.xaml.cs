using System;
using System.Windows;
using Registro_Prestamo.BLL;
using Registro_Prestamo.Entidades;

namespace Registro_Prestamo.UI.Registros
{
    public partial class rPersona : Window
    {
        private Persona persona;
        public rPersona()
        {
            InitializeComponent();
            persona = new Persona();
        }
        private void Limpiar()
        {
            this.persona = new Persona();
            this.DataContext = persona;
        }
        public void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;
            if (BalanceTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var persona = PersonaBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));
            if (persona != null)
                this.persona = persona;
            else
                this.persona = new Persona();
            this.DataContext = this.persona;
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;
            var paso = PersonaBLL.Guardar(this.persona);
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
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonaBLL.Eliminar(Convert.ToInt32(PersonaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);


        }
    }
}

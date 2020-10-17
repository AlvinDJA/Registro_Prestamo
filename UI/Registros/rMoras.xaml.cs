using Registro_Prestamo.BLL;
using Registro_Prestamo.Entidades;
using System;
using System.Linq;
using System.Windows;

namespace Registro_Prestamo.UI.Registros
{
    /// <summary>
    /// Interaction logic for rMoras.xaml
    /// </summary>
    public partial class rMoras : Window
    {
        private Moras Mora = new Moras();

        public rMoras()
        {
            InitializeComponent();
            PrestamoComboBox.ItemsSource = PrestamoBLL.GetList();
            PrestamoComboBox.SelectedValuePath = "PrestamoId";
            PrestamoComboBox.DisplayMemberPath = "PrestamoId";
            Limpiar();
            TotalTextBox.Text = "0";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Mora;
        }
        private void Limpiar()
        {
            this.Mora = new Moras();
            this.Mora.Fecha = DateTime.Now;
            this.DataContext = Mora;
            
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Moras encontrado = MorasBLL.Buscar(Mora.MoraId);

            if (encontrado != null)
            {
                Mora = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Mora no existe en la base de datos", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Moras existe = MorasBLL.Buscar(Mora.MoraId);

            if (existe == null)
            {
                MessageBox.Show("No existe la mora en la base de datos", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MorasBLL.Eliminar(Mora.MoraId);
                MessageBox.Show("Eliminado", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (Mora.MoraId == 0)
            {
                paso = MorasBLL.Guardar(Mora);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = MorasBLL.Guardar(Mora);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Moras esValido = MorasBLL.Buscar(Mora.MoraId);

            return (esValido != null);
        }
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            TotalTextBox.Text = Convert.ToString(Convert.ToDecimal(ValorTextBox.Text) + Convert.ToDecimal(TotalTextBox.Text));
            Mora.Detalle.Add(new MorasDetalle(Mora.MoraId, Convert.ToInt32(PrestamoComboBox.Text), Convert.ToDecimal(ValorTextBox.Text)));
            Cargar();
            ValorTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (MorasDataGrid.Items.Count >= 1 && MorasDataGrid.SelectedIndex <= MorasDataGrid.Items.Count - 1)
            {
                Mora.Detalle.RemoveAt(MorasDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}

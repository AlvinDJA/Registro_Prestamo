using System.Windows;
using Registro_Prestamo.UI.Consultas;
using Registro_Prestamo.UI.Registros;

namespace Registro_Prestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void rPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            new rPrestamo().ShowDialog();
        }
         public void rPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            new rPersona().ShowDialog();
        }
        public void cPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            new cPrestamo().ShowDialog();
        }
         public void cPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            new cPersona().ShowDialog();
        }

        private void rMorasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new rMoras().ShowDialog();
        }
        private void cMorasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new cMoras().ShowDialog();
        }
    }
}

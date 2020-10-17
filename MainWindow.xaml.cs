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
            rPrestamo rprestamo = new rPrestamo();
            rprestamo.Show();
        }
         public void rPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            rPersona rpersona = new rPersona();
            rpersona.Show();
        }
        public void cPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            cPrestamo cprestamo = new cPrestamo();
            cprestamo.Show();
        }
         public void cPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            cPersona cpersona = new cPersona();
            cpersona.Show();
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

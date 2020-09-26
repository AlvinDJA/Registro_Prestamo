using System.Windows;
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
    }
}

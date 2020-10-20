using System;
using System.Windows;
using System.Collections.Generic;
using Registro_Prestamo.Entidades;
using Registro_Prestamo.BLL;

namespace Registro_Prestamo.UI.Consultas
{
    public partial class cPrestamo : Window
    {
        public cPrestamo()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Prestamos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //PrestamoId
                        listado = PrestamoBLL.GetList(e => e.PrestamoId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1: //PersonaId 
                        listado = PrestamoBLL.GetList(e => e.PersonaId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = PrestamoBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}

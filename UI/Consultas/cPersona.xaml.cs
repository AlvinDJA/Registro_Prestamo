using System;
using System.Windows;
using System.Collections.Generic;
using Registro_Prestamo.Entidades;
using Registro_Prestamo.BLL;

namespace Registro_Prestamo.UI.Consultas
{
    public partial class cPersona : Window
    {
        public cPersona()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Persona>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //PersonaId
                        listado = PersonaBLL.GetList(e => e.PersonaId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        //listado = PersonaBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = PersonaBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}

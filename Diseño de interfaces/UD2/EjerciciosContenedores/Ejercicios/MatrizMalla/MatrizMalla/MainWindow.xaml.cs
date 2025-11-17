using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrizMalla
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CrearMalla();
        }

        private void CrearMalla()
        {
            malla.RowDefinitions.Clear();
            malla.ColumnDefinitions.Clear();
            malla.Children.Clear();

            int filas = 15;
            int columnas = 15;

            // Crear filas
            for (int i = 0; i < filas; i++)
            {
                malla.RowDefinitions.Add(new RowDefinition());
            }

            // Crear columnas
            for (int j = 0; j < columnas; j++)
            {
                malla.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Crear labels dentro del grid
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Label lbl = new Label();
                    lbl.Content = $"{i},{j}";
                    lbl.HorizontalAlignment = HorizontalAlignment.Center;
                    lbl.VerticalAlignment = VerticalAlignment.Center;

                    Grid.SetRow(lbl, i);
                    Grid.SetColumn(lbl, j);

                    malla.Children.Add(lbl);
                }
            }
        }
    }

}
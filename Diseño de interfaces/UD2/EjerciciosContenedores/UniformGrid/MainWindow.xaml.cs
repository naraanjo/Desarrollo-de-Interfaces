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

namespace UniformGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String[] opciones =  {"7","8", "9", "6", "5", "4", "3", "2", "1", "=","0" ,"C" };
            int contador = 0;
            InitializeComponent();

            for (int i = 0; i < 4; i++) {

                for (int j = 0; j < 3; j++) {
                    Button boton = new Button();

                    boton.Width = 50;
                    boton.Height = 50;
                    contenedor.Children.Add(boton);
                    boton.Content = opciones[contador];
                    contador++;                
                }
            }
        }
    }
}
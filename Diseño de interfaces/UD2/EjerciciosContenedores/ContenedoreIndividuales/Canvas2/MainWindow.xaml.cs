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

namespace Canvas2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random aleator = new Random();


            for (int i = 0; i < 10; i++) { 
            
                // Creacion del boton
                Button boton = new Button();

                
                

                // Tamaño random
                int ancho = aleator.Next(50);
                int altura = aleator.Next(50);
            
                // Izq
                int izq = aleator.Next(600);

                // Der
                int der = aleator.Next(600);
                // Arr
                int arr = aleator.Next(600);
                // Abaj
                int abj = aleator.Next(600);

                boton.Width = ancho;
                boton.Height = altura;
                Canvas.SetLeft(boton,izq);
                Canvas.SetRight(boton,der);
                Canvas.SetTop(boton,arr);
                Canvas.SetBottom(boton,abj);

                contenedor.Children.Add(boton);
            }
        }
    }
}
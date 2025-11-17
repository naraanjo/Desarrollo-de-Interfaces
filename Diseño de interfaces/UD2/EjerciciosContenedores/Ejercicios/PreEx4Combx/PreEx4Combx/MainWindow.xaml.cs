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

namespace PreEx4Combx
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

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            // Obtengo el valor del nombre y de la contraseña
            String nombre = txNombre.Text;
            String passwd = txPassword.Password;

            // Valido
            if (nombre != "" && passwd != "")
            {
                // Envio los datos al comboBox
                cmbxPaises.Items.Add(nombre + " - " + passwd);

                // Limpio los campos
                txNombre.Text = "";
                txPassword.Password = "";
            }
            else {

                MessageBox.Show("Complete todos los campos");
            }
        }
    }
}
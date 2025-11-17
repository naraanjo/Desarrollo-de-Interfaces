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

namespace PreparacionExamen1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaro la lista
        private List<Persona> listaPersonas;
        public MainWindow()
        {
            InitializeComponent();


            // Inicializo la lista de personas
            listaPersonas = new List<Persona>();
            listaPersonas.Add(new Persona("Alvaro", "Naranjo", 19));
            listaPersonas.Add(new Persona("Marta", "Ruiz", 17));

            // Enlazo el data grid con la lista de personas
            dtGridPersonas.ItemsSource = listaPersonas;

        }


        // INSERTAR
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Compruebo que estan rellelos los TextBox
            String nombreUI = txBoxNombre.Text;
            String apellidoUI = txBoxApellido.Text;

            int edadUI;
            Boolean edadValida = int.TryParse(txBoxEdad.Text, out edadUI);

            // Valido
            if (nombreUI != "" && apellidoUI != "" && edadValida)
            {

                MessageBox.Show("Persona añadida correctamente");
                // Valido -> Creo la persona y la añado a la lista
                Persona personaCreada = new Persona(nombreUI, apellidoUI, edadUI);
                listaPersonas.Add (personaCreada);
                dtGridPersonas.Items.Refresh();

                // Limpio lo escrito
                txBoxNombre.Text = "";
                txBoxApellido.Text = "";
                txBoxEdad.Text = "";
            }
            else {

                MessageBox.Show("Complete todos los campos");
            }


        }


        // Actualizar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Persona personaSeleccionada = dtGridPersonas.SelectedItem as Persona;

            if (personaSeleccionada != null)
            {
                // Pongo los datos de la persona en la UI
                txBoxNombre.Text = personaSeleccionada.Nombre;
                txBoxApellido.Text = personaSeleccionada.Apellidos;
                txBoxEdad.Text = personaSeleccionada.Edad.ToString();

                // Elimino
                listaPersonas.Remove (personaSeleccionada);
            }
            else {

                MessageBox.Show("Persona no seleccionada");
            }
        }

        // Confirmar actualizacion
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Obtengo los valores de la UI
            String nombre = txBoxNombre.Text;
            String apellidos = txBoxApellido.Text;
            int edad;
            Boolean valido = int.TryParse(nombre, out edad);

            if (!valido || nombre != "" || apellidos != "")
            {
                // Creo la persona y la añado a la lista
                Persona personaActualizada = new Persona(nombre, apellidos, edad);
                listaPersonas.Add (personaActualizada);
                dtGridPersonas.Items.Refresh();

                // Limpio UI
                txBoxNombre.Text = "";
                txBoxApellido.Text = "";
                txBoxEdad.Text = "";
                // Notifico
                MessageBox.Show("Actualizacion realizada");
            }
            else {

                MessageBox.Show("Campos invalidos");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            // Capturo el seleccionado
            Persona personaSeleccionada = dtGridPersonas.SelectedItem as Persona;

            if (personaSeleccionada == null)
            {

                MessageBox.Show("Ninguna persona seleccionada");
            }
            else {

                listaPersonas.Remove(personaSeleccionada);
                // Actualizo el data grid
                dtGridPersonas.Items.Refresh();

                MessageBox.Show("Eliminacion realizada");
            }
        }


        // FILTRAR - PONE EL NOMBRE Y SACA SUS CAMPOS
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            String buscarNombre = txtBuscarNombre.Text.ToString();
                Persona personaBuscadaPorNombre = listaPersonas.FirstOrDefault(persona => persona.Nombre == buscarNombre);



            if (personaBuscadaPorNombre != null)
            {

                // Actualizo la UI
                txBoxNombre.Text = personaBuscadaPorNombre.Nombre;
                txBoxApellido.Text = personaBuscadaPorNombre.Apellidos;
                txBoxEdad.Text = personaBuscadaPorNombre.Edad.ToString();
            }
            else {

                MessageBox.Show("Persona no encontrada");
            }
        }
    }
}
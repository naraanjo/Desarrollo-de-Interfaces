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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Lista de las personas
        private List<Persona> listaPersona;

        public MainWindow()
        {
            InitializeComponent();

            listaPersona = new List<Persona>();


            listaPersona.Add(new Persona("Juan", "Perez", 20));
            listaPersona.Add(new Persona("Jose", "Garcia", 23));

            var personas = listaPersona.Where(persona => persona.Edad > 21);
            dvgPersonas.ItemsSource = personas; // Asociamos la lista de las personas
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Borra el dato que esta seleccionado
            listaPersona.Remove((Persona) dvgPersonas.SelectedItem);
            dvgPersonas.Items.Refresh(); // Para que vuelva a actualizar los datos
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (txtNombre.Text != "" && txtApellido.Text != "" && txtEdad.Text != "")
            {

                // Capturo los valores de cada textBox
                String edad = txtEdad.Text;
                String nombre = txtNombre.Text;
                String apellidos = txtApellido.Text;

                // Creo la personas
                Persona persona1 = new Persona(nombre, apellidos, int.Parse(edad));

                // Añado la persona a la lista
                listaPersona.Add(persona1);

                // Refresco el data grid
                dvgPersonas.Items.Refresh();

                txtEdad.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";

            }
            else {
                // Ventana emergente
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Obtengo la persona seleccionado en el data
            Persona personaSeleccionada = (Persona)dvgPersonas.SelectedItem;

            if (personaSeleccionada != null)
            {

                // Añado cada atributo al textBox
                txtNombre.Text = personaSeleccionada.Nombre;
                txtApellido.Text = personaSeleccionada.Apellidos;
                txtEdad.Text = personaSeleccionada.Edad.ToString();

                // Activo el otro boton
                btnActualizarConfirmar.IsEnabled = true;
            }
            else {

                MessageBox.Show("No has seleccionado a ningun persona");
            }
           

        }

        private void Button_actualizarConfirmar(object sender, RoutedEventArgs e)
        {
            // Obtengo los nuevos valores
            string nombrePersona = txtNombre.Text;
            string apellidoPersona = txtApellido.Text;
            string edadTexto = txtEdad.Text;

            if (!int.TryParse(edadTexto, out int edadNueva))
            {
                MessageBox.Show("La edad debe ser un número válido");
                return;
            }

            // Buscar persona existente usando LINQ (por nombre y apellido)
            var personaExistente = listaPersona
                .FirstOrDefault(p => p.Nombre == nombrePersona);

            if (personaExistente != null)
            {
                // Actualizo sus datos
                personaExistente.Edad = edadNueva;

                // Refresco el DataGrid
                dvgPersonas.Items.Refresh();

                // Limpio los campos
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";

                // Desactivo el botón
                btnActualizarConfirmar.IsEnabled = false;

                MessageBox.Show("Actualización realizada con éxito");
            }
            else
            {
                MessageBox.Show("No se encontró ninguna persona con ese nombre .");
            }



           /*  Obtengo los nuevos valores
            String nombrePersona = txtNombre.Text;
            String apellidoPersona = txtApellido.Text;
            String edad = txtEdad.Text;

            // Elimino el anterior
            listaPersona.Remove((Persona)dvgPersonas.SelectedItem);

            // Añado el nuevo
            listaPersona.Add(new Persona(nombrePersona,apellidoPersona,int.Parse(edad)));
            // Refresco el data grid
            dvgPersonas.Items.Refresh();

            // Limpio los campos
            txtEdad.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";

            // Vuelvo a desactivar
            btnActualizarConfirmar.IsEnabled=false;

            MessageBox.Show("Actualizacion realizada con exito");*/
        }
    }
}
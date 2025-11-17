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

namespace FiltradoPersonas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        // Declaro una lista
        private List<Persona> listaPersonas;

        public MainWindow()
        {
            InitializeComponent();

            // Inicio la lista
            listaPersonas = new List<Persona>();
            listaPersonas.Add(new Persona("Alvaro", "Naranjo", 19));
            listaPersonas.Add(new Persona("Adrian", "Dondarza", 19));
            listaPersonas.Add(new Persona("Antonio", "Cano", 48));
            listaPersonas.Add(new Persona("Vanesa", "Garcia", 49));

        }

        // Boton de filtrar
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int edadUser;
            // Obteno el valor del TextBox
            Boolean valido = int.TryParse(EdadIntroducida.Text, out edadUser);

            // Caso de que sea un numero valido
            if (valido && rdbMayor.IsChecked == true)
            {
                MessageBox.Show("Datos filtrados (Mayor que la edad indicada): ");

                // Filtro
                // Vinculo al data
                DataPersonas.ItemsSource = listaPersonas.Where(persona => persona.Edad > edadUser).ToList(); ;
                // Refresco los datos
                DataPersonas.Items.Refresh();


            }
            else if (valido && rdbMenor.IsChecked == true)
            {
                MessageBox.Show("Datos filtrados (Menor que la edad indicada): ");

                // Filtro y vinculo el data
                DataPersonas.ItemsSource = listaPersonas.Where(persona => persona.Edad < edadUser).ToList();
                DataPersonas.Items.Refresh();
            }
            else if (valido && rdbIgual.IsChecked == true)
            {
                MessageBox.Show("Datos filtrados (Igual que la edad indicada): ");

                // Filtro y vinculo
                DataPersonas.ItemsSource = listaPersonas.Where(persona => persona.Edad == edadUser).ToList();
                DataPersonas.Items.Refresh();

            }
            else
            {

                MessageBox.Show("Introduce una edad valida");
            }

            // Limpio el campo
            EdadIntroducida.Text = "";
        }

        // Boton de monstrar todos
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            // Relaciono el data con la lista
            DataPersonas.ItemsSource = listaPersonas;
            DataPersonas.Items.Refresh(); // Actulizo el contenido para ver los cambios
        }

        // Filtrar por nombre
        private void FiltrarNombre_Click(object sender, RoutedEventArgs e)
        {
            // Compruebo que hay un valor en el TextBox
            if (txBoxNombre.Text == "")
            {

                MessageBox.Show("Campo vacio, no se ha podido filtrar");
            }
            else
            {
                // Obtengo el valor del TextBox para filtrar
                String contiene = txBoxNombre.Text;

                MessageBox.Show("Datos filtrados");
                // Vinculo el data con la lista |-> FILTRANDO
                DataPersonas.ItemsSource = listaPersonas.Where(persona => persona.Nombre.Contains(contiene) || persona.Apellidos.Contains(contiene));
            }
        }

        // Ordenar segun lo que seleccione en el deslegable
        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            // Obtengo el valor del desplegable

            if (CmbxOpciones.SelectedItem != null)
            {
                // Saco la opcion seleccionada
                MessageBox.Show("Ordenacion por: " + CmbxOpciones.Text);
            }

            String opcionSeeccionada = CmbxOpciones.Text;
            // Caso de nombre - apellidos y edad
            switch (opcionSeeccionada)
            {


                case "Nombre":
                    {
                        //Vinculo el data con la lista ordenada
                        DataPersonas.ItemsSource = listaPersonas.OrderBy(persona => persona.Nombre);
                        break;
                    }

                case "Edad":
                    {
                        // Vinculo al data la lista filtrada
                        DataPersonas.ItemsSource = listaPersonas.OrderByDescending(persona => persona.Edad);
                        break;
                    }

                case "Apellido":
                    {
                        // Vinculo al data la lista filtrada
                        DataPersonas.ItemsSource = listaPersonas.OrderBy(persona => persona.Apellidos);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }


        // Funciones - segun lo seleccionado en el desplegable
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Compruebo que haya algo seleccionado
            if (CmbxFunciones.SelectedItem != null)
            {
                String opcionSeleccionada = CmbxFunciones.Text;
                switch (opcionSeleccionada)
                {


                    case "Maximo":
                        {
                            // Persona mas grande
                            if (listaPersonas != null)
                            {
                                Persona personaMayor = listaPersonas.OrderByDescending(persona => persona.Edad).FirstOrDefault();
                                MessageBox.Show("Persona mayor: " + personaMayor.Nombre + " -> " + personaMayor.Edad);
                            }
                            break;
                        }

                    case "Minimo":
                        {
                            // Persona mas pequeña
                            if (listaPersonas != null)
                            {
                                Persona personaMenor = listaPersonas.OrderBy(persona => persona.Edad).FirstOrDefault();
                                MessageBox.Show("Persona menor: " + personaMenor.Nombre + " -> " + personaMenor.Edad);
                            }
                            break;
                        }

                    case "Contar":
                        {
                            // Cantidad de elementos
                            if (listaPersonas != null)
                            {
                                int cantidadPersonas = listaPersonas.Count();
                                MessageBox.Show("Cantidad de personas: " + cantidadPersonas);
                            }
                            break;
                        }
                    case "Media":
                        {
                            // Vinculo al data la lista filtrada
                            double mediaEdad = listaPersonas.Average(persona => persona.Edad);
                            MessageBox.Show("Edad media: " + mediaEdad);
                            break;
                        }

                    case "Ordenar":
                        {

                            // Veo si esta seleccionada o no el chekc
                            // Indica si se filtra ASC o DESC
                            // Vinculo al data la lista filtrada

                            if (chckBoxOrdenarSegun.IsChecked == true)
                            {

                                // Filtrado ASC
                                // Vinculo el data a la lista filtrada
                                DataPersonas.ItemsSource = listaPersonas.OrderBy(persona => persona.Edad);
                            }
                            else
                            {

                                // Filtrado DESC
                                // Vinculo el data a la lista filtrada
                                DataPersonas.ItemsSource = listaPersonas.OrderByDescending(persona => persona.Edad);

                            }
                            break;
                        }

                    default:
                        {
                            break;
                        }

                }

            }
        }
    }
}
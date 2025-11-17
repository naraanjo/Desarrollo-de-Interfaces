using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Persona
    {
        private String nombre;
        private String apellidos;
        private int edad;

        // Creacion del constructor automatico - click dereche sobre la clase |-> acciones rapidasa
        public Persona(string nombre, string apellidos, int edad)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
        }

        // Getters y seter auttomaticos |-> click derecho sobre cada atributo
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}

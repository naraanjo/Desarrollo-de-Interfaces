using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltradoPersonas
{
    class Persona
    {

        private String nombre;
        private String apellidos;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }

        public Persona(string nombre, string apellidos, int edad)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
        }

      
    }
}

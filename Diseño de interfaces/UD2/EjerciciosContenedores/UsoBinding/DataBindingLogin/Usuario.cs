using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32._Rellenado_ComboBox
{
    class Usuario
    {
        public string Login { get; set; } // Implementamos métodos getter y setter
        public string Passw { get; set; }

        // Constructor
        public Usuario(String Login, String Passw)
        {
            this.Login = Login;
            this.Passw = Passw;
        }

        // Sobrecargamos el método ToString
        public override string ToString()
        {
            return Login + " " + Passw;
        }

        // Metodo para añadir usuario al desplegable

    }
}
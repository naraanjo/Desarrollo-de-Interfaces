namespace PreparacionExamen1
{
    internal class PersonaBase
    {
        private String apellidos;
        private int edad;
        private String nombre;
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }

        public string Nombre { get => nombre; set => nombre = value; }
    }
}
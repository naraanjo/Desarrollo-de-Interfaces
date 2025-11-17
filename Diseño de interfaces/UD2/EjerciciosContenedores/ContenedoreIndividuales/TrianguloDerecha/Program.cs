namespace trianguloDerecha
{
    class program
    {

        static void Main()
        {

            List<List<int>> tablero = new List<List<int>>();

            rellenarTablero(tablero);
            realizarEjercicio(tablero);
            imprimirTablero(tablero);


        }
        public static void rellenarTablero(List<List<int>> tablero)
        {


            // Inicio el tablero con ceros
            for (int f = 0; f < 8; f++)
            {
                List<int> filaAñadir = new List<int>();
                for (int c = 0; c < 8; c++)
                {
                    filaAñadir.Add(0);
                }
                tablero.Add(filaAñadir);

            }

        }

        public static void realizarEjercicio(List<List<int>> tablero)
        {

            for (int f = 0; f < 8; f++)
            {


                for (int c = f; c < 8; c++)
                {
                    tablero[f][c] = c+1;

                }
            }

        }


        public static void imprimirTablero(List<List<int>> tablero)
        {


            // Inicio el tablero con ceros
            for (int f = 0; f < 8; f++)
            {
                List<int> filaAñadir = new List<int>();
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(tablero[f][c]);
                }

                Console.WriteLine();
            }

        }

    }
}
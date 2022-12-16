using System;
using System.Collections.Generic;
namespace TrypleCyber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coincidencias();

        }

        //1 Lista de numeros aleatorios 
        public static void NumerosAleatorios()
        {
            const int min = 1;
            const int max = 100;
            const int cantidadPorDefecto = 5;

            List<int> aleatorios = new List<int>();
            var random = new Random();

            Console.WriteLine("Introduce un numero");
            int numero;

            int.TryParse(Console.ReadLine(), out numero);

            if (numero > 20 || numero <= 0)
                numero = cantidadPorDefecto;

            while (aleatorios.Count < numero)
            {
                int numeroRandom = random.Next(min, max + 1);
                if (!aleatorios.Any(x => x == numeroRandom))
                    aleatorios.Add(numeroRandom);
            }

            aleatorios.ForEach((x) => Console.Write(x + " "));
        }

        //2 Numeros primos

        public static void NumeroPrimos()
        {
            int numero;
            int i = 2;
            List<int> numerosPrimos = new List<int>();

            Console.WriteLine("Introduce un numero");
            int.TryParse(Console.ReadLine(), out numero);

            if (numero <= 0)
                numero = 9;

            while (numerosPrimos.Count < numero)
            {
                if (EsPrimo(i))
                {
                    numerosPrimos.Add(i);
                }
                i++;
            }
            numerosPrimos.ForEach((x) => Console.Write(x + " "));

        }

        public static bool EsPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        // Emulador de Cajero automático

        public static void CajeroAutomatico()
        {
            Console.Write("Introduzca un numero: ");
            int cantidad = int.Parse(Console.ReadLine());

            Dictionary<int, int> billetes = new Dictionary<int, int>();
            while (cantidad >= 1)
            {
                int denominacion;

                if (cantidad > 2000) denominacion = 2000;
                else if (cantidad > 1000) denominacion = 1000;
                else if (cantidad > 500) denominacion = 500;
                else if (cantidad > 200) denominacion = 200;
                else if (cantidad > 100) denominacion = 100;
                else if (cantidad > 50) denominacion = 50;
                else if (cantidad > 10) denominacion = 10;
                else if (cantidad > 5) denominacion = 5;
                else denominacion = 1;

                cantidad -= denominacion;
                int valorDiccionario;
                try
                {
                    valorDiccionario = billetes[denominacion];
                }
                catch
                {
                    billetes.Add(denominacion, 0);
                    valorDiccionario = 0;
                }

                billetes[denominacion] = valorDiccionario + 1;
            }

            foreach (KeyValuePair<int, int> billete in billetes)
            {
                Console.WriteLine(billete.Key + " : " + billete.Value);
            }
        }

        // 4. Coincidencias

        public static void Coincidencias()
        {
            List<int> aleatorios = new List<int>();
            var random = new Random();
            for (int i = 1; i < 20; i++)
            {
                int numeroRandom = random.Next(1, 100);
                if (!aleatorios.Any(x => x == numeroRandom))
                    aleatorios.Add(numeroRandom);
            }

            List<int> primos = new List<int>();
            primos = aleatorios.Where(x => EsPrimo(x)).ToList();
            int numeroMaximo = primos.Max();

            int a, b, aux;
            a = 0;
            b = 1;

            for (int i = 0; i < numeroMaximo; i++)
            {
                aux = a;
                a = b;
                b = aux +a;

                Console.Write(a +" ");
            }
        }
    }
}
//Madelin Sanchez Cuevas
//20242511

namespace Numero_par_o_impar
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;
            Console.Write("Escribe un numero: ");
            numero = int.Parse(Console.ReadLine());

            if (numero % 2 == 0)
            {
                Console.WriteLine("El numero es par");
            }
            else
            {
                Console.WriteLine("El numero es impar");
            }

            Console.ReadKey();
        }
    }
}

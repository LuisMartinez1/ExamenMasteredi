using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMasteredi.Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arreglo = new int[] { 4, 5, 9, 13, 1, 10 };
            EncuentraSuma(arreglo);
            Console.ReadLine();
        }

        private static void EncuentraSuma(int[] arreglo)
        {
            for(var i = 0 ; i <= arreglo.Length - 1; i++)
            {
                for (var j = 0; j <= arreglo.Length - 1; j++)
                {
                    if((arreglo[i] + arreglo[j]) == 14)
                    {
                        Console.WriteLine("La suma de " + arreglo[i] + " + " + arreglo[j] + " es igual a 14 ===========");
                    }
                }
            }
        }
    }
}

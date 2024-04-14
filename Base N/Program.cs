using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumar
{
    internal class Program
    {
        static void Main()
        {
            int n;
            Console.WriteLine("¿Cuantos número desea sumar?");
            n=int.Parse(Console.ReadLine());
            String temporal;
            List<String> decimales=new List<String>(),numeros= new List<String>();
            for(int i=0;i<n;i++)
            {
                Console.Write($"Ingrese el {i+1}.- número: ");
                temporal=Console.ReadLine();
                if(temporal.Contains(','))
                {
                    int coma=temporal.IndexOf(',');
                    numeros.Add(temporal.Substring(0,coma));
                    decimales.Add(temporal.Substring(coma+1));
                }
                else
                {
                    numeros.Add(temporal);
                }
            }
            Console.Write("La base numérica de todos esos números: ");
            n = int.Parse(Console.ReadLine());
            temporal = "";
            if(decimales.Count>0)
            {
                decimales.Sort((x, y) => x.Length.CompareTo(y.Length));
                decimales.Reverse();
                for (int i = 1; i < decimales.Count; i++)
                    while (decimales[i].Length < decimales[0].Length)
                        decimales[i] += '0';
                temporal =Respuesta(decimales, 1, n);
                if (temporal.Length > decimales[0].Length)
                {
                    numeros.Add(temporal.Substring(0, temporal.Length - decimales[0].Length));
                    temporal =temporal.Substring(temporal.Length - decimales[0].Length);
                }
                temporal = ',' + temporal;
            }
            numeros.Sort((x, y) => x.Length.CompareTo(y.Length));
            numeros.Reverse();
            for(int i=1;i<numeros.Count;i++)
                while (numeros[i].Length < numeros[0].Length)
                    numeros[i] = "0"+ numeros[i];
            temporal = Respuesta(numeros, 1, n) + temporal;
            Console.WriteLine($"La respuesta es:\n{temporal}");
            Console.WriteLine("¿Desea continuar?\nSí\t(1)\nNo\tCualquier número");
            n = byte.Parse(Console.ReadLine());
            if (n == 1)
                Main();
        }
        private static String Respuesta(List<String> sumandos,int indice, int Base)
        {
            String respuesta = "";
            int contador = 0;
            for(int j = sumandos[0].Length-1;j>=0;j--)
            {
                int suma = contador;
                for (int i = 0; i < sumandos.Count; i++)
                {
                    if (sumandos[i][j] >= 'A' && sumandos[i][j] <= 'Z')
                        suma += sumandos[i][j] - 55;
                    else
                        suma += int.Parse($"{sumandos[i][j]}");
                }
                for (contador = 0; suma >= Base; contador++)
                    suma -= Base;
                if (suma >= 10)
                    respuesta += $"{(char)(suma + 55)}";
                else
                    respuesta += suma;
            }
            if (contador >= 10)
                respuesta += $"{(char)(contador + 55)}";
            else if (contador != 0)
                respuesta += contador;
            return new string(respuesta.Reverse().ToArray()); ;
        }
    }
}

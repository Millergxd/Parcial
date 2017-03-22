using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace ConsoleApplication2
{
    class Program
    {
        public static void maximaGanancia(int [][] matriz, int capacidad)
        {
            int mayorGanancia = 0;
            int maximaCapacidad = 0;
            int aux = 0;
            int aux2 = 0;
            int producto = 0;
            int[][] matrizAux = null;
            int []vecAux = null;
            vecAux =new int [3];
            matrizAux = new int[matriz.Length][];
            for (int i = 0; i < matriz.Length; i++)
            {
                matrizAux[i] = new int[4];
            }
            for (int i = 0; i < matrizAux.Length; i++)
            {
                for(int j = 0; j < matrizAux[i].Length; j++)
                {
                    if (j == 0)
                    {
                        while (true)
                        {
                            if (capacidad >= maximaCapacidad + matriz[i][j])
                            {
                                maximaCapacidad += matriz[i][j];
                                aux++;
                            }
                            else
                                break;
                        }
                        matrizAux[i][j] = maximaCapacidad;
                    }
                    if (j == 1)
                    {
                        while (aux>aux2)
                        {
                            mayorGanancia += matriz[i][j];
                            aux2++;
                        }
                        matrizAux[i][j] = mayorGanancia;
                    }
                    if( j == 2)
                    {
                        matrizAux[i][j] = i;
                    }
                    if(j == 3)
                    {
                        matrizAux[i][j] = aux;
                    }
                }
            }
            for (int i = 0; i < matrizAux.Length; i++ )
            {
                if (i + 1 < matrizAux.Length)
                {
                    if (matrizAux[i][1] < matrizAux[i + 1][1])
                    {
                        for (int j = 0; j < matriz[i].Length; j++)
                        {
                            vecAux[j] = matrizAux[i + 1][j];
                        }
                        for (int j = 0; j < matriz[i].Length; j++)
                        {
                            matrizAux[i][j] = matrizAux[i + 1][j];
                        }
                    }
                }
            }
            Console.WriteLine(matrizAux[0][1]);
            for (int i = 0; i < matrizAux.Length; i++)
            {
                if(i == matrizAux[0][2])
                {
                    Console.WriteLine(matrizAux[0][3]);
                }
                else
                    Console.WriteLine("0");
               
            } 
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int[][] matriz = null;
            int capacidad = 0;
            int productos = 0;
            char delimiter = ' ';
            String lineAux = null;
            String route = "C:\\Users\\william.munoz\\Desktop\\Parcial\\Projects\\ConsoleApplication2\\ConsoleApplication2\\bodega.in";
            String[] subStrings = null;
            file entrada = new file(route);
            entrada.openFile();
            lineAux = entrada.getLine();
            subStrings = lineAux.Split(delimiter);
            capacidad = Int32.Parse(subStrings[0]);
            productos = Int32.Parse(subStrings[1]);
            matriz = new int [productos][];
            for (int i = 0; i < productos; i++ )
            {
                matriz[i]= new int[2];
            }
            for (int i = 0; i < productos; i++)
            {
                lineAux = entrada.getLine();
                subStrings = lineAux.Split(delimiter);
                for (int j = 0; j < matriz[i].Length; j++ )
                {
                    matriz[i][j] = Int32.Parse(subStrings[j]);
                }
            }
            maximaGanancia(matriz, capacidad);
        }
    }
}
// Clase para Abrir y Cerrar un Archivo en modo Lectura
public class file
{
    StreamReader txt;
    String nombreArchivo;
    // Constructor con un parametro para asignar nombre
    public file(String nombreA)
    {
        this.nombreArchivo = nombreA;
    }
    // Abrir el Archivo
    public void openFile()
    {
        txt = new StreamReader(nombreArchivo);
    }
    // Cerrar el Archivo
    public void closedFile()
    {
        txt.Close();
    }
    // Agarrar una linea del archivo 
    public String getLine()
    {
        String Line = null;
        if (txt.EndOfStream)
        {
            Console.WriteLine("Es el final del Archivo");
            return Line;
        }
        Line = txt.ReadLine();
        return Line;
    }
}
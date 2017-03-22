using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        public static void SoladadosPerdidos (int[][] matriz)
        {
            bool solo = false;
            int aux = 0;
            Console.WriteLine("Matriz"+ ++aux);
            for (int i = 0; i < matriz.Length; i ++ )
            {
                for (int j = 0; j < matriz[i].Length; j++ )
                {
                    if ( matriz[i][j]==1 )
                    {            
                        if( matriz[i].Length > j + 1 )
                        {
                            if(matriz[i][j + 1] == 1 )
                            {
                                solo = true;
                            }
                        }
                        if ( j - 1 >= 0 )
                        {
                            if (matriz[i][j - 1] == 1)
                            {
                                solo = true;
                            }
                            
                        }
                        if ( matriz.Length > i + 1 )
                        {
                            if ( matriz[i + 1][j] == 1 )
                            {
                                solo = true;
                            }
                            
                        }
                        if ( i - 1 >= 0)
                        {
                            if (matriz[i - 1][j] == 1)
                            {
                                solo = true;
                            }
                        }
                        if (!solo)
                        {
                            Console.WriteLine(i + " " + j);
                        }
                    }
                   
                }
                if (solo)
                {
                    Console.WriteLine("ninguno");
                }
                solo = false;
            }
            
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[][] matriz;
            int casoPrueba = 0;
            int[] sizeMatriz = null; 
            String lineAux = null;
            char delimiter = ' ';
            String[] sizeM = null;
            String route = "C:\\Users\\william.munoz\\Documents\\Visual Studio 2012\\Projects\\ConsoleApplication1\\ConsoleApplication1\\soldados.in";
            file entrada = new file(route);
            entrada.openFile();
            lineAux = entrada.getLine();
            casoPrueba = Int32.Parse(lineAux);
            for (int i = 0; i < casoPrueba; i++ )
            {
                lineAux = entrada.getLine();
                sizeM = lineAux.Split(delimiter);
                sizeMatriz = new int[2];
                sizeMatriz[0] = Int32.Parse(sizeM[0]);
                sizeMatriz[1] = Int32.Parse(sizeM[1]);
                matriz = new int[sizeMatriz[0]][];
                for (int j = 0; j < sizeMatriz[0]; j++ )
                {
                    matriz[j] = new int[sizeMatriz[1]];
                }
                sizeM = null;
                for (int j = 0; j < matriz.Length; j++ )
                {
                    lineAux = entrada.getLine();
                    sizeM = lineAux.Split(delimiter);
                    for (int k = 0; k < matriz[j].Length; k++ )
                    {
                        matriz[j][k] = Int32.Parse(sizeM[k]);
                    }
                }
                SoladadosPerdidos(matriz);
                matriz = null;
            }
            Console.ReadKey();
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
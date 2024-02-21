

using System.Security.Cryptography.X509Certificates;

namespace Graphs
{
    public class GraphMatrix
    {

        public static int CountEdges(int[,] aMatrix)
        {
            int edges = 0;

            for (int i = 0; i < aMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (aMatrix[i, j] != 0)
                        edges++;
                }
            }

            return edges;
        }

        public static bool IsEmpty(int[,] a2DArray, bool aPrint = false)
        {
            bool is_empty = true;

            for (int i = 0; i < a2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < a2DArray.GetLength(1); j++)
                {
                    is_empty &= a2DArray[i, j] == 0;
                }
            }

            if (aPrint)
            {
                Console.WriteLine("Is empty: " + is_empty);
            }

            return is_empty;
        }
    }



    public class Adjacency : GraphMatrix
    {
        public static int[,] Init(int aPoints, int aEdges = int.MaxValue, bool aOneWay = false)
        {
            int[,] adj_matrix = new int[aPoints, aPoints];
            Random rnd = new Random();

            int min = aOneWay ? -1 : 0;

            while (CountEdges(adj_matrix) != aEdges)
            {
                int created_edges = 0;

                for (int col = 0; col < aPoints; col++)
                {
                    for (int row = 0; row < col; row++)
                    {
                        adj_matrix[col, row] = aEdges - created_edges > 0 ? rnd.Next(min, 2) : 0;

                        if (adj_matrix[col, row] != 0)
                        {
                            created_edges++;
                        }

                        if (aOneWay)
                        {
                            adj_matrix[row, col] = 0 - adj_matrix[col, row];
                        }
                        else
                        {
                            adj_matrix[row, col] = adj_matrix[col, row];
                        }

                    }
                    adj_matrix[col, col] = 0;
                }
            }


            return adj_matrix;
        }
    }

    public class Incidence : GraphMatrix
    {
        public static int[,] Init(int aPoints, int aEdges = int.MaxValue, bool aOneWay = false)
        {
            int[,] adj_matrix = new int[aPoints, aPoints];
            Random rnd = new Random();

            int min = aOneWay ? -1 : 0;

            while (CountEdges(adj_matrix) != aEdges)
            {
                int created_edges = 0;

                for (int col = 0; col < aPoints; col++)
                {
                    for (int row = 0; row < col; row++)
                    {
                        adj_matrix[col, row] = aEdges - created_edges > 0 ? rnd.Next(min, 2) : 0;

                        if (adj_matrix[col, row] != 0)
                        {
                            created_edges++;
                        }

                        if (aOneWay)
                        {
                            adj_matrix[row, col] = 0 - adj_matrix[col, row];
                        }
                        else
                        {
                            adj_matrix[row, col] = adj_matrix[col, row];
                        }

                    }
                    adj_matrix[col, col] = 0;
                }
            }


            return adj_matrix;
        }
    }

    internal class Program
    {

        public static void PrintMatrix(int[,] aMatrix)
        {
            Console.WriteLine("Printing matrix:");

            for (int i = 0; i < aMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < aMatrix.GetLength(1); j++)
                {
                    Console.Write(aMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //// Pobranie liczby wierzchołków
            //Console.WriteLine("Podaj liczbę wierzchołków:");
            //int no_points = int.Parse(Console.ReadLine());

            //int no_edges = -1;

            ////// Pobranie liczby krawędzi
            //while (no_edges < 0 || no_edges > ((no_points * (no_points - 1)) / 2))
            //{
            //    Console.WriteLine("Podaj liczbę krawędzi:");
            //    no_edges = int.Parse(Console.ReadLine());
            //}

            //// Generowanie macierzy sąsiedztwa
            //var adj = Adjacency.Init(no_points, no_edges);
            //PrintMatrix(adj);
            //Adjacency.IsEmpty(adj, true);
            //Console.WriteLine("Liczba krawędzi: " + Adjacency.CountEdges(adj));

            var adj = new int[,] {  {0, 1, 1, 0, 0, 0},
                                    {1, 0, 1, 1, 0, 0}, 
                                    {1, 1, 0, 0, 1, 0}, 
                                    {0, 1, 0, 0, 0, 1}, 
                                    {0, 0, 1, 0, 0, 0}, 
                                    {0, 0, 0, 1, 0, 0} };

            Graph graf = Graph.FromMatrix(adj);
            graf.Print();

            Console.WriteLine();
            graf.BFS(1);
         }
    }
}

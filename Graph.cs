using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Castle.Core;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;


namespace Graphs
{
    public class Graph
    {
        private Graph() { }

        public static Graph FromMatrix(int[,] aGraphMatrix)
        {
            var graph = new Graph();
            graph.mEdges = new List<int>[aGraphMatrix.GetLength(0)];

            for (int i = 0; i < aGraphMatrix.GetLength(0); i++)
            {
                List<int> reaching_nodes = new List<int>();

                for (int j = 0; j < aGraphMatrix.GetLength(1); j++)
                {
                    if (aGraphMatrix[i, j] == 0)
                        continue;

                    reaching_nodes.Add(j);
                }

                graph.mEdges[i] = reaching_nodes;
            }

            return graph;
        }

        public void Print()
        {
            if (mEdges == null)
            {
                Console.WriteLine("Empty graph");
            }
            else if (mEdges.Length > 0) 
            {
                Console.WriteLine("Printing graph");

                string nodes = "", edges = "";

                for (int i = 0;i < mEdges.Length;i++)
                {
                    nodes += i == mEdges.Length - 1 ? i.ToString() : i.ToString() + "\n";
                    edges += i + " -> ";

                    foreach (var item in mEdges[i])
                    {
                        edges += item.ToString() + " ";
                    }
                    edges += "\n";
                }

                Console.WriteLine(nodes);
                Console.WriteLine(edges);
            }
        }

        public void BFS(int aStartNode)
        {
            Console.WriteLine($"Performing BFS search starting with {aStartNode+1}");

            bool[] visited = new bool[mEdges.Length];
            Queue<int> queue = new Queue<int>();

            visited[aStartNode] = true;
            queue.Enqueue(aStartNode);

            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                string text = $"{node + 1 }";
                Console.Write(text + " ");

                foreach (int nextNode in mEdges[node])
                {
                    if (!visited[nextNode])
                    {
                        visited[nextNode] = true;
                        queue.Enqueue(nextNode);
                    }
                }
            }
        }

        public void DFS(int aStartNode)
        {
            bool[] visited = new bool[mEdges.Length];
            Stack<int> stack = new Stack<int>();

            visited[aStartNode] = true;
            stack.Push(aStartNode);

            while (stack.Any())
            {
                int node = stack.Pop();
                //node + 1 -> numeracja na stronie jest od 1
                Console.Write((node + 1).ToString() + " ");

                mEdges[node].Reverse();
                foreach (var next_node in mEdges[node])
                {
                    if (visited[next_node])
                    { continue; }

                    visited[next_node] = true;
                    stack.Push(next_node);
                }
            }
        }

        public List<int>[] mEdges;
    }
}

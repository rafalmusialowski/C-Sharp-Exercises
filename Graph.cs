using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Castle.Core;


namespace Graphs
{
    public class Graph
    {
        private Graph() { }

        public static Graph FromMatrix(int[,] aGraphMatrix)
        {
            var graph = new Graph();

            for (int i = 0; i < aGraphMatrix.GetLength(0); i++)
            {
                var reaching_nodes = new List<int>();

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

        public List<int>[] mEdges;
    }
}

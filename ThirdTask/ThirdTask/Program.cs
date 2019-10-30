using System;
using System.Collections.Generic;

namespace ThirdTask
{
    public class Graph
    {
        int[,] residualCapacity;
        int s, t;
        public Graph()
        {

        }
        public Graph(int[,] residualCapacity)
        {
            this.residualCapacity = residualCapacity;
            this.s = 0;
            this.t = Convert.ToInt32(Math.Sqrt(residualCapacity.Length));
        }
        public int[,] getResidualCapacity()
        {
            return residualCapacity;
        }
        bool bfs(int []parent) 
        {
            int N = Convert.ToInt32(Math.Sqrt(residualCapacity.Length));
            bool[] visited = new bool[N];
            for (int i = 0; i < N; ++i) //initialization all vertices as not visited
            {
                visited[i] = false;
            }
            List<int> queue = new List<int>();
            queue.Add(s); //Adding stock to queue 
            visited[s] = true; //Marking stock as visited
            parent[s] = -1;

            while(queue.Count != 0)
            {
                //Tacking first item from he queue
                int u = queue[0]; //This will be first vertices
                queue.RemoveAt(0); 
                for (int v = 0; v < N; v++)
                {
                    //If we current vertices isn't visited, and free path from first vertices to current exist 
                    if (visited[v] == false && residualCapacity[u, v] > 0)
                    {
                        queue.Add(v); //Adding this vertices to the queue
                        parent[v] = u; //Rembering the path 
                        visited[v] = true; //Marking it as visited
                    }
                }
            }
            return visited[t] == true;
        }
        public int fordFulkerson()
        {
            int u, v;
            int N = Convert.ToInt32(Math.Sqrt(residualCapacity.Length));
            int[] parent = new int[N];
            int maxFlow = 0;
            while(bfs(parent)) //While there is a path from source to sink
            {
                int path_flow = int.MaxValue;
                //Finding the maximum flow through current path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, residualCapacity[u, v]); 
                }
                //Changing the residual capacity through current path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    residualCapacity[u, v] -= path_flow; //Reducing the capacity through the path we found
                    residualCapacity[v, u] += path_flow; //Increasing the capacity of reverse path
                }
                maxFlow += path_flow;
            }
            return maxFlow;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*int[,] graphMatrix = { {0, 16, 13, 0, 0, 0},
                                    {0, 0, 10, 12, 0, 0},
                                    {0, 4, 0, 0, 14, 0},
                                    {0, 0, 9, 0, 0, 20},
                                    {0, 0, 0, 7, 0, 4},
                                    {0, 0, 0, 0, 0, 0} }; */
            int[,] graphMatrix2 = { {0, 9, 8, 9, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 5, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 2, 5, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 4, 0, 3, 0, 0, 6, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 5, 0, 5, 0, 3, 5, 0, 0, 0}, 
                                    {0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 0, 7, 0, 0},
                                    {0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 7},
                                    {0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 1, 6},
                                    {0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 9},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            int[,] graphMatrix3 = { {0, 1000, 1000, 0},
                                    {0, 0, 1, 1000},
                                    {0, 0, 0, 1000},
                                    {0, 0, 0, 0 } };
            //Graph newgraph = new Graph(graphMatrix);
            Graph newgraph2 = new Graph(graphMatrix2);
            //Console.WriteLine(newgraph.fordFulkerson());
            Console.WriteLine(newgraph2.fordFulkerson());
            Graph newgraph3 = new Graph(graphMatrix3);
            Console.WriteLine(newgraph3.fordFulkerson());
        }
    }
}

using System;
using System.Collections.Generic;

namespace ThirdTask
{
    //Interface for Flow
    public interface IFlow
    {
        //Define finding maximum flow functional
        int findMaxFlow();
    }
    public class Graph: IFlow
    {
        //Matrix of residual capacity
        public int[,] residualCapacity { get; }
        //Unique vertex
        private Vertex s, t;
        //Constructor from matrix parameter
        public Graph(int[,] residualCapacity)
        {
            int n = residualCapacity.GetLength(0);
            this.residualCapacity = new int[n, n];
            //Copying values from given matrix
            Array.Copy(residualCapacity, 0 ,this.residualCapacity, 0, residualCapacity.Length);
            this.s = new Vertex("S", 0);
            this.t = new Vertex("T",
                Convert.ToInt32(Math.Sqrt(residualCapacity.Length)) - 1);
        }
        bool bfs(int []parent) 
        {
            int N = residualCapacity.GetLength(0);
            bool[] visited = new bool[N];
            for (int i = 0; i < N; ++i) //initialization all vertices as not visited
            {
                visited[i] = false;
            }
            List<int> queue = new List<int>();
            queue.Add(s.position); //Adding stock to queue 
            visited[s.position] = true; //Marking stock as visited
            parent[s.position] = -1;

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
            return visited[t.position] == true;
        }
        public int findMaxFlow()
        {
            int u, v;
            int N = residualCapacity.GetLength(0);
            int[] parent = new int[N];
            int maxFlow = 0;
            while(bfs(parent)) //While there is a path from source to sink
            {
                int path_flow = int.MaxValue;
                //Finding the maximum flow through current path
                for (v = t.position; v != s.position; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, residualCapacity[u, v]); 
                }
                //Changing the residual capacity through current path
                for (v = t.position; v != s.position; v = parent[v])
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

    class Vertex {
        public string name {get;} //Name of unique vertex
        public int position {get;} //Position of unique vertex
        //Constructor by default
        public Vertex() {
            name = "";
            position = 0;
        }
        //Constructor from name and position parameters
        public Vertex(string name, int position) {
            this.name = name;
            this.position = position;
        }
    }
    class Program
    {

    }
    
}

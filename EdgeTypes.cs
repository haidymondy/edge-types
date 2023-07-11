using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class EdgeTypes
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Detect & count the edge types of the given UNDIRECTED graph by applying COMPLETE-DFS on the entire graph 
        /// NOTE: during search, break ties (if any) by selecting the verices in ASCENDING numeric order
        /// </summary>
        /// <param name="vertices">array of vertices in the graph (named from 0 to |V| - 1)</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <returns>return array of 3 numbers: res[0] number of backward edges, res[1] number of forward edges, res[2] number of cross edges</returns>
        
         public static int[] DetectEdges(int[] vertices, KeyValuePair<int, int>[] edges)

        {
          
            bool[] viseted_vert = new bool[vertices.Length];
            List<int>[] adj = new List<int>[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
                adj[i] = new List<int>();

            foreach (KeyValuePair<int, int> edge in edges)
            {
                adj[edge.Key].Add(edge.Value);
                adj[edge.Value].Add(edge.Key);
            }

            int[] res = new int[3];
            for (int i = 0; i < vertices.Length; i++)
            {
                if (viseted_vert[i])
                    continue;
                dfs(i, adj, viseted_vert, -1, res);
            }

            return res;
        }

        public static void dfs(int vertex, List<int>[] adj, bool[] viseted_vert, int parent, int[] res)
        {
            viseted_vert[vertex] = true;

            foreach (int neighbor in adj[vertex])
            {
                if (neighbor == parent)
                    continue;
                if (!viseted_vert[neighbor])
                    dfs(neighbor, adj, viseted_vert, vertex, res);

                else
                {
                    int vertexIndex = vertex;
                    int neighborIndex = neighbor;

                    switch (neighborIndex.CompareTo(vertexIndex))
                    {
                        case -1:
                            res[0]++; // backward edge
                            break;
                        case 1:
                            res[1]++; // forward edge
                            break;
                        default:
                            res[2]++; // cross edge
                            break;
                    }
                }
            }
        }

        #endregion
    }
}

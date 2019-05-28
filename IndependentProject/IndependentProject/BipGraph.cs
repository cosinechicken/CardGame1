using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject
{
    // Code adapted from https://www.geeksforgeeks.org/hopcroft-karp-algorithm-for-maximum-matching-set-2-implementation/
    // BipGraph is abbreviation for Bipartite graph
    // Note: 1-based indices used for the vertices, be sure to convert in Play.xaml.cs!!!
    class BipGraph
    {
        // Number of vertices on the left side of the graph
        private int m;
        // Number of vertices on the right side of the graph
        private int n;
        // adj[u] is the list of vertices adjacent to u, including 0, the dummy vertex
        public List<int>[] adj;
        // pairU[u] is the vertex on the right side of the graph, connected to u on the left side
        int[] pairU;
        // pairV[v] is the vertex on the left side of the graph, connected to v on the right side
        int[] pairV;
        int[] dist;
        // Constructor
        public BipGraph(int m, int n)
        {
            this.m = m;
            this.n = n;
            adj = new List<int>[m + 1];
            for (int i = 0; i <= m; i++)
            {
                adj[i] = new List<int>();
            }
        }
        // Add an edge from u to v and v to u, avoiding duplicates
        public void AddEdge(int u, int v)
        {
            if (!adj[u].Contains(v))
            {
                adj[u].Add(v);
            }
        }
        // Clear vertex u's edges
        public void ClearVertex(int u)
        {
            adj[u] = new List<int>();
        }
        // Clear vertex v's edges where v is on the right
        // This is used because once a card is selected to be a certain number, other cards cannot also be that number
        public void ClearVertexRight(int v)
        {
            for (int i = 0; i <= 2*m; i++)
            {
                if (adj[i].Contains(v))
                {
                    adj[i].Remove(v);
                }
            }
        }

        // Checks to see if the two vertices are connected by a pair of edges
        public Boolean hasEdge (int u, int v)
        {
            return adj[u].Contains(v);
        }
        // Runs Hopcroft-Karp algorithm, returns pairU
        public int[] HopcroftKarp()
        {
            pairU = new int[m + 1];
            pairV = new int[n + 1];
            dist = new int[m + 1];
            for (int u = 0; u < m+1; u++)
            {
                pairU[u] = 0;
            }
            for (int v = 0; v < n+1; v++)
            {
                pairV[v] = 0;
            }
            int result = 0;
            int count = 0;
            while (HasAugmentingPath())
            {
                for (int u= 1; u <= m; u++)
                {
                    // Finding an augmenting path starting from u on the left side of the graph
                    if (pairU[u] == 0 && dfs(u))
                    {
                        result++;
                    }
                }
                count++;
                if (count == 10000)
                {
                    // Test
                    throw new Exception();
                }
            }
            return pairU;
        }
        // Returns true if there is an augmenting path (alternating path starting and ending with free vertex), false otherwise
        private bool HasAugmentingPath()
        {
            Queue<int> queue = new Queue<int>();
            // First layer of vertices
            for (int u = 1; u <= m; u++)
            {
                // If it's a free vertex, add it to the queue
                if (pairU[u] == 0)
                {
                    dist[u] = 0;
                    queue.Enqueue(u);
                } else
                {
                    dist[u] = Int32.MaxValue;
                }
            }
            dist[0] = Int32.MaxValue;
            // queue contains vertices from the left side only
            while (queue.Count != 0)
            {
                // Dequeue a vertex
                int u = queue.Dequeue();
                if (dist[u] < dist[0])
                {
                    foreach (int i in adj[u])
                    {
                        // If the pair of i is not considered then the distance to pairV[i] is infinite, and (i, pairV[i]) is not an explored edge
                        if (dist[pairV[i]] == Int32.MaxValue)
                        {
                            dist[pairV[i]] = dist[u] + 1;
                            queue.Enqueue(pairV[i]);
                        }
                    }
                }
            }
            return dist[0] != Int32.MaxValue;
        }
        // Returns true if there exists an augmenting path beginning with free vertex u
        private bool dfs(int u)
        {
            if (u != 0)
            {
                foreach (int i in adj[u])
                {
                    if (dist[pairV[i]] == dist[u] + 1)
                    {
                        if (dfs(pairV[i]))
                        {
                            pairV[i] = u;
                            pairU[u] = i;
                            return true;
                        }
                    }
                }
                dist[u] = Int32.MaxValue;
                return false;
            }
            return true;
        }
    }
}

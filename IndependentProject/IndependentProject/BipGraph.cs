﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject
{
    // Code adapted from https://www.geeksforgeeks.org/hopcroft-karp-algorithm-for-maximum-matching-set-2-implementation/, adapted 5/27/19, lines 14-161
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
        public void ClearEdge(int u, int v)
        {
            if (adj[u].Contains(v))
            {
                adj[u].Remove(v);
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
            while (HasAugmentingPath())
            {
                // Shuffle the order in which the cards are chosen for dfs, to randomize the cards
                List<int> order = new List<int>();
                for (int i = 1; i <= m; i++)
                {
                    order.Add(i);
                }
                Shuffle(order);
                for (int u = 0; u < m; u++)
                {
                    // Finding an augmenting path starting from u on the left side of the graph
                    if (pairU[order[u]] == 0 && dfs(order[u]))
                    {
                        result++;
                    }
                }
            }
            return pairU;
        }
        // Returns true if there is an augmenting path (alternating path starting and ending with free vertex), false otherwise
        private bool HasAugmentingPath()
        {
            // For randomness, we shuffle the cards before each dequeue
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
                // To randomize order adjacent vertices get visited in
                Shuffle(adj[u]);
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

        // Shuffling a list, code from https://stackoverflow.com/questions/273313/randomize-a-listt, copied 5/28/19, lines 164-176
        private void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            Random rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

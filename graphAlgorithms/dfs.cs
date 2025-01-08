using System;
using System.Collections.Generic;

public class Graph
{
    // gonna use an adjacency list to represent the graph. Each key is a node, and the value is a list of nodes that are connected to it. so neighbors = values of the key.
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    /// <summary>
    /// adds an edge between two nodes u and v.
    /// for undirected graphs, we add an edge in both directions: (u -> v) and (v -> u)
    /// for directed graphs, we only add an edge in one direction: (u -> v) -- removing the second line will make it directed.
    /// </summary>
    /// <param name="u"></param>
    /// <param name="v"></param>
    public void addEdge(int u, int v)
    {
        if (!adjacencyList.ContainsKey(u))
        {
            adjacencyList[u] = new List<int>();
        }
        if (!adjacencyList.ContainsKey(v))
        {
            adjacencyList[v] = new List<int>();
        }
        adjacencyList[u].Add(v); // add v to u's list of neighbors
        adjacencyList[v].Add(u); // undirected graph
    }
}
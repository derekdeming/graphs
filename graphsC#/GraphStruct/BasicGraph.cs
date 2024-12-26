using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GraphStruct
{
    public class BasicGraph
    {
        HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        #region private variables 
        // this represents directed graph impl using LinkedLists private variables 

        private int totalVertices; // num of vertices 
        private LinkedList<int>[] linkedListArray;
        #endregion

        //constructor
        public BasicGraph(int n)
        {
            totalVertices = n;
            linkedListArray = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
                linkedListArray[i] = new LinkedList<int>();
        }

        // add an edge to adjacent vertex
        public void addEdge(int vertex, int addVertex)
        {
            linkedListArray[vertex].AddLast(addVertex);
        }

        // print adjacency list representation of graph
        public void printAdjacencyList()
        {
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("Graph Representation\n");
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("The Graph Adjacency List Representation:\n");
            _httpContext.Response.WriteAsync("------------------------------------------------\n");
            StringBuilder nodeString = new StringBuilder();
            // traversing over each of the vertices - print vertex
            for (int i = 0; i < linkedListArray.Length; i++)
            {
                nodeString.Append("[Node value: " + i + " with Neighbors");
                foreach (var item in linkedListArray[i])
                {
                    nodeString.Append(" -> " + item);
                }
                nodeString.Append(i + "]\n");
            }
            _httpContext.Response.WriteAsync(nodeString.ToString());
        }

        public void CreateAdjacencyMatrix(BasicGraph graph)
        {
            int?[,] adjacencyMatrix = new int?[graph.totalVertices, graph.totalVertices];
            for (int parentVertex = 0; parentVertex < graph.totalVertices; parentVertex++)
            {
                var parentNode = linkedListArray[parentVertex];
                for (int childNode = 0; childNode < graph.totalVertices; childNode++)
                {
                    if (parentVertex != childNode)
                    {
                        var arc = parentNode.Find(childNode);
                        if (arc != null)
                        {
                            adjacencyMatrix[parentVertex, childNode] = 1;
                        }
                    }
                }
            }
            PrintAdjacencyMatrix(adjacencyMatrix, graph.totalVertices);
        }

        public void PrintAdjacencyMatrix(int?[,] adjacencyMatrix, int totalVertices)
        {
            _httpContext.Response.WriteAsync("================================================\n");
            _httpContext.Response.WriteAsync("The Graph Adjacency Matrix Representation:\n");
            _httpContext.Response.WriteAsync("------------------------------------------------\n");
            _httpContext.Response.WriteAsync("Nodes  ");
            for (int i = 0; i < totalVertices; i++)
            {
                _httpContext.Response.WriteAsync(string.Format("{0}  ", i));
            }

            _httpContext.Response.WriteAsync("\n");

            for (int i = 0; i < totalVertices; i++)
            {
                _httpContext.Response.WriteAsync(string.Format("{0} | [ ", i));

                for (int j = 0; j < totalVertices; j++)
                {
                    if (i == j)
                    {
                        _httpContext.Response.WriteAsync(" x ");
                    }
                    else if (adjacencyMatrix[i, j] == null)
                    {
                        _httpContext.Response.WriteAsync(" . ");
                    }
                    else
                    {
                        _httpContext.Response.WriteAsync(string.Format(" {0} ", adjacencyMatrix[i, j]));
                    }

                }
                _httpContext.Response.WriteAsync(" ]\r\n");
            }
            _httpContext.Response.WriteAsync("================================================\n");
        }
    }
}

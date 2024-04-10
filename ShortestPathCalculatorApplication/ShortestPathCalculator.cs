using System.Collections.Generic;
using System;
using System.Linq;
using ShortestPathCalculatorApplication.IServices;

namespace ShortestPathCalculatorApplication
{
    public class ShortestPathCalculator : IShortestPathCalculator
    {
        private readonly INodeDataService _nodeDataService;
        private static int V = 9;

        public ShortestPathCalculator(INodeDataService nodeDataService)
        {
            _nodeDataService = nodeDataService;
        }

        // Implements Dijkstra's algorithm to find the shortest path for a graph represented using adjacency matrix representation.
        public ShortestPathDto CalculateShortestPath(string startNode, string finishNode)
        {
            int[,] graph = _nodeDataService.ProvideGraph();
            int startNodeIndex = startNode.GetPosition(_nodeDataService.ProvideInitialNodes());
            int finishNodeIndex = finishNode.GetPosition(_nodeDataService.ProvideInitialNodes());

            // This array holds shortest distances from starting node to other nodes
            int[] distanceFromStartingNodeArray = new int[V];

            /* sptSet[i] will true if node i is included in shortest
             path tree or shortest distance from starting node to i is finalized */
            bool[] sptSet = new bool[V];

            // Initialize all distances as infinite and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                distanceFromStartingNodeArray[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of starting node to itself is always 0
            distanceFromStartingNodeArray[startNodeIndex] = 0;
            Dictionary<int, List<int>> paths = new Dictionary<int, List<int>>();

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance node from the set of vertices not yet processed. u is always equal to starting node in first iteration.
                int u = MinDistance(distanceFromStartingNodeArray, sptSet);

                // Mark the picked node as processed
                sptSet[u] = true;

                // Update distanceArrayFromNode value of the adjacent vertices of the picked node.
                for (int v = 0; v < V; v++)

                    /* Update distanceArrayFromNode[v] only if is not in sptSet, there is an edge from u to v, 
                     and total weight of path from starting node to v through u is smaller than current value of distanceArrayFromNode[v] */
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         distanceFromStartingNodeArray[u] != int.MaxValue && distanceFromStartingNodeArray[u] + graph[u, v] < distanceFromStartingNodeArray[v])
                    {
                        distanceFromStartingNodeArray[v] = distanceFromStartingNodeArray[u] + graph[u, v];
                        if (paths.TryGetValue(v, out List<int> numbers))
                        {
                            List<int> addingpath = null;
                            paths.TryGetValue(u, out addingpath);
                            paths.Remove(v);

                            if (addingpath.LastOrDefault() != u)
                            {
                                addingpath.Add(u);
                            }
                            paths.Add(v, addingpath);
                        }
                        else

                        {
                            List<int> existingpath = null;

                            if (paths.TryGetValue(u, out List<int> currentpath))
                            {
                                existingpath = currentpath.ToList();
                                existingpath.Add(u);
                                paths.Add(v, existingpath);
                            }
                            else
                            {
                                existingpath = new List<int>();
                                existingpath.Add(u);
                                paths.Add(v, existingpath);
                            }
                        }
                    }

            }

            List<int> path = new List<int>();
            if (paths.TryGetValue(finishNodeIndex, out path))
            {
                if (path.LastOrDefault() != finishNodeIndex)
                {
                    path.Add(finishNodeIndex);
                }
            }

            List<string> nodePath = path.Select(x => x.GetNodeValueUsingPosition(_nodeDataService.ProvideInitialNodes())).ToList();
            int shortestDistant = distanceFromStartingNodeArray[finishNodeIndex];

            ShortestPathDto shortestPathData = new ShortestPathDto(nodePath, shortestDistant);

            return shortestPathData;
        }

        // Function to find the node with minimum distance value, from the set of vertices not yet included in shortest path tree
        private int MinDistance(int[] distanceFromStartingNodeArray,
                        bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && distanceFromStartingNodeArray[v] <= min)
                {
                    min = distanceFromStartingNodeArray[v];
                    min_index = v;
                }

            return min_index;
        }
    }
}

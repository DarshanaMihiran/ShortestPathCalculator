using DijkstrasAlgorithm.Models;
using DijkstrasAlgorithm.Repositories.Interfaces;
using DijkstrasAlgorithm.Services.Interfaces;
using System.Collections.Generic;

namespace DijkstrasAlgorithm.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly INodeRepository _nodeRepository;

        // Constructor injection to get the node repository
        public CalculatorService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        // Method to find the shortest path from one node to another
        public ShortestPathData FindShortestPath(string fromNodeName, string toNodeName)
        {
            // Get all nodes from the repository
            var graphNodes = _nodeRepository.GetAllNodes();

            // Call the ShortestPath method to calculate the shortest path
            return ShortestPath(fromNodeName, toNodeName, graphNodes);
        }

        // Method to calculate the shortest path using Dijkstra's algorithm
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
        {
            // Initialization
            Dictionary<string, int> distance = new Dictionary<string, int>();  // Distance from source node to each node
            Dictionary<string, string> previous = new Dictionary<string, string>();  // Previous node in the shortest path
            HashSet<string> visited = new HashSet<string>();  // Set of visited nodes

            // Initialize distances and previous nodes
            foreach (var node in graphNodes)
            {
                distance[node.Name] = int.MaxValue;  // Initialize all distances to infinity
                previous[node.Name] = null;  // Initialize previous nodes to null
            }

            // Set the distance from the source node to 0
            distance[fromNodeName] = 0;

            // Dijkstra's algorithm
            while (visited.Count < graphNodes.Count)
            {
                // Find the node with the shortest distance
                string currentNode = null;
                int shortestDistance = int.MaxValue;
                foreach (var node in graphNodes)
                {
                    if (!visited.Contains(node.Name) && distance[node.Name] < shortestDistance)
                    {
                        currentNode = node.Name;
                        shortestDistance = distance[node.Name];
                    }
                }

                // Break if no more nodes to visit
                if (currentNode == null)
                {
                    break;
                }

                // Update distances to neighbors
                foreach (var neighbor in graphNodes.Find(n => n.Name == currentNode).Neighbors)
                {
                    int altDistance = distance[currentNode] + neighbor.Value;
                    if (altDistance < distance[neighbor.Key])
                    {
                        distance[neighbor.Key] = altDistance;
                        previous[neighbor.Key] = currentNode;
                    }
                }

                visited.Add(currentNode);
            }

            // Reconstruct the shortest path
            List<string> shortestPath = new List<string>();
            string current = toNodeName;
            while (current != null)
            {
                shortestPath.Add(current);
                current = previous[current];
            }
            shortestPath.Reverse();

            // Return the result containing the shortest path and its distance
            return new ShortestPathData
            {
                NodeNames = shortestPath,
                Distance = distance[toNodeName]
            };
        }
    }
}

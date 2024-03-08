﻿using DijkstrasAlgorithm.Models;
using DijkstrasAlgorithm.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DijkstrasAlgorithm.Controllers
{
        public class HomeController : Controller
        {
            private readonly INodeRepository _nodeRepository; 
            public HomeController(INodeRepository nodeRepository)
            {
                _nodeRepository = nodeRepository;
            }

            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CalculateShortestPath(string fromNodeName, string toNodeName)
            {
                var graphNodes = _nodeRepository.GetAllNodes();
                // Call method to calculate shortest path
                ShortestPathData shortestPathData = ShortestPath(fromNodeName, toNodeName, graphNodes);

                return Json(shortestPathData);
            }

            private ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
            {
                // Initialization
                Dictionary<string, int> distance = new Dictionary<string, int>();
                Dictionary<string, string> previous = new Dictionary<string, string>();
                HashSet<string> visited = new HashSet<string>();

                foreach (var node in graphNodes)
                {
                    distance[node.Name] = int.MaxValue;
                    previous[node.Name] = null;
                }

                distance[fromNodeName] = 0;

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

                // Return the result
                return new ShortestPathData
                {
                    NodeNames = shortestPath,
                    Distance = distance[toNodeName]
                };
            }
        }
    }

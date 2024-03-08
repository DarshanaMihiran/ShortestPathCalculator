using DijkstrasAlgorithm.Models;
using System.Collections.Generic;

namespace DijkstrasAlgorithm.Services.Interfaces
{
    public interface ICalculatorService
    {
        ShortestPathData FindShortestPath(string fromNodeName, string toNodeName);
        ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
    }
}

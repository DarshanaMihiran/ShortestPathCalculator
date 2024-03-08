using DijkstrasAlgorithm.Models;
using DijkstrasAlgorithm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstrasAlgorithm.Repositories
{
    public class NodeRepository : INodeRepository
    {
        public List<Node> GetAllNodes()
        {
            List<Node> graphNodes = new List<Node>
            {
                new Node { Name = "A", Neighbors = new Dictionary<string, int> { { "B", 5 }, { "C", 3 } } },
                new Node { Name = "B", Neighbors = new Dictionary<string, int> { { "A", 5 }, { "D", 7 } } },
                new Node { Name = "C", Neighbors = new Dictionary<string, int> { { "A", 3 }, { "D", 4 } } },
                new Node { Name = "D", Neighbors = new Dictionary<string, int> { { "B", 7 }, { "C", 4 } } }
            };
            return graphNodes;
        }
    }
}

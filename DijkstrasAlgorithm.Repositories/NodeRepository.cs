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
                new Node { Name = "A", Neighbors = new Dictionary<string, int> { { "B", 4 }, { "C", 6 } } },
                new Node { Name = "B", Neighbors = new Dictionary<string, int> { { "A", 4 }, { "F", 2 } } },
                new Node { Name = "C", Neighbors = new Dictionary<string, int> { { "A", 6 }, { "D", 8 } } },
                new Node { Name = "D", Neighbors = new Dictionary<string, int> { { "C", 8 }, { "E", 4 } ,{ "G", 1 } } },
                new Node { Name = "E", Neighbors = new Dictionary<string, int> { { "B", 2 }, { "F", 3 } ,{ "I", 8 }, { "D", 4 } } },
                new Node { Name = "F", Neighbors = new Dictionary<string, int> { { "B", 2 }, { "E", 3 } ,{ "G", 4 }, { "H", 6 } } },
                new Node { Name = "G", Neighbors = new Dictionary<string, int> { { "D", 1 }, { "I", 5 } ,{ "H", 5 }, { "F", 4 } } },
                new Node { Name = "H", Neighbors = new Dictionary<string, int> { { "F", 6 }, { "G", 5 } } },
                new Node { Name = "I", Neighbors = new Dictionary<string, int> { { "E", 8 }, { "G", 5 } } }
            };
            return graphNodes;
        }
    }
}

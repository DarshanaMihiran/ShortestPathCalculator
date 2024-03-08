using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DijkstrasAlgorithm.Models
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<string, int> Neighbors { get; set; }
    }
}
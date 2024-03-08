using DijkstrasAlgorithm.Models;    
using DijkstrasAlgorithm.Repositories.Interfaces;
using DijkstrasAlgorithm.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DijkstrasAlgorithm.Tests
{
    public class CalculatorServiceTests
    {
        private CalculatorService _calculatorService;
        public CalculatorServiceTests()
        {
            // Arrange
            var graphNodes = new List<Node>
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

            
            var nodeRepositoryMock = new Mock<INodeRepository>();
            _calculatorService = new CalculatorService(nodeRepositoryMock.Object);
            nodeRepositoryMock.Setup(repo => repo.GetAllNodes()).Returns(graphNodes);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoD()
        {            
            // Act
            var result = _calculatorService.FindShortestPath("A", "D");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "G", "D" }, result.NodeNames);
            Assert.Equal(11, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoE()
        {
            // Act
            var result = _calculatorService.FindShortestPath("A", "E");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "E" }, result.NodeNames);
            Assert.Equal(9, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoF()
        {
            // Act
            var result = _calculatorService.FindShortestPath("A", "F");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F"}, result.NodeNames);
            Assert.Equal(6, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoG()
        {
            // Act
            var result = _calculatorService.FindShortestPath("A", "G");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "G" }, result.NodeNames);
            Assert.Equal(10, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoH()
        {
            // Act
            var result = _calculatorService.FindShortestPath("A", "H");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "H" }, result.NodeNames);
            Assert.Equal(12, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_AtoI()
        {
            // Act
            var result = _calculatorService.FindShortestPath("A", "I");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "A", "B", "F", "G", "I" }, result.NodeNames);
            Assert.Equal(15, result.Distance);
        }

        [Fact]
        public void FindShortestPath_Should_Return_Shortest_Path_CtoI()
        {
            // Act
            var result = _calculatorService.FindShortestPath("C", "I");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new List<string> { "C", "D", "G", "I" }, result.NodeNames);
            Assert.Equal(14, result.Distance);
        }
    }
}

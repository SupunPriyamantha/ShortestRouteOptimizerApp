using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPathCalculatorApplication;
using System;
using System.Collections.Generic;

namespace ShortestRouteOptimizerTest
{
    [TestClass]
    public class ShortestPathCalculatorTest
    {
        private readonly NodeDataService _nodeDataService;

        public ShortestPathCalculatorTest()
        {
            _nodeDataService = new NodeDataService();
        }

        [TestMethod]
        public void Check_Given_Valid_Arguments_Return_Expected_Shortest_PathData()
        {
            ShortestPathCalculator shortestPathCalculator = new ShortestPathCalculator(_nodeDataService);

            ShortestPathDto fromBToI = shortestPathCalculator.CalculateShortestPath("B", "I");
            ShortestPathDto fromCToH = shortestPathCalculator.CalculateShortestPath("C", "H");

            fromBToI.Should().NotBeNull();
            fromBToI.NodeNames.Should().NotBeNull();
            fromBToI.Distance.Should().Be(11);
            fromBToI.NodeNames.Should().Equal(new List<string>() { "B", "F", "G", "I" });

            fromCToH.Should().NotBeNull();
            fromCToH.NodeNames.Should().NotBeNull();
            fromCToH.Distance.Should().Be(14);
            fromCToH.NodeNames.Should().Equal(new List<string>() { "C", "D", "G", "H" });
        }
    }
}

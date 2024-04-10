using Microsoft.Extensions.DependencyInjection;
using ShortestPathCalculatorApplication;
using System;
using System.Linq;

namespace ShortestRouteOptimizerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You have nodes from A - I. You can only select start node and finish node between this range");
            Console.WriteLine();
            Console.WriteLine("Enter the start Node:");
            char startNode;
            char finishNode;
            bool isValid = false;
            isValid = char.TryParse(Console.ReadLine().ToUpper(), out startNode);

            while (!IsInRange(startNode) || !isValid)
            {
                Console.WriteLine("Entered node is not a valid starting node.");
                Console.WriteLine();
                Console.WriteLine("Enter the start Node:");
                isValid = char.TryParse(Console.ReadLine().ToUpper(), out startNode);
            }

            Console.WriteLine();

            Console.WriteLine("Enter the finish Node:");
            isValid = char.TryParse(Console.ReadLine().ToUpper(), out finishNode);

            while (!IsInRange(finishNode) || !isValid || startNode == finishNode)
            {
                Console.WriteLine("Entered node is not a valid finishing node.");
                Console.WriteLine();
                Console.WriteLine("Enter the finish Node:");
                isValid = char.TryParse(Console.ReadLine().ToUpper(), out finishNode);
            }

            Console.WriteLine();

            var services = CreateServices();
            NodeDataService nodeDataService = services.GetRequiredService<NodeDataService>();
            ShortestPathCalculator shortestPathCalculator = new ShortestPathCalculator(nodeDataService);
            ShortestPathDto shortestPathData = shortestPathCalculator.CalculateShortestPath(startNode.ToString(), finishNode.ToString());
            
            PrintShortestPathData(shortestPathData);

            Console.ReadLine();

            bool IsInRange(char inputNode)
            {
                if (inputNode >= char.Parse("A") && inputNode <= char.Parse("I"))
                {
                    // inputNode is within the range
                    return (true);
                }
                else
                {
                    // inputNode is NOT within the range 
                    return (false);
                }
            }
        }

        private static void PrintShortestPathData(ShortestPathDto shortestPathData)
        {
            Console.WriteLine("Total distance: " + shortestPathData.Distance);
            Console.WriteLine();
            Console.WriteLine("Traversed nodes order from Node = '" + shortestPathData.NodeNames.First() + "' to Node = '" + shortestPathData.NodeNames.Last() + "' is: ");

            foreach (var nodeName in shortestPathData.NodeNames)
            {
                Console.Write(nodeName + "  ");
            }
        }

        private static ServiceProvider CreateServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<NodeDataService>(new NodeDataService())
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}

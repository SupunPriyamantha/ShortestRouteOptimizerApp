using ShortestPathCalculatorApplication.IServices;

namespace ShortestPathCalculatorApplication
{
    public class NodeDataService : INodeDataService
    {
        private static int[,] NodeGraph = new int[9, 9];
        private static string[] nodeArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

        public NodeDataService()
        {
            InitializeGraph();
        }

        public int[,] ProvideGraph()
        {
            return NodeGraph;
        }

        public string[] ProvideInitialNodes()
        {
            return nodeArray;
        }

        private void SeedGraph(string u, string v, int w)
        {
            NodeGraph[u.GetPosition(nodeArray), v.GetPosition(nodeArray)] = w;
        }

        private void InitializeGraph()
        {
            SeedGraph("A", "B", 4);
            SeedGraph("A", "C", 6);
            SeedGraph("B", "A", 4);
            SeedGraph("B", "F", 2);
            SeedGraph("C", "A", 6);
            SeedGraph("C", "D", 8);
            SeedGraph("D", "C", 8);
            SeedGraph("D", "E", 4);
            SeedGraph("D", "G", 1);
            SeedGraph("E", "B", 2);
            SeedGraph("E", "D", 4);
            SeedGraph("E", "F", 3);
            SeedGraph("E", "I", 8);
            SeedGraph("F", "B", 2);
            SeedGraph("F", "E", 3);
            SeedGraph("F", "G", 4);
            SeedGraph("F", "H", 6);
            SeedGraph("G", "D", 1);
            SeedGraph("G", "F", 4);
            SeedGraph("G", "H", 5);
            SeedGraph("G", "I", 5);
            SeedGraph("H", "F", 6);
            SeedGraph("H", "G", 5);
            SeedGraph("I", "E", 8);
            SeedGraph("I", "G", 5);
        }
    }
}
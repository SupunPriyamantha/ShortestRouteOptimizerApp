using ShortestPathCalculatorApplication.IServices;

namespace ShortestPathCalculatorApplication
{
    public class NodeDataService : INodeDataService
    {
        private static string[] nodeArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        private static int[,] nodeGraph = new int[nodeArray.Length, nodeArray.Length];

        public NodeDataService()
        {
            // Initialize nodeGraph from here.
            InitializeGraph();
        }

        public int[,] ProvideGraph()
        {
            return nodeGraph;
        }

        public string[] ProvideInitialNodes()
        {
            return nodeArray;
        }

        private void SeedGraph(string u, string v, int w)
        {
            nodeGraph[u.GetPosition(nodeArray), v.GetPosition(nodeArray)] = w;
        }


        // New nodes should add to nodeArray and seed the distances from here.
        // Bidirectional nodes should seed both ways. Ondirectional ones should seed only for that direction.
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
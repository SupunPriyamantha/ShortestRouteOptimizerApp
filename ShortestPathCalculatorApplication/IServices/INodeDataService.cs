namespace ShortestPathCalculatorApplication.IServices
{
    public interface INodeDataService
    {
        int[,] ProvideGraph();

        string[] ProvideInitialNodes();
    }
}

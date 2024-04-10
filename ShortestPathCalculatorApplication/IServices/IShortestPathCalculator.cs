namespace ShortestPathCalculatorApplication.IServices
{
    public interface IShortestPathCalculator
    {
        ShortestPathDto CalculateShortestPath(string startNode, string finishNode);
    }
}

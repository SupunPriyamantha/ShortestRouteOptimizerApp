using System.Collections.Generic;

namespace ShortestPathCalculatorApplication
{
    public class ShortestPathDto
    {
        public ShortestPathDto(
            List<string> nodeNames,
            int distance)
        {
            NodeNames = nodeNames;
            Distance = distance;
        }

        public List<string> NodeNames { get; }

        public int Distance { get; }
    }
}
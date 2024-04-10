using System;

namespace ShortestPathCalculatorApplication
{
    public static class NodesToArrayIndexesMapper
    {
        public static int GetPosition(this string node, string[] nodeArray)
        {
            node = Char.ToUpper(char.Parse(node)).ToString();
            int index = Array.IndexOf(nodeArray, node);

            return index;
        }

        public static string GetNodeValueUsingPosition(this int index, string[] nodeArray)
        {
            string node = nodeArray[index];

            return node;
        }
    }
}
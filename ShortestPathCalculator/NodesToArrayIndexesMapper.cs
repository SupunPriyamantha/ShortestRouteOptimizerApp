using System;

namespace ShortestPathCalculator
{
    public static class NodesToArrayIndexesMapper
    {
        private static string[] nodeArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

        public static int GetPosition(this string node)
        {
            node = Char.ToUpper(char.Parse(node)).ToString();
            int index = Array.IndexOf(nodeArray, node);

            return index;
        }

        public static string GetNodeValueUsingPosition(this int index)
        {
            string node = nodeArray[index];

            return node;
        }
    }
}
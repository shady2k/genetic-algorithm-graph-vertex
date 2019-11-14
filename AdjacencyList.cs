using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gavg
{
    public class AdjacencyList
    {
        private List<KeyValuePair<int, int>> adjacencyList;
        public AdjacencyList()
        {
            adjacencyList = new List<KeyValuePair<int, int>>();
        }
        public bool ContainsKeyValue(int expectedKey, int expectedValue)
        {
            bool t1 = adjacencyList.Any(kvp => kvp.Key == expectedKey && kvp.Value == expectedValue);
            bool t2 = adjacencyList.Any(kvp => kvp.Key == expectedValue && kvp.Value == expectedKey);
            return t1 || t2;
        }
        public void addEdge(int startVertex, int endVertex)
        {
            if (startVertex == endVertex)
            {
                return;
            }
            if (startVertex > endVertex)
            {
                int sv = startVertex;
                int ev = endVertex;
                startVertex = ev;
                endVertex = sv;
            }
            if (!ContainsKeyValue(startVertex, endVertex))
            {
                adjacencyList.Add(new KeyValuePair<int, int>(startVertex, endVertex));
            }
        }
        public List<KeyValuePair<int, int>> getEdgesList()
        {
            return adjacencyList;
        }
    }
}

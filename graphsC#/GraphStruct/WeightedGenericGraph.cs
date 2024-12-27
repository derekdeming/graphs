using Priority_Queue;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace GraphStruct
{
    #region WeightedGraphNode: Create node structure
    public class WeightedGenericGraph<T>
    {
        #region Properties - Index, Value, Neighbors, Weights
        public int Index { get; set; }
        public T Value { get; set; }
        public List<WeightedGraphNode<T>> Neighbors { get; set; } = new List<WeightedGraphNode<T>>();
        public List<int> Weights { get; set; } = new List<int>();
        #endregion
        #region Basic Operations - AddNeighbors, RemoveNeighbors, ToString
        public bool AddNeighbors(WeightedGenericGraph<T> neighbor)
        {
            if (Neighbors.Contains(neighbor))
                return false;
            else
            {
                Neighbors.Add(neighbor);
                return true;
            }
        }
        //public bool RemoveNeighbors(WeightedGraphNode<T> neighbor)
        //{
        //    return Neighbors.Remove(neighbor);
        //}

        //public bool RemoveAllNeighbors()
        //{
        //    for (int i = Neighbors.Count; i >= 0; i--)
        //    {
        //        Neighbors.RemoveAt(i);
        //    }
        //    return true;
        //}
    }
}

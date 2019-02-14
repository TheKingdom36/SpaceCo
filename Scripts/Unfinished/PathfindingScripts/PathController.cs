using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class PathController : MonoBehaviour {
    /*
	public List<Node> GetShortestPathDijkstra(Node start , Node End)
    {
		DijkstraSearch(start);
        var shortestPath = new List<Node>();
        shortestPath.Add(End);
        BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }


    private void BuildShortestPath(List<Node> list, Node node)
    {
        if (node.NearestToStart == null)
            return;
        list.Add(node.NearestToStart);
        BuildShortestPath(list, node.NearestToStart);
    }

	private void DijkstraSearch(Node start)
    {
        Start.MinCostToStart = 0;
        var prioQueue = new List<Node>();
        prioQueue.Add(Start);
        do
        {
            prioQueue = prioQueue.OrderBy(x => x.MinCostToStart).ToList();
            var node = prioQueue.First();
            prioQueue.Remove(node);
            foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
            {
                var childNode = cnn.ConnectedNode;
                if (childNode.Visited)
                    continue;
                if (childNode.MinCostToStart == null ||
                    node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                {
                    childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                    childNode.NearestToStart = node;
                    if (!prioQueue.Contains(childNode))
                        prioQueue.Add(childNode);
                }
            }
            node.Visited = true;
            if (node == End)
                return;
        } while (prioQueue.Any());
    }*/
}

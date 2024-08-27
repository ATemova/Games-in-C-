using System;
using System.Collections.Generic;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int GCost { get; set; } // Cost from start node
    public int HCost { get; set; } // Heuristic cost to end node
    public Node Parent { get; set; }
    public bool IsWalkable { get; set; }

    public int FCost => GCost + HCost; // Total cost

    public Node(int x, int y, bool isWalkable)
    {
        X = x;
        Y = y;
        IsWalkable = isWalkable;
        GCost = int.MaxValue;
        HCost = 0;
        Parent = null;
    }
}

public class AStarPathfinding
{
    public static List<Node> FindPath(Node start, Node end, Node[,] grid)
    {
        List<Node> openSet = new List<Node> { start };
        HashSet<Node> closedSet = new HashSet<Node>();

        start.GCost = 0;
        start.HCost = CalculateHeuristic(start, end);

        while (openSet.Count > 0)
        {
            Node currentNode = GetLowestFCostNode(openSet);
            if (currentNode == end)
            {
                return RetracePath(start, end);
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (Node neighbor in GetNeighbors(currentNode, grid))
            {
                if (!neighbor.IsWalkable || closedSet.Contains(neighbor))
                    continue;

                int newGCost = currentNode.GCost + 1; // Assuming uniform cost
                if (newGCost < neighbor.GCost || !openSet.Contains(neighbor))
                {
                    neighbor.GCost = newGCost;
                    neighbor.HCost = CalculateHeuristic(neighbor, end);
                    neighbor.Parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null; // Path not found
    }

    private static List<Node> RetracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node currentNode = end;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        return path;
    }

    private static Node GetLowestFCostNode(List<Node> nodes)
    {
        Node lowest = nodes[0];
        foreach (Node node in nodes)
        {
            if (node.FCost < lowest.FCost)
                lowest = node;
        }
        return lowest;
    }

    private static List<Node> GetNeighbors(Node node, Node[,] grid)
    {
        List<Node> neighbors = new List<Node>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = node.X + dx[i];
            int newY = node.Y + dy[i];

            if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
            {
                neighbors.Add(grid[newX, newY]);
            }
        }

        return neighbors;
    }

    private static int CalculateHeuristic(Node a, Node b)
    {
        // Using Manhattan distance
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}

using System;
using System.Collections.Generic;

namespace EdgeBetweenTwoNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode A = new GraphNode(1);
            GraphNode B = new GraphNode(2);
            GraphNode C = new GraphNode(3);
            GraphNode D = new GraphNode(4);
            GraphNode E = new GraphNode(5);
            A.children.Add(B);
            A.children.Add(D);
            B.children.Add(C);
            B.children.Add(D);
            D.children.Add(E);

            Console.WriteLine(PavanDFS(D, A));
            Console.WriteLine(HasRoute(D, A));
        }

        public static bool HasRoute(GraphNode src, GraphNode trg)
        {
            if (src == null || trg == null) return false;
            if (src == trg) return true;
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            return RouteBetween2Nodes(src, trg, visited);
        }
        public static bool RouteBetween2Nodes(GraphNode source, GraphNode target, HashSet<GraphNode> visited)
        {
            if (source == target) return true;
            visited.Add(source);
            foreach (var child in source.children)
            {
                if (!visited.Contains(child))
                    if (RouteBetween2Nodes(child, target, visited))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// Pavan's Own implementation of DFS for Directed Graph that searches for edge between two nodes Iteratively
        /// </summary>
        /// <param name="src"></param>
        /// <param name="trg"></param>
        public static bool PavanDFS(GraphNode src, GraphNode trg)
        {
            if (src == null || trg == null) return false;
            if (src == trg) return true;
            Stack<GraphNode> nodes = new Stack<GraphNode>();
            nodes.Push(src);
            while (nodes.Count > 0)
            {
                GraphNode curNode = nodes.Pop();
                curNode.visited = true;
                if (curNode == trg) return true;
                else if (curNode.children != null && curNode.children.Count > 0)
                {
                    foreach (var item in curNode.children)
                        if (!item.visited)
                            nodes.Push(item);
                }
            }
            return false;
        }
    }

    class GraphNode
    {
        public int val;
        public List<GraphNode> children;
        public bool visited;
        public GraphNode(int value)
        {
            val = value;
            visited = false;
            children = new List<GraphNode>();
        }
    }
}

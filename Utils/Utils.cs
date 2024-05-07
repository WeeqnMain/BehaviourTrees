using System.Collections.Generic;

namespace BehaviourTrees
{
    public static class Utils
    {
        private static System.Random random = new();

        private struct NodeLevel
        {
            public Node node;
            public int level;
        }

        /// <summary>
        /// Builds string printout of the tree starting in given node
        /// </summary>
        /// <param name="node">Node that would be the root of the printed tree</param>
        /// <returns>Tree printout</returns>
        public static string Print(this Node node) 
        {
            string treePrintout = "";
            Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
            Node currentNode = node;
            nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

            while (nodeStack.Count != 0)
            {
                NodeLevel nextNode = nodeStack.Pop();
                treePrintout += new string('-', nextNode.level) + nextNode.node.name + "\n";
                for (int i = nextNode.node.children.Count - 1; i >= 0; i--)
                {
                    nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.children[i] });
                }
            }

            return treePrintout;
        }

        /// <summary>
        /// Shuffles the given List<Node>
        /// </summary>
        /// <param name="list">List that should be shuffled</param>
        /// <returns>Shuffled List<Node></returns>
        public static List<Node> Shuffle(this List<Node> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }
    }
}
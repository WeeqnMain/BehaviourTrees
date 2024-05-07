using System.Collections.Generic;

namespace BehaviourTrees
{
    /// <summary>
    /// Basic object for the behaviour tree
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Status of the node.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <item>
        /// <term>Success</term>
        /// <description>
        /// This value returns when task was completed successfully.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Failure</term>
        /// <description>
        /// This value returns when task was failed.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Running</term>
        /// <description>
        /// The value returns when node is working at that moment.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        public enum Status { Success, Running, Failure}

        public readonly List<Node> children = new();
        protected int currentChild;

        public readonly string name;
        public readonly int priority;

        public Node(string name = "Node", int priority = 0)
        {
            this.name = name;
            this.priority = priority;
        }

        /// <summary>
        /// Makes given node the child of the invoking one.
        /// </summary>
        /// <remarks>
        /// This means that invoking node going to return <c>Node.Status</c>
        /// based on the child node's status
        /// </remarks>
        /// <param name="child">Node that should be added to the invoking node</param>
        public void AddChild(Node child) => children.Add(child);

        public virtual Status Process() => children[currentChild].Process();

        public virtual void Reset()
        {
            currentChild = 0;
            foreach (var child in children)
            {
                child.Reset();
            }
        }
    }
}
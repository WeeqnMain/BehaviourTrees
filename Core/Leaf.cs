namespace BehaviourTrees
{
    /// <summary>
    /// Leaf nodes are actual actions that determines the decision making of the tree.
    /// Cannot have child nodes
    /// </summary>
    public class Leaf : Node
    {
        private readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy, int priority) : base(name, priority) 
        {
            this.strategy = strategy;
        }

        public override Status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
    }
}
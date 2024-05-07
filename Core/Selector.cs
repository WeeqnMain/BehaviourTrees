namespace BehaviourTrees
{
    /// <summary>
    /// <b>Composite node</b> that run's all the children in order of added in AddChild() method.
    /// </summary>
    /// <remarks>
    /// <i>Succeed</i> if <b>any</b> child node returns <c>Node.Status.Success</c> and 
    /// <i>Fails</i> if <b>all</b> the children returns <c>Node.Status.Failure</c>
    /// </remarks>
    public class Selector : Node
    {
        public Selector(string name, int priority) : base(name, priority) { }
        
        public override Status Process()
        {
            if (currentChild >= children.Count)
            {
                Reset();
                return Status.Failure;
            }

            Status childStatus = children[currentChild].Process();
            switch (childStatus)
            {
                case Status.Success:
                    Reset();
                    return Status.Success;
                case Status.Failure:
                    currentChild++;
                    return Status.Running;
                default:
                    return Status.Running;
            }
        }
    }
}
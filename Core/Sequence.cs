namespace BehaviourTrees
{
    /// <summary>
    /// <b>Composite node</b> that run's all the children in order of added in AddChild() method.
    /// </summary>
    /// <remarks>
    /// <i>Fails</i> if <b>any</b> child node returns <c>Node.Status.Failure</c> and 
    /// <i>Succeed</i> if <b>all</b> the children returns <c>Node.Status.Success</c>
    /// </remarks>
	public class Sequence : Node
	{
        public Sequence(string name, int priority) : base(name, priority) { }

        public override Status Process()
        {
            if (currentChild >= children.Count)
            {
                Reset();
                return Status.Success;
            }

            Status childStatus = children[currentChild].Process();
            switch (childStatus)
            {
                case Status.Success:
                    currentChild++;
                    return currentChild >= children.Count ? Status.Success : Status.Running;
                case Status.Failure:
                    currentChild = 0;
                    return Status.Failure;
                default:
                    return Status.Running;
            }
        }
    }
}
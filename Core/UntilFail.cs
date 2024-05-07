namespace BehaviourTrees
{
    /// <summary>
    /// <b>Composite node</b> that runs his child until it's returns <c>Node.Status.Failure</c>
    /// </summary>
    /// <remarks>
    /// Shouldn't have more than one child
    /// </remarks>
    public class UntilFail : Node
    {
        public UntilFail(string name) : base(name) { }

        public override Status Process()
        {
            Status childStatus = children[0].Process();
            if (childStatus == Status.Failure)
                return Status.Failure;
            return Status.Running;
        }
    }
}
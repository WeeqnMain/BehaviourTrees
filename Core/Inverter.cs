namespace BehaviourTrees
{
    /// <summary>
    /// <b>Decorator node</b> that inverts the child node status.
    /// </summary>
    /// <remarks>
    /// Shouldn't have more than one child
    /// </remarks>
    public class Inverter : Node
    {
        public Inverter(string name) : base(name) { }

        public override Status Process()
        {
            Status childStatus = children[0].Process();

            switch (childStatus)
            {
                case Status.Success:
                    return Status.Failure;
                case Status.Failure:
                    return Status.Success;
                default:
                    return Status.Running;
            }
        }
    }
}
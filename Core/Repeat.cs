namespace BehaviourTrees
{
    /// <summary>
    /// <b>Decorator node</b> that ignores child's <c>Node.Status.Success</c> and <c>Node.Status.Success</c> given amount of repetition.
    /// </summary>
    /// <remarks>
    /// Shouldn't have more than one child
    /// </remarks>
    public class Repeat : Node
    {
        private readonly int repetitionAmount;
        private int repetitionsLeft;

        public Repeat(string name, int repetitionAmount) : base(name) 
        {
            this.repetitionAmount = repetitionAmount;
            repetitionsLeft = repetitionAmount;
        }

        public override Status Process()
        {
            Status childStatus = children[0].Process();

            if (childStatus == Status.Running) return Status.Running;

            Reset();

            repetitionsLeft--;
            if (repetitionsLeft == 0)
            {
                repetitionsLeft = repetitionAmount;
                return Status.Success;
            }
            return Status.Running;
        }
    }
}
namespace BehaviourTrees
{
    public class Condition : IStrategy
    {
        public delegate bool ConditionMethod();
        private readonly ConditionMethod conditionMethod;

        public Condition(ConditionMethod conditionMethod)
        {
            this.conditionMethod = conditionMethod;
        }

        public Node.Status Process() => conditionMethod() ? Node.Status.Success : Node.Status.Failure;
    }
}
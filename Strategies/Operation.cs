namespace BehaviourTrees
{
    public class Operation : IStrategy
    {
        public delegate Node.Status OperationMethod();
        private OperationMethod operationMethod;

        public Operation(OperationMethod operationMethod)
        {
            this.operationMethod = operationMethod;
        }

        public Node.Status Process()
        {
            operationMethod();
            return Node.Status.Success;
        }
    }
}
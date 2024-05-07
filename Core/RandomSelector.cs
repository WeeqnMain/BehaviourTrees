using System.Collections.Generic;

namespace BehaviourTrees
{
    /// <summary>
    /// <b>Composite node</b> that run's all the children in random order.
    /// </summary>
    /// <remarks>
    /// Shuffle happening after node restart.
    /// <para>
    /// <i>Succeed</i> if <b>any</b> child node returns <c>Node.Status.Success</c> and 
    /// <i>Fails</i> if <b>all</b> the children returns <c>Node.Status.Failure</c>
    /// </para>
    /// </remarks>
    public class RandomSelector : PrioritySelector
    {
        protected override List<Node> SortChildren() => children.Shuffle();

        public RandomSelector(string name, int priority) : base(name, priority) { }
    }
}
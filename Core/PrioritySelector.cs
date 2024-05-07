using System.Collections.Generic;
using System.Linq;

namespace BehaviourTrees
{
    /// <summary>
    /// <b>Composite node</b> that run's all the children in order of <i>child.priority</i>.
    /// </summary>
    /// <remarks>
    /// Sorting happening after node restart
    /// <para>
    /// <i>Succeed</i> if <b>any</b> child node returns <c>Node.Status.Success</c> and 
    /// <i>Fails</i> if <b>all</b> the children returns <c>Node.Status.Failure</c>
    /// </para>
    /// </remarks>
    public class PrioritySelector : Selector
    {
        private List<Node> sortedChildren;
        protected List<Node> SortedChildren
        {
            get
            {
                if (sortedChildren == null)
                    sortedChildren = SortChildren();
                return sortedChildren;
            }
        }

        protected virtual List<Node> SortChildren() => children.OrderBy(child => child.priority).ToList();

        public PrioritySelector(string name, int priority) : base(name, priority) { }

        public override Status Process()
        {
            if (currentChild >= children.Count)
            {
                Reset();
                return Status.Failure;
            }

            Status childStatus = sortedChildren[currentChild].Process();
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

        public override void Reset()
        {
            base.Reset();
            sortedChildren = null;
        }

    }
}
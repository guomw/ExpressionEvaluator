using System.Collections.Generic;

namespace ExpressionEvaluator.ExpressionNotation.Data
{
    internal abstract class BaseDataValue : ExpressionNotationToken
    {
        public override void Push(Queue<object> output, Stack<object> ops)
        {
            output.Enqueue(this);
        }
    }
}

﻿using System.Collections.Generic;

namespace ExpressionEvaluator.ExpressionNotation.Typographic
{
    internal class LeftParenthesis : Parenthesis
    {
        #region Methods

        public override void Push(Queue<object> output, Stack<object> ops)
        {
            ops.Push(this);
        }

        #endregion Methods
    }
}

﻿using System;

namespace ExpressionEvaluator.ExpressionNotation.LogicalOperation
{
    internal class LogicalOperatorAnd : LogicalOperator
    {
        #region Methods

        protected override bool evaluateOperation(bool oper1, bool oper2)
        {
            bool _result;

            _result = (Convert.ToBoolean(oper1)) && (Convert.ToBoolean(oper2));

            return _result;
        }

        #endregion Methods
    }
}

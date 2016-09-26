using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class TypographicTest
    {
        [TestMethod]
        public void TestParenthesis()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("(VALOR[n,6][+]VALOR[n,9])[/]VALOR[n,3]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(5M, _result.Value);


            _expression.Parse("VALOR[n,6][+](VALOR[n,9][/]VALOR[n,3])");

            _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(9M, _result.Value);


            _expression.Parse("(VALOR[n,6][-]([average]VALOR[an,3;54;1;93]))[+](VALOR[n,9][/]VALOR[n,3])");

            _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(-28.75M, _result.Value);


            _expression.Parse("(([average]VALOR[an,3;54;1;93])[-]VALOR[n,6])[+](VALOR[n,9][/]VALOR[n,3])");

            _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(34.75M, _result.Value);
        }
    }
}

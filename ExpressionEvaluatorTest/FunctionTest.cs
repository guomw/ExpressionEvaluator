using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class FunctionTest
    {
        [Priority(3), TestMethod]
        public void TestAverage()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("[average]VALOR[an,3;54;1;93]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(37.75M, _result.Value);
        }

        [TestMethod]
        public void TestCos()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("[cos]VALOR[n,437]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(-0.95M, Math.Round(_result.Value, 3));
        }

        [TestMethod]
        public void TestSin()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("[cos]VALOR[n,364]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(0.911M, Math.Round(_result.Value, 3));
        }

        [TestMethod]
        public void TestSum()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("[sum]VALOR[an,3;54;254;432]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(743, _result.Value);
        }
    }
}

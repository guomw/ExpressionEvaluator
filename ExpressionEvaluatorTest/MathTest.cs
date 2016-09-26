using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void TestDivision()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,15][/]VALOR[n,3]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(5, _result.Value);
        }

        [TestMethod]
        public void TestMinus()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,8][-]VALOR[n,6]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(2, _result.Value);
        }

        [TestMethod]
        public void TestMultiply()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,9][*]VALOR[n,4]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(36, _result.Value);
        }

        [TestMethod]
        public void TestPlus()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,28][+]VALOR[n,11]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual<decimal>(39, _result.Value);
        }

        //[TestMethod]
        //public void TestUnaryMinus()
        //{
        //    ExpressionInterpreter _expression = new ExpressionInterpreter();
        //    _expression.Parse("VALOR[n,28][~]VALOR[n,75]");

        //    decimal? _result = _expression.Evaluate() as decimal?;

        //    Assert.IsNotNull(_result);
        //    Assert.AreEqual<decimal>(5, _result.Value);
        //}
    }
}

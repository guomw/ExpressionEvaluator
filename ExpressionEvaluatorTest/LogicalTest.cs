using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class LogicalTest
    {
        [TestMethod]
        public void TestAnd()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("(VALOR[n,23][=]VALOR[n,23])[AND](VALOR[t,marcelo][=]VALOR[t,marcelo])");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("(VALOR[n,23][=]VALOR[n,23])[AND](VALOR[t,marcelo][=]VALOR[t,ribeiro])");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("(VALOR[n,654][=]VALOR[n,23])[AND](VALOR[t,marcelo][=]VALOR[t,ribeiro])");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestOr()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("(VALOR[n,23][=]VALOR[n,23])[OR](VALOR[t,marcelo][=]VALOR[t,marcelo])");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("(VALOR[n,23][=]VALOR[n,23])[OR](VALOR[t,marcelo][=]VALOR[t,ribeiro])");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("(VALOR[n,654][=]VALOR[n,23])[OR](VALOR[t,marcelo][=]VALOR[t,ribeiro])");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestArray()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[an,1;56;7;8]");

            decimal[] _result = _expression.Evaluate() as decimal[];

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Length > 0);


            _expression.Parse("VALOR[at,marcelo;gomes;ribeiro]");

            string[] _resultString = _expression.Evaluate() as string[];

            Assert.IsNotNull(_resultString);
            Assert.IsTrue(_resultString.Length > 0);
        }

        [TestMethod]
        public void TestBoolean()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[b,1]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[b,0]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [Priority(1), TestMethod]
        public void TestDateTime()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[dt,1988-10-7]");

            DateTime? _result = _expression.Evaluate() as DateTime?;

            Assert.IsNotNull(_result);
            Assert.AreEqual(new DateTime(1988, 10, 7), _result);
        }

        [TestMethod]
        public void TestNumber()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,634]");

            decimal? _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual(634, _result);


            _expression.Parse("VALOR[d,32.9]");

            _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual(32.9M, _result);


            _expression.Parse("VALOR[i,3]");

            _result = _expression.Evaluate() as decimal?;

            Assert.IsNotNull(_result);
            Assert.AreEqual(3M, _result);
        }

        [TestMethod]
        public void TestString()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[t,marcelo]");

            string _result = _expression.Evaluate().ToString();

            Assert.IsNotNull(_result);
            Assert.AreEqual("marcelo", _result);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class CompTest
    {
        [TestMethod]
        public void TestContains()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[an,5;78;9;0;23][contains]VALOR[an,0;5;9;78]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[at,jose;marcelo;alberto][contains]VALOR[at,marcelo;joao;jose;alberto]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEquals()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,23][=]VALOR[n,23]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,44][=]VALOR[n,33]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEqualsString()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[t,marcelo][=]VALOR[t,marcelo]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[t,marcelo][=]VALOR[t,ribeiro]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEqualsArray()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[an,89;0;5;67;8;3][=]VALOR[an,0;3;5;8;67;89]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[at,marcelo;gomes;ribeiro][=]VALOR[at,marcelo;alves;ribeiro]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);

            _expression.Parse("VALOR[an,22;22][=]VALOR[an,22;13]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);

            _expression.Parse("VALOR[an,22;13][=]VALOR[an,22;22]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestGreaterEqualsThan()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,15][>=]VALOR[n,3]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,3][>=]VALOR[n,15]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[n,3][>=]VALOR[n,3]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);
        }

        [TestMethod]
        public void TestGreaterThan()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,15][>]VALOR[n,3]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,3][>]VALOR[n,15]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[n,3][>]VALOR[n,3]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestLessEqualsThan()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,45][<=]VALOR[n,78]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,12][<=]VALOR[n,3]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[n,34][<=]VALOR[n,324]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);
        }

        [TestMethod]
        public void TestLessThan()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,34][<]VALOR[n,54]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,98][<]VALOR[n,63]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[n,25][<]VALOR[n,25]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEquals()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,23][<>]VALOR[n,56]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,12][<>]VALOR[n,12]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEqualsString()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[t,marcelo][<>]VALOR[t,ribeiro]");
            
            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[t,marcelo][<>]VALOR[t,marcelo]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEqualsArray()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[at,marcelo;gomes;ribeiro][<>]VALOR[at,marcelo;alves;ribeiro]");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[an,89;0;5;67;8;3][<>]VALOR[an,0;3;5;8;67;89]"); 

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[an,22;22][<>]VALOR[an,22;23]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);

            _expression.Parse("VALOR[an,22;23][<>]VALOR[an,22;22]");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);
        }

    }
}

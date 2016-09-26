using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionEvaluator;

namespace ExpressionEvaluatorTest
{
    [TestClass]
    public class VariableTest
    {
        [TestMethod]
        public void TestContainsWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[contains]VALOR[an,0;5;9;78]");
            _expression.SetVariable("@parameter@", new decimal[] { 5, 78, 9, 0, 23 });

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[at,jose;marcelo;alberto][contains]@parameter@");
            _expression.SetVariable("@parameter@", new string[] { "marcelo", "joao", "jose", "alberto" });

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEqualsWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,23][=]@parameter@");
            _expression.SetVariable("@parameter@", 23);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("@parameter@[=]VALOR[n,33]");
            _expression.SetVariable("@parameter@", 44);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEqualsStringWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[=]VALOR[t,marcelo]");
            _expression.SetVariable("@parameter@", "marcelo");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[t,marcelo][=]@parameter@");
            _expression.SetVariable("@parameter@", "ribeiro");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestEqualsArrayWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[an,89;0;5;67;8;3][=]@parameter@");
            _expression.SetVariable("@parameter@", new decimal[] { 0, 3, 5, 8, 67, 89 });

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[at,marcelo;gomes;ribeiro][=]@parameter@");
            _expression.SetVariable("@parameter@", new string[] { "marcelo", "alves", "ribeiro" });

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestGreaterEqualsThanWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[>=]VALOR[n,3]");
            _expression.SetVariable("@parameter@", 15);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("@parameter@[>=]VALOR[n,15]");
            _expression.SetVariable("@parameter@", 3);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("VALOR[n,3][>=]@parameter@");
            _expression.SetVariable("@parameter@", 3);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);
        }

        [TestMethod]
        public void TestGreaterThanWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,15][>]@parameter@");
            _expression.SetVariable("@parameter@", 3);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,3][>]@parameter@");
            _expression.SetVariable("@parameter@", 15);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("@parameter@[>]VALOR[n,3]");
            _expression.SetVariable("@parameter@", 3);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestLessEqualsThanWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("VALOR[n,45][<=]@parameter@");
            _expression.SetVariable("@parameter@", 78);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("@parameter@[<=]VALOR[n,3]");
            _expression.SetVariable("@parameter@", 12);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("@parameter@[<=]VALOR[n,34]");
            _expression.SetVariable("@parameter@", 34);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);
        }

        [TestMethod]
        public void TestLessThanWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[<]VALOR[n,54]");
            _expression.SetVariable("@parameter@", 34);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[n,98][<]@parameter@");
            _expression.SetVariable("@parameter@", 63);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);


            _expression.Parse("@parameter@[<]VALOR[n,25]");
            _expression.SetVariable("@parameter@", 25);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEqualsWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[<>]VALOR[n,56]");
            _expression.SetVariable("@parameter@", 23);

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("@parameter@[<>]VALOR[n,12]");
            _expression.SetVariable("@parameter@", 12);

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEqualsStringWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[<>]VALOR[t,ribeiro]");
            _expression.SetVariable("@parameter@", "marcelo");

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("VALOR[t,marcelo][<>]@parameter@");
            _expression.SetVariable("@parameter@", "marcelo");

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }

        [TestMethod]
        public void TestNotEqualsArrayWithVariable()
        {
            ExpressionInterpreter _expression = new ExpressionInterpreter();
            _expression.Parse("@parameter@[<>]VALOR[at,marcelo;alves;ribeiro]");
            _expression.SetVariable("@parameter@", new string[] { "marcelo", "gomes", "ribeiro" });

            bool? _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Value);


            _expression.Parse("@parameter@[<>]VALOR[an,0;3;5;8;67;89]");
            _expression.SetVariable("@parameter@", new decimal[] { 89, 0, 5, 67, 8, 3 });

            _result = _expression.Evaluate() as bool?;

            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Value);
        }
    }
}

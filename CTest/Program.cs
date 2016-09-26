using ExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 30000; i++)
            {
                //new System.Threading.Thread(delegate()
                //{
                    string tmplNote = "当前被砍#{helpcount}#次，当前剩余#{remainstore}#件";                    
                    string tmpl = Regex.Replace(tmplNote, "#([^#]+)#", new MatchEvaluator(delegate(Match ma)
                    {
                        string expression = ma.Groups[1].Value;
                        expression = expression.Replace("{helpcount}", "8227");
                        expression = expression.Replace("{remainstore}", "79");
                        expression = expression.Replace("{invokeperson}", "623");
                        object _result = ExpressionsEvaluator.Eval(expression);
                        return Convert.ToInt32(_result).ToString();

                    }));
                    Console.WriteLine(tmpl);
                //}) { IsBackground = true }.Start();
            }

           

            //string tempNote = @"{{w}-0.1}*{{2000-w}-0.6}*(10+[(w-500)/500]*3)+{{w-2000}-0.1}*{{5000-w}-0.6}*[w]*6+{{w-5000}-0.1}*{{10000-w}-0.6}*[w]*5+{{w-10000}-0.1}*[w]*4";
            //tempNote = @"{{200-p}-0.6}*(15+[(w-1000)/500]*5)";
            ////tempNote = "0*(15+-1+5)+1.5+-2.3+1";
            //tempNote = tempNote.Replace("p", "200");
            //tempNote = tempNote.Replace("w", "1");
            //tempNote = RegexReplace(tempNote, false);
            //tempNote = RegexReplace(tempNote, true);
            //object _result = ExpressionsEvaluator.Eval(tempNote);
            //Console.Write(_result);


            ////string expression = @"{{200-p}-0.6}*(15+[(w-1000)/500]*5)";
            //string expression = @"{{w}-0.1}*{{2000-w}-0.6}*(10+[(w-500)/500]*3)+{{w-2000}-0.1}*{{5000-w}-0.6}*[w]*6+{{w-5000}-0.1}*{{10000-w}-0.6}*[w]*5+{{w-10000}-0.1}*[w]*4";
            //for (int i = 0; i < 10000; i++)
            //{
            //    string tempNote = expression;
            //    tempNote = tempNote.Replace("p", "200");
            //    tempNote = tempNote.Replace("w", i.ToString());
            //    tempNote = RegexReplace(tempNote, false);
            //    tempNote = RegexReplace(tempNote, true);
            //    object _result = ExpressionsEvaluator.Eval(tempNote);                
            //    Console.WriteLine(_result);
            //}


        }

        /// <summary>
        ///解析公式
        /// </summary>
        /// <param name="expression">运费公式 如：{{w}-0.1}*{{2000-w}-0.6}*(10+[(w-500)/500]*3)+{{w-2000}-0.1}*{{5000-w}-0.6}*[w]*6+{{w-5000}-0.1}*{{10000-w}-0.6}*[w]*5+{{w-10000}-0.1}*[w]*4</param>
        /// <param name="IsBracket">是否替换中括号(true表示中括号，false表示大括号)</param>
        /// <returns></returns>
        private static string RegexReplace(string expression, bool IsBracket)
        {
            //IsBracket=true 时，匹配expression 中[]的内容，从小到大，否则匹配{}
            string pattern = IsBracket ? @"\[[^?!\[|\]]*\]" : @"\{[^?!\{|\}]+\}";
            expression = Regex.Replace(expression, pattern, new MatchEvaluator((Match ma) =>
            {
                string express = ma.Value;
                express = express.Replace(!IsBracket ? "{" : "[", "");//替换{或[为空
                express = express.Replace(!IsBracket ? "}" : "]", "");//替换}或]为空
                object _result = ExpressionsEvaluator.Eval(express);
                double d = IsBracket ? ExpressionsEvaluator.GetCeil(Convert.ToDouble(_result)) : ExpressionsEvaluator.GetVal(Convert.ToDouble(_result));
                return d.ToString();
            }), RegexOptions.Compiled);
            if (Regex.IsMatch(expression, pattern))
                expression = RegexReplace(expression, IsBracket);
            return expression;
        }



    }


    public class ExpressionsEvaluator
    {

       // private static ExpressionInterpreter _expression = null;
        /// <summary>
        /// 计算结果,如果表达式出错则抛出异常，支持-加减乘除
        /// </summary>
        /// <param name="expression">表达式,如"1+2+3+4"</param>
        /// <returns></returns>
        public static object Eval(string expression)
        {
            string output = expression;
            //if (_expression == null)
            //    _expression = new ExpressionInterpreter();

            ExpressionInterpreter _expression = new ExpressionInterpreter();

            //匹配小数和整数正则表达式(包含正负)
            //示例：0*(15+-1+5)+1.5+-2.3+1
            string pattern = @"(?<!\d)-?\d*\.\d*|(?<!\d)-?\d+";
            //将公式替换成规定格式如VALOR[n,0]*(VALOR[n,15]+(VALOR[n,-1]+VALOR[n,5]))+VALOR[n,1.5]+(VALOR[n,-2.3])+VALOR[n,1]
            output = Regex.Replace(output, pattern, new MatchEvaluator((Match m) =>
            {
                return string.Format("VALOR[n,{0}]", m.Value);
            }), RegexOptions.Compiled);
            //匹配加减乘除运算符，并替换成规定格式
            //如VALOR[n,0][*](VALOR[n,15][+](VALOR[n,-1][+]VALOR[n,5]))[+]VALOR[n,1.5][+](VALOR[n,-2.3])[+]VALOR[n,1]
            string o = @"[\*|\+|\-|/](?!\d)";
            output = Regex.Replace(output, o, new MatchEvaluator((Match m) =>
            {
                return string.Format("[{0}]", m.Value);
            }), RegexOptions.Compiled);
            _expression.Parse(output);
            return _expression.Evaluate();
        }
        /// <summary>
        /// 当val的数值 >0时 整体值向上取整数，如[7＋2.2]=10
        /// 当val的数值=0时 整体值取0，如[0]=0
        /// 当val的数值小于0时 整体值取0，如[0]=0
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double GetCeil(double val)
        {
            return Math.Ceiling(val);
        }
        /// <summary>
        /// 当val的数值>0时,整体值取1，如{23565}=1、{0.00001}=1
        /// 当val的数值=0时,整体值取0.5，如{0}=0.5
        /// 当val的数值小于0时，整体值取0，如{-2255}=0,{-0.002}=0
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double GetVal(double val)
        {
            if (val > 0)
                return 1;
            else if (val == 0)
                return 0.5;
            else
                return 0;
        }

    }

}

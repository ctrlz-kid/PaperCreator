using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator
{
    public enum FormulaMethod
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division
    };

    public class FormulaOperator
    {
        public FormulaOperator()
        {
            this.method = FormulaMethod.None;
            this.number = 0;
        }
        private FormulaMethod method;
        private int number;
       
        public int Number { get => number; set => number = value; }
        public FormulaMethod Method { get => method; set => method = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            switch(Method)
            {
                case FormulaMethod.Addition:
                    sb.Append("+");
                    break;

                case FormulaMethod.None:                    
                    break;

                case FormulaMethod.Subtraction:
                    sb.Append("-");
                    break;

                case FormulaMethod.Multiplication:
                    sb.Append("×");
                    break;

                case FormulaMethod.Division:
                    sb.Append("÷");
                    break;
            }
            sb.Append(number);
            return sb.ToString();
        }

        public  static FormulaOperator NoneOperator(int number)
        {
            FormulaOperator ret = new FormulaOperator();
            ret.method = FormulaMethod.None;
            ret.number = number;
            return ret;
        }

        public static FormulaOperator AdditionOperator(int number)
        {
            FormulaOperator ret = new FormulaOperator();
            ret.method = FormulaMethod.Addition;
            ret.number = number;
            return ret;
        }

        public static FormulaOperator SubtractionOperator(int number)
        {
            FormulaOperator ret = new FormulaOperator();
            ret.method = FormulaMethod.Subtraction;
            ret.number = number;
            return ret;
        }

        public static FormulaOperator MultiplicationOperator(int number)
        {
            FormulaOperator ret = new FormulaOperator();
            ret.method = FormulaMethod.Multiplication;
            ret.number = number;
            return ret;
        }

        public static FormulaOperator DivisionOperator(int number)
        {
            FormulaOperator ret = new FormulaOperator();
            ret.method = FormulaMethod.Division;
            ret.number = number;
            return ret;
        }

        public static FormulaOperator Combine(FormulaOperator one, FormulaOperator two)
        {
            if ( (one.method == FormulaMethod.Addition || one.method == FormulaMethod.Subtraction)
                && (two.method == FormulaMethod.Addition || two.method == FormulaMethod.Subtraction))
            {
                if(one.method == two.method)
                {
                    int temp = one.number + two.number;
                    FormulaOperator newOne = new FormulaOperator();
                    newOne.method = one.method;
                    newOne.number = temp;
                    return newOne;
                }
                else
                {
                    int temp = 0;
                    if (one.method == FormulaMethod.Addition)
                    {
                        temp = one.number - two.number;
                    }
                    else
                    {
                        temp = two.number - one.number;
                    }

                    if (temp > 0)
                    {
                        return AdditionOperator(temp);
                    }
                    else
                        return SubtractionOperator(temp * (-1));
                }
            }
               
            throw new NotSupportedException();
        }
    }

    public class Formula
    {
        public Formula()
        {
            result = 0;
            DisplayResult = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FormulaOperator op in operators)
            {
                sb.Append(op.ToString());
            }

            sb.Append("=");
            if (displayResult)
                sb.Append(result);
            return sb.ToString();
        }

        public void AddOperator(FormulaOperator p)
        {
            this.operators.Add(p);
        }

        int result;
        bool displayResult;


        private List<FormulaOperator> operators = new List<FormulaOperator>();

        public List<FormulaOperator> Operators { get => operators; set => operators = value; }
        public int Result { get => result; set => result = value; }
        public bool DisplayResult { get => displayResult; set => displayResult = value; }
    }

    public interface FormulaCreator
    {
        Formula Create();
    }

    public interface FormulaArrayCreator
    {
        Formula[] CreateArray(int count);
    }
}

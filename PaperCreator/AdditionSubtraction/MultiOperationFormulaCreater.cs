using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator.AdditionSubtraction
{
    class MultiOperationFormulaCreater: FormulaCreator
    {
        static Random random = new Random((int)DateTime.Now.Ticks);

        public MultiOperationFormulaCreater()
        {
            countOfOperations = 1;
            resultRange = new Range();
            numberRange = new Range();
            resultRange.Min = 0;
            resultRange.Max = 100;

            numberRange.Min = 3;
            numberRange.Max = 97;
        }
        public Formula Create()
        {
            int sum = 0;            
            int i;
            FormulaOperator operation;
            Formula formula = new Formula();
            for (i=0; i<=countOfOperations; i++)
            {
                if (i== 0)
                {
                    operation = new FormulaOperator();
                    operation.Number = random.Next(numberRange.Min, numberRange.Max);
                    sum = sum + operation.Number;
                    formula.AddOperator(operation);
                }
                else
                {
                    if ( random.Next(0, 1) > 0)
                    {
                        operation = new FormulaOperator();
                        operation.Method = FormulaMethod.Addition;
                        operation.Number = random.Next(numberRange.Min, numberRange.Max);
                        sum = sum + operation.Number;
                        formula.AddOperator(operation);

                        CheckSum(ref sum, formula);
                    }
                    else
                    {
                        operation = new FormulaOperator();
                        operation.Method = FormulaMethod.Subtraction;
                        operation.Number = random.Next(numberRange.Min, numberRange.Max);
                        sum = sum - operation.Number;
                        formula.AddOperator(operation);

                        CheckSum(ref sum, formula);
                    }
                }
            }



            formula.Result = sum;

            return formula;
        }

        /// <summary>
        /// 检查结果是否在结果要求范围内
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="formula"></param>
        private void CheckSum(ref int sum, Formula formula)
        {
            if (sum > resultRange.Max)
            {
                // 结果修正
                int resultAmend = random.Next(sum - resultRange.Max+1, sum);

                formula.Operators[formula.Operators.Count - 1].Number -= resultAmend;
                sum = sum - resultAmend;
                formula.Result = sum;
            }

            if (sum < resultRange.Min)
            {
                // 结果修正

                int resultAmend = random.Next(Math.Min(resultRange.Max * (-1), sum-1)
                    , Math.Max(resultRange.Max * (-1), sum-1));

                FormulaOperator amendOper = new FormulaOperator();
                if (resultAmend < 0)
                {
                    amendOper.Method = FormulaMethod.Addition;
                    amendOper.Number = Math.Abs(resultAmend);
                }
                else
                {
                    amendOper.Method = FormulaMethod.Subtraction;
                    amendOper.Number = Math.Abs(resultAmend);
                }

                FormulaOperator newOne = FormulaOperator.Combine(formula.Operators[formula.Operators.Count - 1], amendOper);
                formula.Operators[formula.Operators.Count - 1] = newOne;
                sum = sum - resultAmend;
                formula.Result = sum;
            }
        }

        int countOfOperations;
        Range resultRange;
        Range numberRange;

        public int CountOfOperations { get => countOfOperations; set => countOfOperations = value; }
        public Range ResultRange { get => resultRange; set => resultRange = value; }
        public Range NumberRange { get => numberRange; set => numberRange = value; }        
    }
}

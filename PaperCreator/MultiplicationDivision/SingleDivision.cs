using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator.MultiplicationDivision
{
    /// <summary>
    /// 单除法
    /// </summary>
    class SingleDivision : SingleMultiplication
    {
        public SingleDivision(Range range1, Range range2) : base(range1, range2)
        {
        }

        protected override void GenerateFormulaArray(ArrayList list)
        {
            int i, k;
            for (i = this.NumberRange1.Min; i <= this.NumberRange1.Max; i++)
            {
                for (k = this.NumberRange2.Min; k <= this.NumberRange2.Max; k++)
                {
                    int leftValue = i * k;
                    Formula formula = new Formula();
                    formula.AddOperator(FormulaOperator.NoneOperator(leftValue));
                    formula.AddOperator(FormulaOperator.DivisionOperator(i));
                    formula.Result = k;

                    list.Add(formula);
                }
            }
        }
    }
}

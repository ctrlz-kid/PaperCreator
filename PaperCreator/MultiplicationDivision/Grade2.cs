using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator.MultiplicationDivision
{
    /// <summary>
    /// 不大于5*9乘法
    /// </summary>
    public class ForGrade2 : FormulaArrayCreator
    {
        static Random random = new Random((int)DateTime.Now.Ticks);

        public ForGrade2()
        {

        }

        public ForGrade2(Range range1, Range range2)
        {
            this.numberRange1 = range1;
            this.numberRange2 = range2;
        }
        public Formula[] CreateArray(int count)
        {
            int i, k;

            System.Collections.ArrayList list = new System.Collections.ArrayList();
            for (i = this.numberRange1.Min; i <= this.numberRange1.Max; i++)
            {
                for (k = this.numberRange2.Min; k <= this.numberRange2.Max; k++)
                {
                    Formula formula = new Formula();
                    formula.AddOperator(FormulaOperator.NoneOperator(i));
                    formula.AddOperator(FormulaOperator.MultiplicationOperator(k));
                    formula.Result = i * k;

                    list.Add(formula);
                }
            }

            for(i=0; i<list.Count; i++)
            {
                int index = random.Next(0, list.Count-1);
                object temp = list[0];
                list[0] = list[index];
                list[index] = temp;
            }

            if (count < list.Count)
                list.RemoveRange(count, list.Count - count);

            return (Formula[])list.ToArray(typeof(Formula));
        }

        private Range numberRange1;
        private Range numberRange2;

        public Range NumberRange1 { get => numberRange1; set => numberRange1 = value; }
        public Range NumberRange2 { get => numberRange2; set => numberRange2 = value; }
    }
}

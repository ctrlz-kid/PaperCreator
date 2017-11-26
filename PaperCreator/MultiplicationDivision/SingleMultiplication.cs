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
    public class SingleMultiplication : FormulaArrayCreator
    {
        static Random random = new Random((int)DateTime.Now.Ticks);

        public SingleMultiplication()
        {

        }

        public SingleMultiplication(Range range1, Range range2)
        {
            this.numberRange1 = range1;
            this.numberRange2 = range2;
        }
        Formula[] FormulaArrayCreator.CreateArray(int count)
        {          
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            GenerateFormulaArray(list);
            RandomScramblingList(list);


            // 缩减长度
            if (count < list.Count)
                list.RemoveRange(count, list.Count - count);

            return (Formula[])list.ToArray(typeof(Formula));
        }

        protected virtual void GenerateFormulaArray(System.Collections.ArrayList list)
        {
            int i, k;
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
        }

        /// <summary>
        /// 随机置乱算法ArrayList
        /// Fisher–Yates随机置乱算法, 也称高纳德（ Knuth）随机置乱算法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected static void RandomScramblingList(System.Collections.ArrayList list)
        {
            int i;
            for (i = list.Count -1; i > 0; i--)
            {
                int index = random.Next(0, i);
                object temp = list[i];
                list[i] = list[index];
                list[index] = temp;
            }            
        }

        private Range numberRange1;
        private Range numberRange2;

        public Range NumberRange1 { get => numberRange1; set => numberRange1 = value; }
        public Range NumberRange2 { get => numberRange2; set => numberRange2 = value; }
    }
}

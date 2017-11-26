using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaperCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            // 乘法 5以内
            paper.InsertFormulaArrayCreater(new MultiplicationDivision.SingleMultiplication(
                new Range(2, 5), new Range(2, 9)), 24);

            // 除法 5以内
            paper.InsertFormulaArrayCreater(new MultiplicationDivision.SingleDivision(
                new Range(2, 5), new Range(2, 9)), 24);

            // 单独加减（100以内）
            AdditionSubtraction.MultiOperationFormulaCreater singleOperationFormulacreater
                = new AdditionSubtraction.MultiOperationFormulaCreater();
            singleOperationFormulacreater.NumberRange.Min = 20;
            singleOperationFormulacreater.NumberRange.Max = 90;
            paper.InsertFormulaCreater(singleOperationFormulacreater, 24);

            // 连续加减（100以内）
            AdditionSubtraction.MultiOperationFormulaCreater multiOperationFormulacreater
                = new AdditionSubtraction.MultiOperationFormulaCreater();
            multiOperationFormulacreater.CountOfOperations = 2;
            paper.InsertFormulaCreater(multiOperationFormulacreater, 100-24-24-24);

            paper.Create();
        }

        private global::PaperCreator.Paper paper = new Paper();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string fullPath = paper.SaveFile("output.html");

            Uri uri = new Uri(fullPath);
            
            System.Diagnostics.Process.Start(@"chrome.exe", uri.AbsoluteUri);
        }
    }
}

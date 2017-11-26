using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator
{


    class Paper
    {
        private struct CreatorSetting
        {
            public int count;
            public FormulaCreator formulaCreator;
        }
        private struct ArrayCreatorSetting
        {
            public int count;
            public FormulaArrayCreator formulaArrayCreator;
        }

        public void Create()
        {
            formulas.Clear();

            CreateArray();

            foreach (CreatorSetting setting in creatorSettings)
            {
                for(int i=0; i<setting.count; i++)
                {
                    Formula formula = setting.formulaCreator.Create();
                   // formula.DisplayResult = true;
                    string f = formula.ToString();
                    char c;
                    while ( formulas.TryGetValue(f, out c) == true )
                    {
                        formula = setting.formulaCreator.Create();
                       // formula.DisplayResult = true;
                        f = formula.ToString();
                    }

                    formulas.Add(f, '1');
                }
            }
        }

        public void CreateArray()
        {
            foreach (ArrayCreatorSetting setting in this.arrayCreatorSettings)
            {
                Formula[] formulaArray = setting.formulaArrayCreator.CreateArray(setting.count);

                for(int i=0; i<formulaArray.Length; i++)
                {
                    Formula formula = formulaArray[i];
                    //formula.DisplayResult = true;
                    string f = formula.ToString();
                    char c;
                    if (formulas.TryGetValue(f, out c) == false)
                    {
                        formulas.Add(f, '1');
                    }
                }

            }
        }

        public string SaveFile(string filename)
        {
            string fileFullPath;
            StreamWriter fn = new StreamWriter(filename, false);

            FileStream fs = fn.BaseStream as FileStream;
            fileFullPath = fs.Name;
            fn.WriteLine("<table width=800 border=1>");

            int line = 0;

            foreach(KeyValuePair<string,char> kvp in this.formulas)
            {
                if (line == 0)
                    fn.WriteLine("<tr>");


                fn.WriteLine("<td width=25%>");
                fn.WriteLine(kvp.Key);
                fn.WriteLine("</td>");

                line++;
                if (line == 4)
                {
                    fn.WriteLine("</tr>");
                    line = 0;
                }
                  
            }
            
           


            fn.WriteLine("</table>");

            fn.Close();

            return fileFullPath;
        }

        public void InsertFormulaCreater(FormulaCreator formulaCreator, int countToCall)
        {
            CreatorSetting settting = new CreatorSetting();
            settting.formulaCreator = formulaCreator;
            settting.count = countToCall;

            creatorSettings.Add(settting);
        }

        public void InsertFormulaArrayCreater(FormulaArrayCreator formulaArrayCreator, int countToCall)
        {
            ArrayCreatorSetting settting = new ArrayCreatorSetting();
            settting.formulaArrayCreator = formulaArrayCreator;
            settting.count = countToCall;

            arrayCreatorSettings.Add(settting);
        }

        private System.Collections.Generic.List<ArrayCreatorSetting> arrayCreatorSettings = new List<ArrayCreatorSetting>();
        private System.Collections.Generic.List<CreatorSetting> creatorSettings = new List<CreatorSetting>();
        private System.Collections.Generic.Dictionary<string, char> formulas = new Dictionary<string, char>();
    }
}

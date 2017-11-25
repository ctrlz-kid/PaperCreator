using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCreator
{
    public class Range
    {
        public Range ()
        {
            min = 0; max = 0;
        }
        public Range(int min, int max)
        {
            this.min = min; this.max = max;
        }
        private int min;
        private int max;
        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }
    }
}

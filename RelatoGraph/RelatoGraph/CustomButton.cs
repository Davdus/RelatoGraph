using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RelatoGraph
{
    class CustomButton : Button
    {
        public String SetA { get; set; }
        public String SetB { get; set; }
        public String RelationValue { get; set; }

        public CustomButton(String a, String b, String r)
        {
            SetA = a;
            SetB = b;
            RelationValue = r;
        }
    }
}

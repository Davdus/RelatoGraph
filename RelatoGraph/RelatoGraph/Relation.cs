using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatoGraph
{
    class Relation
    {
        /*
         * A relation is the connection of two sets
         * by binding numbers of one set to numbers of the opposite set.
         */
        
        public Relation()
        {
        }

        public List<int> UserInput(char split, String text)
        {
            String[] chars = text.Split(split);
            List<int> list = new List<int>();
            foreach (String s in chars)
                list.Add(Int32.Parse(s));
            return list;
        }

        public String printList(List<int> list)
        {
            String output = "";
            foreach (int i in list)
            {
                output += i;
            }
            return output.ToString();
        }

        public void drawRelation()
        {
            //calls UserInput
            //draw relation class
        }
    }
}

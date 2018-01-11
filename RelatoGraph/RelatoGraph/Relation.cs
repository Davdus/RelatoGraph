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


        public Relation()
        {
        }

        public List<String> UserInput(char split, String text)
        {
            String[] strings = text.Split(split);
            
            List<String> list = new List<String>();
            foreach (String s in strings)
                list.Add(s);
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
        
        /*Still leave this be
        public void drawRelation(String wholeRelation)
        {
            String[] splitThree = wholeRelation.Split('|');

            String setA = splitThree[0];
            String setB = splitThree[1];
            String relationString = splitThree[2];

            String[] splitSetA = setA.Split(',');
            String[] splitSetB = setB.Split(',');

            String[] splitRelationStringBigger = relationString.Split(';');
            String[] splitRelationStringSmaller1 = splitRelationStringBigger[0].Split(',');
            String[] splitRelationStringSmaller2 = splitRelationStringBigger[1].Split(',');

            List<String> list1 = new List<String>();
            list1.Add(setA);
            List<String> list2 = new List<String>();
            list2.Add(setB);
            List<List<String>> list3 = new List<List<String>>();
            //foreach(String s in)

            

            


        
        }*/
    }
}

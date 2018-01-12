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
        public String SetA { get; set; }
        public String SetB { get; set; }
        public String RelationValue { get; set; }

        /*
         * A relation is the connection of two sets
         * by binding numbers of one set to numbers of the opposite set.
         */

        public Relation(String a, String b, String r)
        {
            SetA = a;
            SetB = b;
            RelationValue = r;
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
                output += i + ",";
            }
            output = output.Remove(output.Length - 1);
            return output.ToString() + ";";
        }

        public String printDoubleList(List<List<int>> list)
        {
            String output = "";
            foreach (List<int> i in list)
            {
                output += printList(i);
            }
            return output.ToString();
        }

        public List<List<int>> splitRelation()
        {
            char colon = ',';
            char semicolon = ';';
            String relation = RelationValue;
            int length = relation.Length;
            List<List<int>> intList = new List<List<int>>();
            List<int> innerList;

            String[] charArray = relation.Split(semicolon);
            for (int i = 0; i < charArray.Length; i++)
            {
                String[] innercharArray = charArray[i].Split(colon);
                innerList = innercharArray.Select(x => Int32.Parse(x)).ToList();
                intList.Add(innerList);
            }

            return intList;
        }

        public List<int> splitSetA()
        {
            char colon = ',';
            String setA = SetA;
            String[] charArray = setA.Split(colon);
            List<int> intList = new List<int>();
            intList = charArray.Select(x => Int32.Parse(x)).ToList();
            return intList;
        }

        public List<int> splitSetB()
        {
            char colon = ',';
            String setB = SetB;
            String[] charArray = setB.Split(colon);
            List<int> intList = new List<int>();
            intList = charArray.Select(x => Int32.Parse(x)).ToList();
            return intList;
        }

        public bool isLefttotal()
        {
            int count = splitSetA().Count;
            int counter = 0;

            foreach (int i in splitSetA())
            {
                foreach (List<int> list in splitRelation())
                {
                    int position1 = list.ElementAt(0);
                    if (position1 == i)
                    {
                        counter++;
                        break;
                    }
                }
            }
            if (counter >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRighttotal()
        {
            int count = splitSetB().Count;
            int counter = 0;

            foreach (int i in splitSetB())
            {
                foreach (List<int> list in splitRelation())
                {
                    int position2 = list.ElementAt(1);
                    if (position2 == i)
                    {
                        counter++;
                        break;
                    }
                }
            }
            if (counter >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool isBitotal()
        {
            if (isLefttotal() && isRighttotal())
            {
                return true;
            }
            return false;
        }

        /*
         * Jedes Element b aus der Zielmenge hat max. einen Partner a aus der Quellmenge
         * 
         */
        public bool isLeftunique()
        {
            //is?
            return false;
        }

        /*
         * Jedes Element a aus der Quellmenge hat max. einen Partner b aus der Zielmenge
         */
        public bool isRightunique()
        {
            //is?
            return false;
        }
        public bool isOneunique()
        {
            if (isLeftunique() && isRightunique())
            {
                return true;
            }
            return false;
        }

















    }
}

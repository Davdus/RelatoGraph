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
                output += i;
            }
            return output.ToString();
        }

        public String returnList(List<char> list)
        {
            String output = "";
            foreach (char c in list)
            {
                output += c;
            }
            return output;
        }

        //   "1,2;3,4"
        public String splitRelationChar()
        {
            String relation = RelationValue;
            int length = relation.Length;
            List<List<char>> charList = new List<List<char>>();
            List<char> innerList;
            for (int i = 0; i < length; i++)
            {
                innerList = new List<char>();
                for (int x = 0; x < 3; x++)
                {
                    if (i % 2 == 0)
                    {
                        //even
                        innerList.Add(relation[i]);
                        i++;
                    }
                    else
                    {
                        //odd
                        i++;
                    }
                }
                charList.Add(innerList);
            }
            return printDoubleList(charList).ToString();
        }



        public String printDoubleList(List<List<char>> list)
        {
            String output = "";
            foreach (List<char> c in list)
            {
                output += returnList(c);
            }
            return output;
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


        /*
         * Jedes Element a aus der Quellmenge hat min. einen Partner  aus der Zielmenge
         */
        public bool isLefttotal()
        {
            //is?
            return false;
        }

        /*
         * Jedes Element b aus der Zielmenge hat min.  einen Partner a aus der Quellmenge
         */
        public bool isRighttotal()
        {
            //is?
            return false;
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

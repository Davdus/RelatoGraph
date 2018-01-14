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

        public List<int> splitSetA()
        {
            char colon = ',';
            String setA = SetA;
            String[] stringArray = setA.Split(colon);
            List<int> intList = new List<int>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                int n;
                if (!stringArray[i].Contains(",") && !Int32.TryParse(stringArray[i], out n))
                {
                    throw new InputNotIntException();
                }
                intList.Add(Int32.Parse(stringArray[i]));
            }
            return intList;
        }

        public List<int> splitSetB()
        {
            char colon = ',';
            String setB = SetB;
            String[] stringArray = setB.Split(colon);
            List<int> intList = new List<int>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                int n;
                if (!stringArray[i].Contains(",") && !Int32.TryParse(stringArray[i], out n))
                {
                    throw new InputNotIntException();
                }
                intList.Add(Int32.Parse(stringArray[i]));
            }
            return intList;
        }

        public List<List<int>> splitRelation()
        {
            char colon = ',';
            char semicolon = ';';
            String relation = RelationValue;
            int length = relation.Length;
            List<List<int>> intList = new List<List<int>>();
            List<int> innerList = new List<int>();

            String[] stringArray = relation.Split(semicolon);
            for (int x = 0; x < stringArray.Length; x++)
            {
                String[] innerStringArray = stringArray[x].Split(colon);
                for (int i = 0; i < stringArray.Length; i++)
                {
                    int n;
                    if (!stringArray[i].Contains(",") && !Int32.TryParse(stringArray[i], out n))
                    {
                        throw new InputNotIntException();
                    }
                    innerList.Add(Int32.Parse(innerStringArray[i]));
                }
                intList.Add(innerList);
            }

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

        public bool isLeftunique()
        {
            int count = splitSetA().Count;
            int counter = 0;
            int multiple = 0;

            foreach (int i in splitSetA())
            {
                int localMultiple = 0;
                foreach (List<int> list in splitRelation())
                {
                    int position1 = list.ElementAt(0);
                    if (position1 == i)
                    {
                        counter++;
                        localMultiple++;
                    }
                    if (localMultiple >= 2)
                    {
                        multiple = localMultiple;
                    }
                }
            }
            if (counter <= count && multiple < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRightunique()
        {
            int count = splitSetB().Count;
            int counter = 0;
            int multiple = 0;

            foreach (int i in splitSetB())
            {
                int localMultiple = 0;
                foreach (List<int> list in splitRelation())
                {
                    int position2 = list.ElementAt(1);
                    if (position2 == i)
                    {
                        counter++;
                        localMultiple++;
                    }
                    if (localMultiple >= 2)
                    {
                        multiple = localMultiple;
                    }
                }
            }
            if (counter <= count && multiple < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
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

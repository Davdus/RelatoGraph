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
        private List<int> set1;
        private List<int> set2;
        private List<int> graph;

        public List<int> Set1
        {
            get { return set1; }
            set
            {
                set1 = value;
            }
        }

        public List<int> Set2
        {
            get { return set2; }
            set
            {
                set2 = value;
            }
        }

        public List<int> Graph
        {
            get { return graph; }
            set
            {
                graph = value;
            }
        }

        public Relation(List<int> set1, List<int> set2, List<int> graph)
        {
            Set1 = set1;
            Set2 = set2;
            Graph = graph;
        }

        //public List<int> UserInput(char split, String text)
        //{
            
        //}

    }
}

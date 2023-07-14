using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Node
    {
        public Employee data;
        public Node pNext;
        public Node pPrevious;

        public Node()
        {
            this.data = new Employee();
            this.pNext = null;
            this.pPrevious = null;
        }

        public Node(Employee data)
        {
            this.data = data;
            this.pNext = null;
            this.pPrevious = null;
        }


    }
}

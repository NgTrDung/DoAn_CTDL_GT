using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Node
    {
        public Vocabulary data;
        public Node pNext;

        public Node()//Khởi tạo đối tượng Node mới
        {
            this.data = new Vocabulary();
            this.pNext = null;
        }

    }
}

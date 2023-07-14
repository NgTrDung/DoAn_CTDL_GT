using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Hash_Table
    {
        public Linked_List[] hstbl;
        private const int MAX = 101;

        public Hash_Table()//Khởi tạo 1 Hash Table mới
        {
            this.hstbl = new Linked_List[MAX];
            for (int i = 0; i < MAX; i++)
            {
                hstbl[i] = new Linked_List();
            }
        }

    }
}

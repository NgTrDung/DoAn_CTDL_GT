using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Threading;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Program
    {
        private const int M = 101;

        public static int Kiem_Tra_Nhap_Chuan()
        {
            int n;
            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("\nBan nhap sai dinh dang, vui long nhap lai:  ");
                }
            } while (true);
            return n;
        }

        public static int hashFunc(string New_Word)
        {
            int h = 0;
            string New_Word_Temp = New_Word.ToLower();
            for(int i=0;i<New_Word_Temp.Length;i++)
            {
                h += (int)New_Word_Temp[i] * (i + 1);
            }
            return h % M;
        }

        public static Node Create_Node(Vocabulary tuvung)
        {
            Node pTemp = new Node();
            if(pTemp==null)
            {
                Console.WriteLine("\nCap phat that bai");
                return null;
            }
            pTemp.data = tuvung;
            pTemp.pNext = null;
            return pTemp;
        }

        public static void Insert_Last_Node(Linked_List list, Node node)
        {
            Node pCheck = list.pHead;
            if(pCheck==null)
            {
                list.pHead = list.pTail = node;
            }
            else
            {
                while(pCheck.pNext!=null)
                {
                    if(string.Compare(pCheck.data.Eng,node.data.Eng,true)==0
                        && string.Compare(pCheck.data.Type,node.data.Type,true)==0)
                    {
                        Console.WriteLine("\nKhong the them tu da co, chi duoc phep sua lai");
                        break;
                    }
                    else
                    {
                        pCheck = pCheck.pNext;
                    }
                }
                if(string.Compare(pCheck.data.Eng,node.data.Eng,true)!=0 ||
                    ( string.Compare(pCheck.data.Eng, node.data.Eng, true) == 0 &&
                    string.Compare(pCheck.data.Type, node.data.Type, true) != 0) )
                {
                    pCheck.pNext = node;
                    list.pTail = node;
                }
            }
        }

        public static void Add_Vocabulary(Hash_Table bangbam, Vocabulary tuvung)
        {
            int h = hashFunc(tuvung.Eng);
            //Node pCheck = bangbam.hstbl[h].pHead;
            Node pTemp = Create_Node(tuvung);
            Insert_Last_Node(bangbam.hstbl[h], pTemp);
        }

        public static void Xuat_Node(Linked_List list)
        {
            Node pCheck = list.pHead;
            while (pCheck != null)
            {
                pCheck.data.Xuat_Vocab();
                pCheck = pCheck.pNext;
            }
        }

        public static void Display_Dictionary(Hash_Table bangbam)
        {
            for(int i=0;i<M;i++)
            {
                if (bangbam.hstbl[i].pHead!=null)
                {
                    Console.WriteLine("\n=== KEY {0} ===", i.ToString());
                    Xuat_Node(bangbam.hstbl[i]);
                }
            }
        }

        public static void Fix_Node(Linked_List list, Node node)
        {
            Node pCheck = list.pHead;
            int dem = 0;
            while(pCheck!=null)
            {
                if(string.Compare(pCheck.data.Eng,node.data.Eng,true)==0 && 
                    string.Compare(pCheck.data.Type,node.data.Type,true)==0)
                {
                    pCheck.data.VNese = node.data.VNese;
                    dem++;
                    break;
                }
                else
                {
                    pCheck = pCheck.pNext;
                }
            }
            if(dem==0)
            {
                Console.WriteLine("\nVocab nay chua co trong tu dien nen khong the sua");
            }
        }

        public static void Update_Vocabulary(Hash_Table bangbam, Vocabulary tuvung)
        {
            int h = hashFunc(tuvung.Eng);
            if (bangbam.hstbl[h].pHead==null)
            {
                Console.WriteLine("\nVocab nay chua co trong tu dien nen khong the sua");
            }
            else
            {
                Node pTemp = Create_Node(tuvung);
                Fix_Node(bangbam.hstbl[h], pTemp);
            }
        }

        public static void Find_Node(Linked_List list, Node node)
        {
            Node pCheck = list.pHead;
            int dem = 0;
            while(pCheck!=null)
            {
                if(string.Compare(pCheck.data.Eng,node.data.Eng,true)==0 &&
                    string.Compare(pCheck.data.Type,node.data.Type,true)==0)
                {
                    Console.WriteLine("\n- {0}", pCheck.data.VNese);
                    dem++;
                    break;
                }
                pCheck = pCheck.pNext;
            }
            if(dem==0)
            {
                Console.WriteLine("\nVocab nay chua duoc them vao trong tu dien");
            }

        }

        public static void Search_Vocabulary(Hash_Table bangbam, Vocabulary tuvung)
        {
            int h = hashFunc(tuvung.Eng);
            if (bangbam.hstbl[h].pHead==null)
            {
                Console.WriteLine("\nTu vung nay chua co trong tu dien nen khong the tim");
            }
            else
            {
                Node Temp = Create_Node(tuvung);
                Find_Node(bangbam.hstbl[h], Temp);
            }
        }

        public static void Remove_Node(Linked_List list, Node node)
        {
            Node pCheck = list.pHead;
            int dem = 0;
            Node pPrevious = null;
            while(pCheck!=null)
            {
                if(string.Compare(pCheck.data.Eng,node.data.Eng,true)==0 &&
                    string.Compare(pCheck.data.Type,node.data.Type,true)==0)
                {
                    if(pPrevious==null)//remove pHead
                    {
                        list.pHead = list.pHead.pNext;
                        pCheck.pNext = null;
                    }
                    else
                    {
                        pPrevious.pNext = pCheck.pNext;
                        pCheck.pNext = null;

                    }
                    pCheck = null;
                    dem++;
                    break;
                }
                pPrevious = pCheck;
                pCheck = pCheck.pNext;
            }
            if(dem==0)
            {
                Console.WriteLine("\nTu vung nay chua duoc them vao trong tu dien nen khong the xoa");
            }
        }

        public static void Delete_Vocabulary(Hash_Table bangbam, Vocabulary tuvung)
        {
            int h = hashFunc(tuvung.Eng);
            if (bangbam.hstbl[h].pHead==null)
            {
                Console.WriteLine("\nTu vung nay chua duoc them vao tu dien nen khong the xoa");
            }
            else
            {
                Node Temp = Create_Node(tuvung);
                Remove_Node(bangbam.hstbl[h], Temp);
            }
        }

        public static void Nhap_Dictionary(Hash_Table bangbam)
        {
            Console.Write("\nNhap so luong Vocab ban dau them vao tu dien ( n <=101 ):  ");
            int n = Kiem_Tra_Nhap_Chuan();
            for(int i=0;i<n; i++)
            {
                Console.Write("\n{0}.", i.ToString());
                Vocabulary tuvung= new Vocabulary();
                tuvung.Nhap_Vocab();
                Add_Vocabulary(bangbam, tuvung);
            }
        }

        public static void Read_File(Hash_Table bangbam)
        {
            
            FileStream f = new FileStream("F:\\Dictionary.txt", FileMode.Open);
            StreamReader a = new StreamReader(f, Encoding.UTF8);
            int dem = 0;
            //Vocabulary tuvung = new Vocabulary();
            while (dem <= M - 1)
            {
                Vocabulary tuvung = new Vocabulary();
                tuvung.Eng = a.ReadLine();
                tuvung.Type = a.ReadLine();
                tuvung.VNese = a.ReadLine();
                Add_Vocabulary(bangbam, tuvung);
                dem++;
            }
            a.Close();
        }

        public static int SizeOfList(Linked_List list)
        {
            Node pCheck=list.pHead;
            int nSize = 0;
            while(pCheck!=null)
            {
                nSize++;
                pCheck = pCheck.pNext;
            }
            return nSize;
        }

        public static int Number_Vocabulary(Hash_Table bangbam)
        {
            int nSize = 0;
            for(int i=0;i<M;i++)
            {
                if (bangbam.hstbl[i].pHead!=null)
                {
                    nSize += SizeOfList(bangbam.hstbl[i]);
                }
            }
            return nSize;
        }

        public static void So_Luong_Vocab_Hien_Tai(Hash_Table bangbam)
        {
            int nSize = Number_Vocabulary(bangbam);
            Console.WriteLine("\nTu dien hien dang co {0} Vocabulary", nSize.ToString());
        }

        public static int Design_Menu()
        {
            Thread.Sleep(250);
            Console.Clear();
            Console.Write("\n=========================== DICTIONARY BY HASH TABLE ====================================\n");
            Console.Write("|                                                                                       |\n");
            Console.Write("|                  1. Nhap So Luong Vocabulary Ban Dau Them Vao Dictionary              |\n");
            Console.Write("|                  2. Them Vocabulary Moi Vao Dictionary                                |\n");
            Console.Write("|                  3. Chinh Sua 1 Vocabulary                                            |\n");
            Console.Write("|                  4. Search A Vocabulary                                               |\n");
            Console.Write("|                  5. Delete A Vocabulary                                               |\n");
            Console.Write("|                  6. Display All Vocabulary                                            |\n");
            Console.Write("|                  7. Tao Vocab Tu 1 File Co San                                        |\n");
            Console.Write("|                                                                                       |\n");
            Console.Write("|                  8. Thoat Chuong Trinh                                                |\n");
            Console.Write("|                                                                                       |\n");
            Console.Write("=========================================================================================\n");
            Console.Write("\nBan chon:  ");
            int user_chucnang;
            do
            {
                user_chucnang = Kiem_Tra_Nhap_Chuan();
                if (user_chucnang >= 1 && user_chucnang <= 8)
                {
                    break;
                }
                else
                {
                    Console.Write("\nMoi ban nhap dung chuc nang cua chuong trinh ( 1 -> 8 ), moi ban nhap lai:  ");
                }
            } while (true);
            return user_chucnang;
        }

        public static void Thoat_Chuong_Trinh(Hash_Table bangbam)
        {
            Console.Write("\nGo phim \" 1 \" de den voi Menu\n\nGo phim \" 0 \" de thoat chuong trinh\n");
            Console.Write("\nBan chon:  ");
            int user_chon;
            do
            {
                user_chon = Kiem_Tra_Nhap_Chuan();
                if (user_chon == 0)
                {
                    Thread.Sleep(250);
                    Console.Clear();
                    Console.Write("\nCam on ban da su dung chuong trinh\n");
                    Console.Write("\nChuong trinh duoc thuc hien boi:\n\nNguyen Trong Dung - 21133021\nLe Thai Duong - 21133095\n\n");
                    Environment.Exit(0);
                }
                else if (user_chon == 1)
                {
                    break;
                }
                else
                {
                    Console.Write("\nBan da nhap sai, vui long nhap \" 1 \" hoac \" 0 \", moi ban nhap lai:  ");
                }
            } while (true);
        }

        public static void End_Chuc_Nang(Hash_Table bangbam)
        {
            Console.Write("\n\n---------------------\nTask Completed!\n");
            Thoat_Chuong_Trinh(bangbam);
        }

        public static void Nhap_Eng_Va_Type(Vocabulary tuvung)
        {
            Console.Write("\nNhap Eng:  ");
            tuvung.Eng = Console.ReadLine();
            Console.Write("Nhap Type:  ");
            tuvung.Type = Console.ReadLine();
        }

        public static void Active_Program()
        {
            Hash_Table bangbam = new Hash_Table();
            Console.WriteLine("\nChao mung den voi chuong trinh Tu Dien bang Hash Table");
            Thoat_Chuong_Trinh(bangbam);
            while(true)
            {
                int user_chucnang = Design_Menu();
                switch(user_chucnang)
                {
                    case 1:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n1. Nhap So Luong Vocabulary Ban Dau Them Vao Dictionary");
                        Nhap_Dictionary(bangbam);
                        End_Chuc_Nang(bangbam);
                        break;
                    case 2:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n2. Them Vocabulary Moi Vao Dictionary");
                        So_Luong_Vocab_Hien_Tai(bangbam);
                        Vocabulary tuvung2 = new Vocabulary();
                        tuvung2.Nhap_Vocab();
                        Add_Vocabulary(bangbam, tuvung2);
                        End_Chuc_Nang(bangbam);
                        break;
                    case 3:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n3. Chinh Sua 1 Vocabulary");
                        So_Luong_Vocab_Hien_Tai(bangbam);
                        if(Number_Vocabulary(bangbam) == 0)
                        {
                            Console.WriteLine("\nTu dien dang rong nen khong the thuc hien chuc nang nay");
                        }
                        else
                        {
                            Vocabulary tuvung3 = new Vocabulary();
                            Console.WriteLine("\nNhap Eng va Type cua tu muon doi:");
                            Nhap_Eng_Va_Type(tuvung3);
                            Console.Write("\nNhap VNese muon doi thanh:  ");
                            tuvung3.VNese = Console.ReadLine();
                            Update_Vocabulary(bangbam, tuvung3);
                        }
                        End_Chuc_Nang(bangbam);
                        break;
                    case 4:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n4. Search A Vocabulary");
                        So_Luong_Vocab_Hien_Tai(bangbam);
                        if (Number_Vocabulary(bangbam) == 0)
                        {
                            Console.WriteLine("\nTu dien dang rong nen khong the thuc hien chuc nang nay");
                        }
                        else
                        {
                            Console.WriteLine("\nNhap Eng va Type cua tu muon tim:");
                            Vocabulary tuvung4 = new Vocabulary();
                            Nhap_Eng_Va_Type(tuvung4);
                            Search_Vocabulary(bangbam, tuvung4);
                        }
                        End_Chuc_Nang(bangbam);
                        break;
                    case 5:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n5. Delete A Vocabulary");
                        So_Luong_Vocab_Hien_Tai(bangbam);
                        if (Number_Vocabulary(bangbam) == 0)
                        {
                            Console.WriteLine("\nTu dien dang rong nen khong the thuc hien chuc nang nay");
                        }
                        else
                        {
                            Console.WriteLine("\nNhap Eng va Type cua tu muon xoa:");
                            Vocabulary tuvung5 = new Vocabulary();
                            Nhap_Eng_Va_Type(tuvung5);
                            Delete_Vocabulary(bangbam, tuvung5);
                        }
                        End_Chuc_Nang(bangbam);
                        break;
                    case 6:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n6. Display All Vocabulary");
                        So_Luong_Vocab_Hien_Tai(bangbam);
                        if (Number_Vocabulary(bangbam) == 0)
                        {
                            Console.WriteLine("\nTu dien dang rong nen khong the thuc hien chuc nang nay");
                        }
                        Display_Dictionary(bangbam);
                        End_Chuc_Nang(bangbam);
                        break;
                    case 7:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n7. Tao Vocab Tu 1 File Co San");
                        Read_File(bangbam);
                        End_Chuc_Nang(bangbam);
                        break;
                    case 8:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\nBan chac chan muon thoat?");
                        Thoat_Chuong_Trinh(bangbam);
                        break;

                }
            }

        }

        static void Main(string[] args)
        {
            Active_Program();
        }
    }
}
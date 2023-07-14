using System.Collections;
using System.Collections.Generic;
using System.Runtime;

namespace Demo_Main
{
    class Program
    {

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

        public static bool Is_Empty_Stack(Linked_Stack stack)
        {
            if(stack.Top== null)
            {
                return true;
            }
            return false;
        }

        public static Node Create_Node(int n)
        {
            Node pNode = new Node();
            if(pNode==null)
            {
                Console.WriteLine("\nCap phat bo nho that bai");
                return pNode = null;
            }
            pNode.data = n;
            pNode.pNext = null;
            return pNode;
        }

        public static void Push(Linked_Stack stack, Node data)
        {
            data.pNext = stack.Top;
            stack.Top = data;
        }

        public static int Top(Linked_Stack stack)
        {
            return stack.Top.data;
        }

        public static int Pop(Linked_Stack stack)
        {
            Node pTemp = stack.Top;
            int data_Temp = stack.Top.data;
            stack.Top = stack.Top.pNext;
            pTemp.pNext = null;
            pTemp = null;
            return data_Temp;
        }

        public static int Giai_Thua(Linked_Stack stack, int n)
        {
            if(n<0)
            {
                Console.WriteLine("\nKhong tinh giai thua voi so nguyen n < 0");
                return -1;
            }
            while(n!=0)
            {
                Node pTemp=Create_Node(n);
                Push(stack, pTemp);
                n--;
            }
            int result = 1;
            while(Is_Empty_Stack(stack)==false)
            {
                int Temp = Pop(stack);
                result *= Temp;
            }
            return result;
        }

        public static string For_16(int n)
        {
            string result = "";
            if(n<10)
            {
                result = n.ToString();
            }
            else
            {
                switch(n)
                {
                    case 10:
                        result = "A";
                        break;
                    case 11:
                        result = "B";
                        break;
                    case 12:
                        result = "C";
                        break;
                    case 13:
                        result = "D";
                        break;
                    case 14:
                        result = "E";
                        break;
                    case 15: 
                        result = "F";
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public static void Doi_Co_So(Linked_Stack stack, int n, int bon)
        {
            if(n<=0)
            {
                Console.WriteLine("0");
            }
            while(n>0)
            {
                int r = n % bon;
                Node pTemp = Create_Node(r);
                Push(stack, pTemp);
                n = n / bon;
            }
            string result = "";
            while (Is_Empty_Stack(stack)==false)
            {
                int x = Pop(stack);
                result = For_16(x);
                Console.Write(result);
            }
            Console.WriteLine();
        }

        public static int Design_Menu()
        {
            Thread.Sleep(250);
            Console.Clear();
            Console.Write("\n=========================== STACK AND APPLICATION OF ITS ====================================\n");
            Console.Write("|                                                                                           |\n");
            Console.Write("|          1. Tinh Giai Thua Cua 1 So Nguyen ( int )                                        |\n");
            Console.Write("|          2. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 2 ( Convert Decimal to Binary )       |\n");
            Console.Write("|          3. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 8 ( Convert Decimal to Octal )        |\n");
            Console.Write("|          4. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 16 ( Convert Decimal to Hex )         |\n");
            Console.Write("|                                                                                           |\n");
            Console.Write("|          5. Thoat Chuong Trinh                                                            |\n");
            Console.Write("|                                                                                           |\n");
            Console.Write("=============================================================================================\n");
            Console.Write("\nBan chon:  ");
            int user_chucnang;
            do
            {
                user_chucnang = Kiem_Tra_Nhap_Chuan();
                if (user_chucnang >= 1 && user_chucnang <= 5)
                {
                    break;
                }
                else
                {
                    Console.Write("\nMoi ban nhap dung chuc nang cua chuong trinh ( 1 -> 5 ), moi ban nhap lai:  ");
                }
            } while (true);
            return user_chucnang;
        }

        public static void Thoat_Chuong_Trinh(Linked_Stack stack)
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

        public static void End_Chuc_Nang(Linked_Stack stack)
        {
            Console.Write("\n\n---------------------\nTask Completed!\n");
            Thoat_Chuong_Trinh(stack);
        }

        public static void Active_Program()
        {
            Linked_Stack stack = new Linked_Stack();
            Console.Write("Chao mung den voi Chuong Trinh Stack And Application Of Its!\n");
            Thoat_Chuong_Trinh(stack);
            int n, result;
            string resultConvert = "";
            while (true)
            {
                while (stack.Top != null)
                {
                    int temp = Pop(stack);
                }
                int user_chucnang = Design_Menu();
                switch (user_chucnang)
                {
                    case 1:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n1. Tinh Giai Thua Cua 1 So Nguyen ( int )");
                        Console.Write("\nMoi ban nhap so nguyen (int) muon tinh giai thua:  ");
                        n = Kiem_Tra_Nhap_Chuan();
                        result = Giai_Thua(stack, n);
                        Console.WriteLine("\nKet qua:  {0}", result.ToString());
                        End_Chuc_Nang(stack);
                        break;
                    case 2:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n2. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 2 ( Convert Decimal to Binary )");
                        Console.Write("\nMoi ban nhap co so he 10 muon chuyen doi sang he 2:  ");
                        n = Kiem_Tra_Nhap_Chuan();
                        Console.Write("\nKet qua:  ");
                        Doi_Co_So(stack, n, 2);
                        End_Chuc_Nang(stack);
                        break;
                    case 3:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n3. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 8 ( Convert Decimal to Octal )");
                        Console.Write("\nMoi ban nhap co so he 10 muon chuyen doi sang he 8:  ");
                        n = Kiem_Tra_Nhap_Chuan();
                        Console.Write("\nKet qua:  ");
                        Doi_Co_So(stack, n, 8);
                        End_Chuc_Nang(stack);
                        break;
                    case 4:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n4. Chuyen Doi 1 So Nguyen Tu He 10 Sang He 16 ( Convert Decimal to Hex )");
                        Console.Write("\nMoi ban nhap co so he 10 muon chuyen doi sang he 16:  ");
                        n = Kiem_Tra_Nhap_Chuan();
                        Console.Write("\nKet qua:  ");
                        Doi_Co_So(stack, n, 16);
                        End_Chuc_Nang(stack);
                        break;
                    case 5:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n5. Thoat Chuong Trinh");
                        Console.Write("\nBan co thuc su muon thoat?\n");
                        Thoat_Chuong_Trinh(stack);
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
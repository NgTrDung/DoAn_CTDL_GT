using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Threading;
using System;
using System.Collections;

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

        public static string Tach_Ten(string data_hoten)
        {
            string[] arrTen= data_hoten.Split(' ');
            string ten_Temp = arrTen[arrTen.Length-1];
            return ten_Temp;
        }

        public static int SizeOfList(Linked_List list)
        {
            Node pTemp = list.pHead;
            int nSize = 0;
            while (pTemp != null)
            {
                pTemp = pTemp.pNext;
                nSize++;
            }
            return nSize;
        }

        public static Node CreateNode(Employee data)
        {
            Node pNode = new Node();
            if (pNode != null)
            {
                pNode.data = data;
                pNode.pNext = null;
                pNode.pPrevious = null;
            }
            else
            {
                Console.WriteLine("\nCap phat bo nho that bai");
                return null;
            }
            return pNode;
        }

        public static bool Check_Empty_List(Linked_List list)
        {
            Node pNode = list.pHead;
            if (pNode == null)
            {
                return true;
            }
            return false;
        }

        public static void Print_List(Linked_List list)
        {
            int n = SizeOfList(list);
            Node pTemp = list.pHead;
            Console.WriteLine("\nDanh sach Employee hien tai: {0}", n.ToString());
            if (pTemp == null)
            {
                Console.WriteLine("\nDanh sach rong!");
            }
            int i = 1;
            while (pTemp != null)
            {
                Console.Write("\n - Employee ({0}) - Vi tri ({1})", i.ToString(), (i - 1).ToString());
                pTemp.data.Xuat_Employee();
                pTemp = pTemp.pNext;
                i++;
            }
        }

        public static void Insert_First(Linked_List list, Node data)
        {
            if (list.pHead == null)
            {
                list.pHead = list.pTail = data;
            }
            else
            {
                data.pNext = list.pHead;
                list.pHead.pPrevious = data;
                list.pHead = data;
            }
        }

        public static void Insert_Last(Linked_List list, Node data)
        {
            if (list.pHead == null)
            {
                list.pHead = list.pTail = data;
            }
            else
            {
                list.pTail.pNext = data;
                data.pPrevious = list.pTail;
                list.pTail = data;
            }
        }

        public static void Insert_Mid(Linked_List list, out int vitri, Node data)
        {
            Console.Write("\nNhap vi tri Employee ma ban muon chen Employee moi vao sau no bang Insert_Mid:  ");
            vitri = Kiem_Tra_Nhap_Chuan();
            while (vitri < 0 || vitri >= SizeOfList(list))
            {
                Console.Write("\nBan da nhap sai vi tri, moi ban nhap lai:  ");
                vitri = int.Parse(Console.ReadLine());
            }
            if (vitri == SizeOfList(list) - 1)
            {
                Insert_Last(list, data);
            }
            else
            {
                Node pInsert = list.pHead;
                int i = 0;
                while (pInsert != null)
                {
                    if (i == vitri)
                    {
                        break;
                    }
                    pInsert = pInsert.pNext;
                    i++;
                }
                data.pNext = pInsert.pNext;
                data.pPrevious = pInsert;
                pInsert.pNext.pPrevious = data;
                pInsert.pNext = data;
            }
        }

        public static void Remove_First(Linked_List list)
        {
            Node pTemp = list.pHead;
            if (pTemp == null)
            {
                Console.WriteLine("\nDanh sach rong nen khong the thuc hien chuc nag nay!");
            }
            else
            {
                list.pHead = list.pHead.pNext;
                list.pHead.pPrevious = null;
                pTemp.pNext = null;
                pTemp.pPrevious = null;
                pTemp = null;
            }
        }

        public static void Remove_Last(Linked_List list)
        {
            Node pTemp = list.pTail;
            if (list.pTail == null)
            {
                Console.Write("\nDanh sach rong!");
            }
            else
            {
                list.pTail = list.pTail.pPrevious;
                list.pTail.pNext = null;
                pTemp.pNext = null;
                pTemp.pPrevious = null;
                pTemp = null;

            }
        }

        public static void Remove_Mid(Linked_List list, out int vitri)
        {
            vitri = Kiem_Tra_Nhap_Chuan();
            while (vitri < 0 || vitri >= SizeOfList(list) - 1)
            {
                Console.Write("\nBan da nhap sai vi tri, moi ban nhap lai:  ");
                vitri = int.Parse(Console.ReadLine());
            }
            if (vitri == SizeOfList(list) - 2)
            {
                Remove_Last(list);
            }
            else
            {
                int i = 0;
                Node pRemove = list.pHead;
                Node pPre_Remove = new Node();
                if (pRemove == null)
                {
                    Console.Write("\nDanh sach rong!");
                    return;
                }
                while (pRemove != null)
                {
                    pPre_Remove = pRemove;
                    pRemove = pRemove.pNext;
                    if (i == vitri)
                    {
                        break;
                    }
                    i++;
                }
                pPre_Remove.pNext = pRemove.pNext;
                pRemove.pNext.pPrevious = pPre_Remove;
                pRemove.pPrevious = null;
                pRemove.pNext = null;
                pRemove = null;
            }
        }

        public static void Tim_Kiem_Employee_Theo_SDT(Linked_List list, Employee data)
        {
            if (list.pHead == null)
            {
                Console.WriteLine("\nDanh sach hien tai dang bi rong nen khong the thuc hien chuc nang nay");
            }
            else
            {
                Console.Write("\nNhap So Dien Thoai cua Employee ma ban muon tim trong danh sach:  ");
                data.SoDienThoai = Console.ReadLine();
                Node pTemp = list.pHead;
                int i = 1, dem = 0;
                while (pTemp != null)
                {
                    if (string.Compare(pTemp.data.SoDienThoai, data.SoDienThoai, true) == 0)
                    {
                        Console.WriteLine("\nDa tim thay Employee: {0} o vi tri thu {1} trong danh sach", pTemp.data.HoVaTen, (i - 1).ToString());
                        dem++;
                        break;
                    }
                    pTemp = pTemp.pNext;
                    i++;
                }
                if(dem==0)
                {
                    Console.WriteLine("\nKhong co Employee nao co So Dien Thoai: {0} trong danh sach", data.SoDienThoai);
                }
            }
        }

        public static bool Kiem_Tra_Date_Lon_Hon(Date data1, Date data2)
        {
            if (data2.Nam > data1.Nam)
            {
                return true;
            }
            else if (data2.Nam == data1.Nam)
            {
                if (data2.Thang > data1.Thang)
                {
                    return true;
                }
                else if (data2.Thang == data1.Thang)
                {
                    if (data2.Ngay > data1.Ngay)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void Danh_Sach_Employee_Vao_Lam_Sau_Ngay_Cho_Truoc(Linked_List list, Employee data)
        {
            if(list.pHead==null)
            {
                Console.WriteLine("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay");
            }
            else
            {
                Console.Write("\nNhap ngay, thang, nam ma ban muon so sanh de tim Employee di lam sau ngay nay (dd/mm/yy):  ");
                data.HireDay.Nhap_Date();
                Node pTemp = list.pHead;
                int i = 1, dem = 0;
                while(pTemp != null)
                {
                    if(Kiem_Tra_Date_Lon_Hon(data.HireDay,pTemp.data.HireDay) == true)
                    {
                        Console.WriteLine("\n - Employee ({0}) - Vi tri ({1})", i.ToString(), (i - 1).ToString());
                        pTemp.data.Xuat_Employee();
                        dem++;
                    }
                    i++;
                    pTemp = pTemp.pNext;
                }
                if(i==0)
                {
                    Console.Write("\nKhong co Employee nao di lam sau ngay ");
                    data.HireDay.Xuat_Date();
                }
                else
                {
                    Console.WriteLine("\nTong cong co {0} Employee vao lam sau ngay ",dem);
                    data.HireDay.Xuat_Date();
                }

            }
        }

        public static void Nhap_Danh_Sach_Employee(Linked_List list)
        {
            Console.Write("\nNhap so luong Employee trong danh sach ban dau:  ");
            int n;
            n = Kiem_Tra_Nhap_Chuan();
            for (int i = 0; i < n; i++)
            {
                Employee data = new Employee();
                data.Nhap_Employee();
                Node Temp = CreateNode(data);
                Insert_Last(list, Temp);
            }
        }

        public static void Sort_List_Selection_Sort(Linked_List list)
        {
            //Trường hợp danh sách rỗng hoặc chỉ có 1 phần từ
            if (list.pHead == list.pTail)
            {
                Console.WriteLine("\nDanh sach co it hon 2 Employee nen khong the sap xep");
            }
            else
            {
                int minPos;
                int n = SizeOfList(list);
                Node pI = list.pHead;
                for (int i = 0; i < n - 1; i++)
                {
                    minPos = i;
                    Node MinPos = pI;
                    Node pJ = pI.pNext;
                    for (int j = i + 1; j < n; j++)
                    {
                        string ten_MinPos = Tach_Ten(MinPos.data.HoVaTen);
                        string ten_pJ = Tach_Ten(pJ.data.HoVaTen);
                        if ((int)ten_pJ[0] < (int)ten_MinPos[0] || string.Compare(ten_pJ,ten_MinPos,true)<0)
                        {
                            minPos = j;
                            MinPos = pJ;
                        }
                        pJ = pJ.pNext;

                    }
                    if(minPos!=i)
                    {
                        Employee Temp = pI.data;
                        pI.data = MinPos.data;
                        MinPos.data = Temp;
                    }
                    pI = pI.pNext;
                }
            }
        }

        public static void Sort_List_Quick_Sort(Linked_List mylist)
        {
            if (SizeOfList(mylist)>=2)
            {
                Linked_List mylist1 = new Linked_List();
                Linked_List mylist2 = new Linked_List();
                Node pivot;
                Node p;
                //Phân hoạch danh sách thành 2 danh sách con
                pivot = mylist.pHead; //Phần tử cầm canh
                p = mylist.pHead.pNext;
                while (p != null)
                {
                    Node q = p;
                    p = p.pNext;
                    q.pNext = null;
                    string ten_q = Tach_Ten(q.data.HoVaTen);
                    string ten_pivot = Tach_Ten(pivot.data.HoVaTen);
                    if ((int)ten_q[0] < (int)ten_pivot[0] || string.Compare(ten_q, ten_pivot, true) < 0)
                    {
                        Insert_Last(mylist1, q);//Thêm vào danh sách 1 các Employee có tên đứng trước tên Employee ở pivot
                    }
                    else
                    {
                        Insert_Last(mylist2, q);//Thêm vào danh sách 1 các Employee có tên đứng sau tên Employee ở pivot
                    }
                };
                //Gọi đệ quy để sắp xếp cho các danh sách con
                Sort_List_Quick_Sort(mylist1);
                Sort_List_Quick_Sort(mylist2);
                //Ghép nối danh sách 1 + pivot
                if (!Check_Empty_List(mylist1))
                {
                    mylist.pHead = mylist1.pHead;
                    mylist1.pTail.pNext = pivot;
                }
                else
                {
                    mylist.pHead = pivot;
                }
                //Ghép nối danh sách 2
                pivot.pNext = mylist2.pHead;
                if (!Check_Empty_List(mylist2))
                {
                    mylist.pTail = mylist2.pTail;
                }
                else
                {
                    mylist.pTail = pivot;
                }
            }
            else //Trường hợp danh sách rỗng hoặc chỉ có 1 phần tử
            {
                //Console.WriteLine("\nDanh sach co it hon 2 Employee nen khong the sap xep");
                return;
            }
        }

        public static void Merge_Two_List(Linked_List list1)
        {
            Linked_List list2 = new Linked_List();
            Console.WriteLine("\nKhoi dao Linked List thu 2 ...");
            Nhap_Danh_Sach_Employee(list2);
            Node pTemp = list2.pHead;
            while(pTemp != null )
            {
                Insert_Last(list1, pTemp);
                pTemp = pTemp.pNext;
            }
            Sort_List_Selection_Sort(list1);
        }

        public static void Xoa_Employee_Di_Lam_Truoc_Ngay_Duoc_Nhap(Linked_List list, Employee data)
        {
            Linked_List list_Temp = new Linked_List();
            Console.WriteLine("\nNhap ngay ma ban muon dung de xoa Employees di lam truoc ngay nay (dd/mm/yy):  ");
            data.HireDay.Nhap_Date();
            Node pRemove = list.pHead;
            int i = 0;
            while(pRemove!=null)
            {
                if(Kiem_Tra_Date_Lon_Hon(pRemove.data.HireDay,data.HireDay)==false)
                {
                    Insert_Last(list_Temp, pRemove);
                }
                pRemove = pRemove.pNext;
            }
            list = list_Temp;
        }

        public static Node Employee_Lon_Tuoi_Nhat(Linked_List list)
        {
            Node data_compare_min = list.pHead;
            Node pTemp = list.pHead.pNext;
            while(pTemp!=null)
            {
                if(Kiem_Tra_Date_Lon_Hon(pTemp.data.BirthDay,data_compare_min.data.BirthDay)==true)
                {
                    data_compare_min = pTemp;
                }
                pTemp = pTemp.pNext;
            }
            return data_compare_min;
        }

        public static int Design_Menu()
        {
            Thread.Sleep(250);
            Console.Clear();
            Console.Write("\n=========================== EMPLOYEE MANAGEMENT PROGRAM BY LINKED LIST ====================================\n");
            Console.Write("|                                                                                                          |\n");
            Console.Write("|                        1. Nhap Danh Sach Employee                                                        |\n");
            Console.Write("|                        2. Xuat Danh Sach Employee Hien Tai                                               |\n");
            Console.Write("|                        3. Chen Them Employee Vao Dau Danh Sach Employee Hien Tai                         |\n");
            Console.Write("|                        4. Chen Them Employee Vao Cuoi Danh Sach Employee Hien Tai                        |\n");
            Console.Write("|                        5. Chen Them Employee Vao Sau 1 Vi Tri Ma Ban Muon                                |\n");
            Console.Write("|                        6. Xoa Employee O Vi Tri Dau Danh Sach Employee Hien Tai                          |\n");
            Console.Write("|                        7. Xoa Employee O Vi Tri Cuoi Danh Sach Employee Hien Tai                         |\n");
            Console.Write("|                        8. Xoa Employee O 1 Vi Tri Ma Ban Muon                                            |\n");
            Console.Write("|                        9. Tim 1 Employee Theo So Dien Thoai ( SDT )                                      |\n");
            Console.Write("|                        10. Xuat Danh Sach Employee Di Lam Sau Ngay, Thang, Nam Ma Ban Muon Tim           |\n");
            Console.Write("|                        11. Sap Xep Danh Sach Employee Theo Alphabet (Selection Sort)                     |\n");
            Console.Write("|                        12. Sap Xep Danh Sach Employee Theo Alphabet (Quick Sort)                         |\n");
            Console.Write("|                        13. Gop 2 Danh Sach Employee                                                      |\n");
            Console.Write("|                        14. Lay Danh Sach Employee Di Lam Sau Ngay Ban Muon Tim                           |\n");
            Console.Write("|                        15. Lay Thong Tin Employee Lon Tuoi Nhat                                          |\n");
            Console.Write("|                                                                                                          |\n");
            Console.Write("|                        16. Thoat Chuong Trinh                                                            |\n");
            Console.Write("|                                                                                                          |\n");
            Console.Write("============================================================================================================\n");
            Console.Write("\nBan chon:  ");
            int user_chucnang;
            do
            {
                user_chucnang = Kiem_Tra_Nhap_Chuan();
                if (user_chucnang >= 1 && user_chucnang <= 16)
                {
                    break;
                }
                else
                {
                    Console.Write("\nMoi ban nhap dung chuc nang cua chuong trinh ( 1 -> 16 ), moi ban nhap lai:  ");
                }
            } while (true);
            return user_chucnang;
        }

        public static void Thoat_Chuong_Trinh(Linked_List list)
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

        public static void So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(Linked_List list)
        {
            int n = SizeOfList(list);
            Console.Write("\nHien tai dang co {0} Employee trong danh sach\n", n);
        }

        public static void End_Chuc_Nang(Linked_List list)
        {
            Console.Write("\n\n---------------------\nTask Completed!\n");
            Thoat_Chuong_Trinh(list);
        }

        public static void Active_Program()
        {
            Linked_List list1 = new Linked_List();
            Console.Write("Chao mung den voi Chuong Trinh Quan Ly Nhan Vien Bang Double List!\n");
            Thoat_Chuong_Trinh(list1);
            int count_case1 = 0;
            int vitri;
            while(true)
            {
                Employee data = new Employee();
                Node Temp = new Node();
                int user_chucnang = Design_Menu();
                switch(user_chucnang)
                {
                    case 1:
                        Thread.Sleep(250);
                        Console.Clear() ;
                        Console.Write("\n1. Nhap Danh Sach Employee\n");
                        if (count_case1 != 0)
                        {
                            Console.Write("\nKhong the nhap them 1 danh sach moi, vui long chon 3.  4.  5.  13.  de tao them Employee trong danh sach!\n");
                            Thoat_Chuong_Trinh(list1);
                        }
                        else
                        {
                            Nhap_Danh_Sach_Employee(list1);
                            count_case1 = 1;
                            End_Chuc_Nang(list1);
                        }
                        break;
                    case 2:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n2. Xuat Danh Sach Employee Hien Tai\n");
                        Print_List(list1);
                        End_Chuc_Nang(list1);
                        break;
                    case 3:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n3. Chen Them Employee Vao Dau Danh Sach Employee Hien Tai\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        Console.Write("\nNhap thong tin Employee muon them vao dau danh sach:\n");
                        data.Nhap_Employee();
                        Temp = CreateNode(data);
                        Insert_First(list1, Temp);
                        End_Chuc_Nang(list1);
                        break;
                    case 4:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n4. Chen Them Employee Vao Cuoi Danh Sach Employee Hien Tai\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        Console.Write("\nNhap thong tin Employee muon them vao cuoi danh sach:\n");
                        data.Nhap_Employee();
                        Temp = CreateNode(data);
                        Insert_Last(list1, Temp);
                        End_Chuc_Nang(list1);
                        break;
                    case 5:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n5. Chen Them Employee Vao Sau 1 Vi Tri Ma Ban Muon\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (list1.pHead == null)
                        {
                            Console.Write("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay!\n");
                        }
                        else
                        {
                            Console.Write("\nNhap thong tin Employee muon them vao sau 1 vi tri cu the trong danh sach:\n");
                            data.Nhap_Employee();
                            Temp = CreateNode(data);
                            Insert_Mid(list1, out vitri, Temp);
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 6:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n6. Xoa Employee O Vi Tri Dau Danh Sach Employee Hien Tai\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (SizeOfList(list1) >= 2)
                        {
                            Console.Write("\nStarting delete Employee o dau danh sach ...\n");
                            Remove_First(list1);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.Write("\nSo luong Employee trong danh sach < 2 nen khong the thuc hien chuc nang nay\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 7:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n7. Xoa Employee O Vi Tri Cuoi Danh Sach Employee Hien Tai\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (SizeOfList(list1) >= 2)
                        {
                            Console.Write("\nStarting delete Employee o cuoi danh sach ...\n");
                            Remove_Last(list1);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.Write("\nSo luong Employee trong danh sach < 2 nen khong the thuc hien chuc nang nay\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 8:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n8. Xoa Employee O 1 Vi Tri Ma Ban Muon\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (list1.pHead == null)
                        {
                            Console.Write("\nDanh sach hien tai dang rong nen khong the thuc hien chuc nang nay!\n");
                        }
                        else
                        {
                            Remove_Mid(list1, out vitri);
                            Console.Write("\nStarting delete Employee o vi tri thu {0} trong danh sach ...\n", (vitri+1).ToString());
                            Thread.Sleep(1500);
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 9:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n9. Tim 1 Employee Theo So Dien Thoai ( SDT )\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        Tim_Kiem_Employee_Theo_SDT(list1, data);
                        End_Chuc_Nang(list1);
                        break;
                    case 10:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n10. Xuat Danh Sach Employee Di Lam Sau Ngay, Thang, Nam Ma Ban Muon Tim\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        Danh_Sach_Employee_Vao_Lam_Sau_Ngay_Cho_Truoc(list1, data);
                        End_Chuc_Nang(list1);
                        break;
                    case 11:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n11. Sap Xep Danh Sach Employee Theo Alphabet (Selection Sort) \n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (SizeOfList(list1) >= 2)
                        {
                            Console.Write("\nStarting Selection Sort danh sach Employee theo Alphabet ...\n");
                            Sort_List_Selection_Sort(list1);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.Write("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach < 2\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 12:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n12. Sap Xep Danh Sach Employee Theo Alphabet (Quick Sort)\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (SizeOfList(list1) >= 2)
                        {
                            Console.Write("\nStarting Quick Sort danh sach Employee theo Alphabet ...\n");
                            Sort_List_Quick_Sort(list1);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.Write("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach < 2\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 13:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n13. Gop 2 Danh Sach Employee\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (!Check_Empty_List(list1))
                        {
                            Merge_Two_List(list1);
                        }
                        else
                        {
                            Console.Write("\nKhong the thuc hien chuc nang nay vi so luong Employee trong danh sach ban dau dang rong\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 14:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n14. Lay Danh Sach Employee Di Lam Sau Ngay Ban Muon Tim\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (!Check_Empty_List(list1))
                        {
                            Console.Write("\nStarting chinh sua danh sach chi con Employee vao lam sau ");
                            data.HireDay.Xuat_Date();
                            Xoa_Employee_Di_Lam_Truoc_Ngay_Duoc_Nhap(list1, data);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            Console.Write("\nDanh sach ban dau dang rong nen khong the thuc hien chuc nang nay\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 15:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.Write("\n15. Lay Thong Tin Employee Lon Tuoi Nhat\n");
                        So_Luong_Employee_Trong_Danh_Sach_Hien_Tai(list1);
                        if (SizeOfList(list1) >= 2)
                        {
                            Console.Write("\nThong tin cua Employee lon tuoi nhat trong danh sach la:\n");
                            Node Tuoi_MAX = Employee_Lon_Tuoi_Nhat(list1);
                            Tuoi_MAX.data.Xuat_Employee();
                        }
                        else
                        {
                            Console.Write("\nSo luong Employee trong danh sach hien tai < 2 nen khong the thuc hien chuc nang nay\n");
                        }
                        End_Chuc_Nang(list1);
                        break;
                    case 16:
                        Thread.Sleep(250);
                        Console.Clear();
                        Console.WriteLine("\n16. Thoat Chuong Trinh");
                        Console.Write("\nBan co thuc su muon thoat?\n");
                        Thoat_Chuong_Trinh(list1);
                        break;
                }
            };
        }

        static void Main(string[] args)
        {
            Active_Program();

        }
    }
}
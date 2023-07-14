using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Date
    {
        private int _Ngay, _Thang, _Nam;

        public int Ngay
        {
            get { return this._Ngay; }
            set { this._Ngay = value; }
        }

        public int Thang
        {
            get { return this._Thang; }
            set { this._Thang = value; }
        }

        public int Nam
        {
            get { return this._Nam; }
            set { this._Nam = value; }
        }

        public Date()//Khởi tạo lớp Date
        {
            this._Ngay = 0;
            this._Thang = 0;
            this._Nam = 0;
        }

        public Date(int ngay, int thang, int nam)
        {
            this._Ngay = ngay;
            this._Thang = thang;
            this._Nam = nam;
        }

        private bool Check_Nam_Nhuan()
        {
            if(this._Nam%400 == 0 || (this._Nam%4==0 && this._Nam%100!=0))
            {
                return true;
            }
            return false;
        }

        private bool Check_Date()
        {
            int temp = this._Thang;
            switch(temp)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    if(this._Ngay >= 1 && this._Ngay <= 31)
                    {
                        return true;
                    }
                    break;
                case 4: case 6: case 9: case 11:
                    if(this._Ngay >= 1 && this._Ngay <= 30)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if( (this.Check_Nam_Nhuan() == true && (this._Ngay >= 1 && this._Ngay <= 29)) || (this.Check_Nam_Nhuan() == false && (this._Ngay >= 1 && this._Ngay <= 28)) )
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private void Import_Date()
        {
            try
            {
                /*this._Ngay = int.Parse(Console.ReadLine());
                this._Thang = int.Parse(Console.ReadLine());
                this._Nam = int.Parse(Console.ReadLine());*/
                string chuoiDate = Console.ReadLine();
                string[] arrDate = chuoiDate.Split('/');
                this._Ngay = int.Parse(arrDate[0]);
                this._Thang = int.Parse(arrDate[1]);
                this._Nam = int.Parse(arrDate[2]);
            }
            catch (Exception)
            {
                Console.WriteLine("\nNhap sai dinh dang, phai nhap so nguyen (int)");
            }
        }

        public void Nhap_Date()
        {
            this.Import_Date();
            while(this.Check_Date()==false)
            {
                Console.Write("\nBan da nhap sai ngay, thang, nam cua nhan vien, de nghi nhap lai:  ");
                this.Import_Date();
            }
        }

        public void Xuat_Date()
        {
            Console.WriteLine("{0} / {1} / {2}",this._Ngay.ToString(),this._Thang.ToString(),this._Nam.ToString());
        }
    }
}

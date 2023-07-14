using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Employee
    {
        private string _HoVaTen, _SoDienThoai;
        private Date _BirthDay, _HireDay;

        public string HoVaTen
        {
            get { return this._HoVaTen; }
            set { this._HoVaTen = value; }
        }

        public string SoDienThoai
        {
            get { return this._SoDienThoai; }
            set { this._SoDienThoai = value; }
        }

        public Date BirthDay
        {
            get { return this._BirthDay; }
            set { this._BirthDay = value; }
        }

        public Date HireDay
        {
            get { return this._HireDay; }
            set { this._HireDay = value;}
        }

        public Employee()//Khởi tạo đối tượng Employee mới
        {
            this._HoVaTen = "";
            this._SoDienThoai = "";
            this._BirthDay = new Date();
            this._HireDay = new Date();
        }

        public Employee(string hovaten, string sodienthoai, int ngaysinh, int thangsinh, int namsinh, int ngaylam, int thanglam, int namlam)
        {
            this._HoVaTen = hovaten;
            this._SoDienThoai = sodienthoai;
            this._BirthDay = new Date(ngaysinh, thangsinh, namsinh);
            this._HireDay = new Date(ngaylam, thanglam, namlam);
        }

        public void Nhap_Employee()
        {
            Console.Write("\nNhap Ho Va Ten:  ");
            this._HoVaTen = Console.ReadLine();
            Console.Write("Nhap So Dien Thoai:  ");
            this._SoDienThoai = Console.ReadLine();
            Console.Write("Nhap Ngay, Thang, Nam sinh cua Employee (dd/mm/yy):  ");
            this._BirthDay.Nhap_Date();
            Console.Write("Nhap Ngay, Thang, Nam vao lam cua Employee (dd/mm/yy):  ");
            this._HireDay.Nhap_Date();
        }
        
        public void Xuat_Employee()
        {
            Console.WriteLine("\nHo va Ten:  " + this._HoVaTen);
            Console.WriteLine("Phone Number:  " + this._SoDienThoai);
            Console.Write("Birth Day:  ");
            this._BirthDay.Xuat_Date();
            Console.Write("Hire Day:  ");
            this._HireDay.Xuat_Date();

        }

    }
}

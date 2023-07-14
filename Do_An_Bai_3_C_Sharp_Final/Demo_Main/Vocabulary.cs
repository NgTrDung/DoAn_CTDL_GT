using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Main
{
    class Vocabulary
    {
        private string _Eng, _Type, _VNese;

        public string Eng
        {
            get { return this._Eng; }
            set { this._Eng = value; }
        }

        public string Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        public string VNese
        {
            get { return this._VNese; }
            set { this._VNese = value; }
        }

        public Vocabulary()//Khởi tạo Vocabulay
        {

        }

        public Vocabulary(string eng, string type, string vnese)
        {
            this._Eng = eng;
            this._Type = type;
            this._VNese = vnese;
        }

        public void Nhap_Vocab()
        {
            Console.Write("\nNhap Eng:  ");
            this._Eng = Console.ReadLine();
            Console.Write("Nhap Type:  ");
            this._Type = Console.ReadLine();
            Console.Write("Nhap VNese:  ");
            this._VNese = Console.ReadLine();
        }

        public void Xuat_Vocab()
        {
            Console.WriteLine("\n- {0} ({1}): {2}", this._Eng, this._Type, this._VNese);
        }

    }
}

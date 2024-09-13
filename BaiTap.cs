using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT
{
    internal class Program
    {
        public class SinhVien
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public SinhVien(int ID, string Name, int Age)
            {
                this.ID = ID;
                this.Name = Name;
                this.Age = Age;
            }
            public override string ToString()
            {
                return ("ID:" + this.ID + " Name:" + this.Name + "  Age:" + this.Age);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var sinhvien = new List<SinhVien>
            {
                new SinhVien(1, "Cúc",  17),
                new SinhVien(2, "Dân",  18),
                new SinhVien(3, "An",  20),
                new SinhVien(4, "Duyên",  25),
                new SinhVien(5, "Ánh",  56)

            };
            Console.WriteLine("Danh sách các sinh viên:");
            foreach (var s in sinhvien)
            {
                Console.WriteLine(s);

            }
            Console.WriteLine("Danh sách có tuổi từ 15->18:");
            var ketqua = from s in sinhvien where s.Age >= 15 && s.Age <= 18 select s;
            foreach (var sinhvienf in ketqua)
            {
                Console.WriteLine(sinhvienf.ToString());
            }
            Console.WriteLine("Danh sách sinh viên có tên bắt đầu bằng chữ A:");
            var Ketqua = from s in sinhvien where s.Name.StartsWith("A") select s;
            foreach (var sinhvieng in Ketqua)
            {
                Console.WriteLine(sinhvieng.ToString());
            }
            Console.WriteLine("Tổng tuổi của các sinh viên:");
            var KetQua = (from s in sinhvien select s.Age).Sum();
            Console.WriteLine(KetQua);
            Console.WriteLine("Sinh Vien có tuổi cao nhất là :");
            var ketQua = (from s in sinhvien orderby s.Age descending select s).FirstOrDefault();
            Console.WriteLine(ketQua);
            Console.WriteLine("Danh sách tuổi tăng dần:");
            var thutu = from s in sinhvien orderby s.Age ascending select s;
            foreach (var thutu2 in thutu)
            {
                Console.WriteLine(thutu2);
            }
            Console.ReadKey();
        }
    }
}

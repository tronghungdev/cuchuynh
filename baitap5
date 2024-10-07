using bt5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void FillcomboBox1(List<Faculty> listFalcultys)
        {
            this.cmbFaculty.DataSource = listFalcultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> listStudents)
        {
            try
            {
                dgvStudent.Rows.Clear();
                foreach (var item in listStudents)
                {
                    int index = dgvStudent.Rows.Add();
                    dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                    dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                    if (item.Faculty != null)
                    {
                        dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                    }
                    else
                    {
                        dgvStudent.Rows[index].Cells[2].Value = "Chưa có khoa"; // Hoặc giá trị mặc định khác
                    }

                    dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi hiển thị danh sách: " + ex.Message);
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();
                List<Faculty> listFalcultys = context.Faculty.ToList();
                List<Student> listStudent = context.Student.ToList();
                FillcomboBox1(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int MSSV = int.Parse(txtMSSV.Text);        // Lấy MSSV từ TextBox
                string HoTen = txtHoTen.Text;              // Lấy họ tên từ TextBox
                int FacultyID = (int)cmbFaculty.SelectedValue; // Lấy FacultyID từ ComboBox
                float DTB = float.Parse(txtDTB.Text);      // Lấy điểm trung bình từ TextBox

                using (StudentContextDB context = new StudentContextDB())
                {
                    Student st = new Student()
                    {
                        StudentID = MSSV,
                        FullName = HoTen,
                        FacultyID = FacultyID,
                        AverageScore = (decimal?)DTB
                    };
                    context.Student.Add(st);
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    BindGrid(context.Student.ToList());
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có ngoại lệ xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button2_Click(object sender, EventArgs e) //Sửa 
        {
            
                if (dgvStudent.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvStudent.SelectedRows[0];
                    var studentID = (int)selectedRow.Cells[0].Value;

                    using (StudentContextDB context = new StudentContextDB())
                    {
                        var student = context.Student.FirstOrDefault(s => s.StudentID == studentID);
                        if (student != null)
                        {
                            student.FullName = txtHoTen.Text;
                            student.FacultyID = (int)cmbFaculty.SelectedValue;
                            student.AverageScore = (decimal?)Convert.ToDecimal(txtDTB.Text);
                            context.SaveChanges();
                            BindGrid(context.Student.ToList());

                            MessageBox.Show("Cập nhật thành công!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật.");
                }
        }


    private void button3_Click(object sender, EventArgs e)//Xóa
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudent.SelectedRows[0];
                var studentID = (int)selectedRow.Cells[0].Value;

                using (StudentContextDB context = new StudentContextDB())
                {
                    var student = context.Student.FirstOrDefault(s => s.StudentID == studentID);
                    if (student != null)
                    {
                        context.Student.Remove(student);
                        context.SaveChanges();
                        BindGrid(context.Student.ToList());
                        MessageBox.Show("Xóa sinh viên thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
            }
        
    }

        private void button4_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thoát chương trình
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Lệnh thoát ứng dụng
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 formFacultyManagement = new Form2();

            // Hiển thị Form2 dưới dạng Dialog (ngăn người dùng tương tác với Form1 cho đến khi đóng Form2)
            formFacultyManagement.ShowDialog();
            Form2 form2 = new Form2();

            // Hiển thị Form quản lý Khoa dưới dạng hộp thoại
            formFacultyManagement.ShowDialog();
        }

    }
}

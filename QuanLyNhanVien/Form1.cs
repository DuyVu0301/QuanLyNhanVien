using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{

    public partial class Form1 : Form
    {

        private BindingList<NhanVien> nhanViens = new BindingList<NhanVien>();

        public Form1()
        {
            InitializeComponent();

            // Cấu hình DataGridView
            dataGridView1.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dataGridView1.Columns.Add("MSNV", "Mã số NV"); // Thêm cột Mã số NV
            dataGridView1.Columns.Add("Ten", "Tên nhân viên"); // Thêm cột Tên nhân viên
            dataGridView1.Columns.Add("LuongCoBan", "Lương cơ bản"); // Thêm cột Lương cơ bản

            // Thiết lập kiểu dữ liệu cho các cột
            dataGridView1.Columns["MSNV"].DataPropertyName = "MSNV";
            dataGridView1.Columns["Ten"].DataPropertyName = "Ten";
            dataGridView1.Columns["LuongCoBan"].DataPropertyName = "LuongCoBan";

            dataGridView1.DataSource = nhanViens; // Gán DataSource
        }

  

   

     

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien(); // Tạo mới để thêm
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                nhanViens.Add(formNhanVien.NhanVien);
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Kiểm tra có dòng nào được chọn không
            {
                NhanVien selectedNhanVien = (NhanVien)dataGridView1.SelectedRows[0].DataBoundItem;
                FormNhanVien formNhanVien = new FormNhanVien(selectedNhanVien); // Truyền đối tượng đã chọn

                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    selectedNhanVien.Ten = formNhanVien.NhanVien.Ten;
                    selectedNhanVien.LuongCoBan = formNhanVien.NhanVien.LuongCoBan;
                    dataGridView1.Refresh(); // Cập nhật DataGridView
                }
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                NhanVien selectedNhanVien = (NhanVien)dataGridView1.SelectedRows[0].DataBoundItem;
                nhanViens.Remove(selectedNhanVien);
            }
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form Chính
        }
    }
}

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


    public partial class FormNhanVien : Form
    {
        public NhanVien NhanVien { get; private set; } // Thuộc tính lưu thông tin nhân viên

        // Constructor cho trường hợp thêm nhân viên mới
        public FormNhanVien()
        {
            InitializeComponent();
            NhanVien = new NhanVien(); // Khởi tạo đối tượng mới
        }

        // Constructor cho trường hợp sửa nhân viên
        public FormNhanVien(NhanVien nhanVien) : this()
        {
            NhanVien = nhanVien; // Gán đối tượng đã chọn
            txtMSNV.Text = nhanVien.MSNV.ToString();
            txtTen.Text = nhanVien.Ten;
            txtLuongCoBan.Text = nhanVien.LuongCoBan.ToString();
        }

        // Xử lý khi nhấn nút Đồng ý
   

    

        private void btnDongY_Click_1(object sender, EventArgs e)
        {
            NhanVien.MSNV = int.Parse(txtMSNV.Text);
            NhanVien.Ten = txtTen.Text;
            NhanVien.LuongCoBan = decimal.Parse(txtLuongCoBan.Text);
            DialogResult = DialogResult.OK; // Thông báo Form Chính biết đã hoàn tất
            Close(); // Đóng Form Nhân viên
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form Nhân viên mà không lưu
        }

    }
}

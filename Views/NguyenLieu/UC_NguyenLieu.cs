using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTTQ_BTL.Dao;

namespace LTTQ_BTL.Views.NguyenLieu
{
    public partial class UC_NguyenLieu : UserControl
    {
        public UC_NguyenLieu()
        {
            InitializeComponent();
            this.Load += UC_NguyenLieu_Load;
        }

        private void DinhDangDGV()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["MaNguyenLieu"].HeaderText = "Mã nguyên liệu";
            dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Tên nguyên liệu";
            dataGridView1.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns["DonGiaBan"].HeaderText = "Đơn giá bán";
            dataGridView1.Columns["CongDung"].HeaderText = "Công dụng";
            dataGridView1.Columns["YeuCau"].HeaderText = "Yêu cầu";
            dataGridView1.Columns["ChongChiDinh"].HeaderText = "Chống chỉ định";

            dataGridView1.Columns["MaNguyenLieu"].FillWeight = 10;
            dataGridView1.Columns["TenNguyenLieu"].FillWeight = 40;
            dataGridView1.Columns["DonViTinh"].FillWeight = 10;
            dataGridView1.Columns["SoLuong"].FillWeight = 10;
            dataGridView1.Columns["DonGiaNhap"].FillWeight = 10;
            dataGridView1.Columns["DonGiaBan"].FillWeight = 10;
            dataGridView1.Columns["CongDung"].FillWeight = 20;
            dataGridView1.Columns["YeuCau"].FillWeight = 20;
            dataGridView1.Columns["ChongChiDinh"].FillWeight = 20;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string ma = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                FormMain form = (FormMain)this.FindForm();

                UC_NhapNguyenLieu uc = new UC_NhapNguyenLieu(ma);

                form.HienThiTrang(uc);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_NguyenLieu_Load(object sender, EventArgs e)
        {
            NguyenLieuDAO dao = new NguyenLieuDAO();

            dataGridView1.DataSource = dao.DSNguyenLieu();

            DinhDangDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text.Trim();
            string congdung = textBox2.Text.Trim();
            string ccd = textBox3.Text.Trim();
            NguyenLieuDAO dao = new NguyenLieuDAO();

            dataGridView1.DataSource = dao.TimKiem(ten, congdung, ccd);

            DinhDangDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string ma = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                FormMain form = (FormMain)this.FindForm();

                UC_SuaNguyenLieu uc = new UC_SuaNguyenLieu(ma);

                form.HienThiTrang(uc);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

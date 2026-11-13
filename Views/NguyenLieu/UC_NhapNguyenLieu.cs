using LTTQ_BTL.BLL;
using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.NguyenLieu
{
    public partial class UC_NhapNguyenLieu : UserControl
    {
        string maNL;
        NguyenLieuBLL bll1 = new NguyenLieuBLL();
        HoaDonNhapDao bll2 = new HoaDonNhapDao(); 
        public UC_NhapNguyenLieu(string ma)
        {
            InitializeComponent();
            maNL = ma;
        }

        private void UC_NhapNguyenLieu_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = bll1.LayTheoMa(maNL);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                textBox6.Text = dt1.Rows[0][1]?.ToString() ?? "";
                textBox6.Enabled = false;

                textBox7.Text = dt1.Rows[0][0]?.ToString() ?? "";
                textBox7.Enabled = false;

                textBox1.Text = dt1.Rows[0][5]?.ToString() ?? "";
                textBox1.Enabled = false;

                DataTable dt2 = bll1.DSNhanVien();
                comboBox3.DataSource = dt2;
                comboBox3.DisplayMember = "TenNhanVien";
                comboBox3.ValueMember = "MaNhanVien";

                DataTable dt3 = bll1.DSNhaCungCap();
                comboBox4.DataSource = dt3;
                comboBox4.DisplayMember = "TenNhaCungCap";
                comboBox4.ValueMember = "MaNhaCungCap";

                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;

                textBox4.ReadOnly = true;
                textBox4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TinhThanhTien(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal dongia) &&
                decimal.TryParse(textBox2.Text, out decimal soluong) &&
                decimal.TryParse(textBox3.Text, out decimal giamgia))
            {
                decimal thanhtien = dongia * soluong * (100 - giamgia) / 100;

                textBox4.Text = thanhtien.ToString();
            }
            else
            {
                textBox4.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(textBox1.Text, out decimal donGia) || donGia <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBox2.Text, out decimal soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBox3.Text, out decimal khuyenMai) || khuyenMai < 0 || khuyenMai > 100)
                {
                    MessageBox.Show("Khuyến mại phải từ 0 đến 100%.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBox4.Text, out decimal tongTien) || tongTien <= 0)
                {
                    MessageBox.Show("Tổng tiền không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBox5.Text.Trim()))
                {
                    MessageBox.Show("Mã hóa đơn không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHoaDon = textBox5.Text.Trim();
                DataTable dt = bll2.LayTheoMa(maHoaDon);

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ketQua = bll2.ThemPhieuNhap(
                    maHoaDon,
                    dateTimePicker1.Value,
                    comboBox3.SelectedValue?.ToString() ?? "",
                    comboBox4.SelectedValue?.ToString() ?? "",
                    tongTien,
                    textBox7.Text.Trim(),
                    soLuong,
                    donGia,
                    khuyenMai
                );

                if (ketQua)
                {
                    MessageBox.Show("Nhập nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Text = "0";
                    textBox5.Clear();
                }
                else
                {
                    MessageBox.Show("Nhập nguyên liệu không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập nguyên liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Blue;
            label11.Cursor = Cursors.Hand;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = Color.Transparent;
            label11.ForeColor = Color.Black;
        }
    }
}

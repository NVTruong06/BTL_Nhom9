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
    public partial class UC_SuaNguyenLieu : UserControl
    {
        private string maNL;
        NguyenLieuBLL bll1 = new NguyenLieuBLL();
        public UC_SuaNguyenLieu(string ma)
        {
            InitializeComponent();
            maNL = ma;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_SuaNguyenLieu_Load(object sender, EventArgs e)
        {
            try
            {
            NguyenLieuDAO dao = new NguyenLieuDAO();

            DataTable dt = dao.LayTheoMa(maNL);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dt.Rows[0];
                textBox1.Text = row[0]?.ToString() ?? "";
                textBox2.Text = row[1]?.ToString() ?? "";
                textBox3.Text = row[2]?.ToString() ?? "";
                textBox4.Text = row[3]?.ToString() ?? "";
                textBox5.Text = row[4]?.ToString() ?? "";
                textBox6.Text = row[5]?.ToString() ?? "";
                textBox7.Text = row[6]?.ToString() ?? "";
                textBox8.Text = row[7]?.ToString() ?? "";
                textBox9.Text = row[8]?.ToString() ?? "";

            textBox1.ReadOnly = true;
                textBox1.Enabled = false;

                textBox4.ReadOnly = true;
                textBox4.Enabled = false;

                textBox6.ReadOnly = true;
                textBox6.Enabled = false;
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNguyenLieu = textBox2.Text.Trim();
                string donVi = textBox3.Text.Trim();

                if (string.IsNullOrEmpty(tenNguyenLieu) || string.IsNullOrEmpty(donVi))
            {
                    MessageBox.Show("Tên và đơn vị không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                if (!decimal.TryParse(textBox5.Text, out decimal giaNhap) || giaNhap < 0)
            {
                    MessageBox.Show("Giá nhập phải là số không âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                if (!decimal.TryParse(textBox6.Text, out decimal giaBan) || giaBan <= 0)
            {
                    MessageBox.Show("Giá bán phải là số dương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                if (!decimal.TryParse(textBox4.Text, out decimal soLuong) || soLuong < 0)
            {
                    MessageBox.Show("Số lượng phải là số không âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                bool ketqua = bll1.SuaNguyenLieu(textBox1.Text, tenNguyenLieu, donVi,
                    soLuong, giaNhap, giaBan, textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim());

                if (ketqua)
                {
                    MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }

        private void label11_Leave(object sender, EventArgs e)
        {

        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = Color.Transparent;
            label11.ForeColor = Color.Black;
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Blue;
            label11.Cursor = Cursors.Hand;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }
    }
}

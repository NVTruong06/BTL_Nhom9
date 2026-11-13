using LTTQ_BTL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.NguyenLieu
{
    public partial class UC_ThemNguyenLieu : UserControl
    {
        NguyenLieuBLL bll1 = new NguyenLieuBLL();
        public UC_ThemNguyenLieu()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string maNguyenLieu = textBox1.Text.Trim();
                string tenNguyenLieu = textBox2.Text.Trim();
                string donVi = textBox3.Text.Trim();

                if (string.IsNullOrEmpty(maNguyenLieu) || string.IsNullOrEmpty(tenNguyenLieu) || string.IsNullOrEmpty(donVi))
                {
                    MessageBox.Show("Mã, tên và đơn vị không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (bll1.LayTheoMa(maNguyenLieu).Rows.Count > 0)
                {
                    MessageBox.Show("Mã nguyên liệu đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ketqua = bll1.ThemNguyenLieu(maNguyenLieu, tenNguyenLieu, donVi, giaBan, textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim());

                if (ketqua)
                {
                    MessageBox.Show("Thêm nguyên liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain form = (FormMain)this.FindForm();
                    UC_NguyenLieu uc = new UC_NguyenLieu();
                    form.HienThiTrang(uc);
                }
                else
                {
                    MessageBox.Show("Thêm nguyên liệu không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nguyên liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_ThemNguyenLieu_Load(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
            textBox6.Enabled = false;
            textBox4.Text = "0";
            textBox4.ReadOnly = true;
            textBox4.Enabled = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }
    }
}

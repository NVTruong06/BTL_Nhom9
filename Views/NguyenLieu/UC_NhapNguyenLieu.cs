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
        public UC_NhapNguyenLieu(string ma)
        {
            InitializeComponent();
            maNL = ma;
        }

        private void UC_NhapNguyenLieu_Load(object sender, EventArgs e)
        {
            NguyenLieuDAO dao = new NguyenLieuDAO();

            DataTable dt1 = dao.LayTheoMa(maNL);

            textBox6.Text = dt1.Rows[0][1].ToString();
            textBox6.Enabled = false;

            textBox7.Text = dt1.Rows[0][0].ToString();
            textBox7.Enabled = false;

            textBox1.Text = dt1.Rows[0][5].ToString();
            textBox1.Enabled = false;

            DataTable dt2 = dao.DSNhanVien();

            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "TenNhanVien";
            comboBox3.ValueMember = "MaNhanVien";

            DataTable dt3 = dao.DSNhaCungCap();

            comboBox4.DataSource = dt3;
            comboBox4.DisplayMember = "TenNhaCungCap";
            comboBox4.ValueMember = "MaNhaCungCap";

            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            textBox4.ReadOnly = true;
            textBox4.Enabled = false;
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
            if (!decimal.TryParse(textBox1.Text, out decimal dongia))
            {
                MessageBox.Show("gon gia khong hop le");
                return;
            }
            if (!decimal.TryParse(textBox2.Text, out decimal soluong))
            {
                MessageBox.Show("So luong khong hop le");
                return;
            }
            if (!decimal.TryParse(textBox3.Text, out decimal khuyenmai))
            {
                MessageBox.Show("khuyen mai khong hop le");
                return;
            }
            if (!decimal.TryParse(textBox4.Text, out decimal tongtien))
            {
                MessageBox.Show("tong tien khong hop le");
                return;
            }

            if (textBox4.Text == "0" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Thong tin khong duoc de trong");
            }

            HoaDonNhapDao dao = new HoaDonNhapDao();

            DataTable dt = dao.LayTheoMa(textBox5.Text);

            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Ma trung");
            }
            else
            {
                bool ketqua = dao.ThemPhieuNhap(textBox5.Text, dateTimePicker1.Value,
                    comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString(), tongtien, textBox7.Text, soluong, dongia, khuyenmai);

                if (ketqua)
                {
                    MessageBox.Show("Nhập nguyên liệu thành công!");

                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Text = "0";
                }
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
    }
}

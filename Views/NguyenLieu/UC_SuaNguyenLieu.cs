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
            NguyenLieuDAO dao = new NguyenLieuDAO();

            DataTable dt = dao.LayTheoMa(maNL);

            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            textBox6.Text = dt.Rows[0][5].ToString();
            textBox7.Text = dt.Rows[0][6].ToString();
            textBox8.Text = dt.Rows[0][7].ToString();
            textBox9.Text = dt.Rows[0][8].ToString();

            textBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBox4.Text, out decimal soluong))
            {
                MessageBox.Show("So luong khong hop le");
                return;
            }
            if (!decimal.TryParse(textBox5.Text, out decimal nhap))
            {
                MessageBox.Show("Don gia nhap khong hop le");
                return;
            }
            if (!decimal.TryParse(textBox6.Text, out decimal ban))
            {
                MessageBox.Show("Don gia ban khong hop le");
                return;
            }
            if(textBox2.Text == ""|| textBox3.Text == "" || textBox7.Text == "" || textBox8.Text == "" | textBox9.Text == "")
            {
                MessageBox.Show("Thong tin khong duoc de trong");
                return;
            }

            NguyenLieuDAO dao = new NguyenLieuDAO();

            bool ketqua = dao.SuaNguyenLieu(textBox1.Text, textBox2.Text, textBox3.Text,
                soluong, nhap, ban, textBox7.Text, textBox8.Text, textBox9.Text);

            FormMain form = (FormMain)this.FindForm();

            UC_NguyenLieu uc = new UC_NguyenLieu();

            form.HienThiTrang(uc);
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
    }
}

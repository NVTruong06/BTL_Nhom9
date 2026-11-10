using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.MonAn
{
    public partial class UC_MonAn : UserControl
    {
        public UC_MonAn()
        {
            InitializeComponent();
        }

        private void DinhDangDGV()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].HeaderText = "Mã món ăn";
            dataGridView1.Columns[1].HeaderText = "Tên món ăn";
            dataGridView1.Columns[2].HeaderText = "Công dụng";
            dataGridView1.Columns[3].HeaderText = "Loại";
            dataGridView1.Columns[4].HeaderText = "Yêu cầu";
            dataGridView1.Columns[5].HeaderText = "Đơn giá";

            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 40;
            dataGridView1.Columns[2].FillWeight = 10;
            dataGridView1.Columns[3].FillWeight = 10;
            dataGridView1.Columns[4].FillWeight = 10;
            dataGridView1.Columns[5].FillWeight = 10;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UC_MonAn_Load(object sender, EventArgs e)
        {
            MonAnDao dao = new MonAnDao();

            dataGridView1.DataSource = dao.DSMonAn();
            DinhDangDGV();

            DataTable dt1 = dao.DSLoai();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";

            DataTable dt2 = dao.DSCongDung();
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "TenCongDung";
            comboBox2.ValueMember = "MaCongDung";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            textBox2.Multiline = true;
            textBox2.ReadOnly = true;
            textBox2.WordWrap = true;

            DataTable dt3 = dao.LayTheoMa(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            label2.Text = dt3.Rows[0][1].ToString();
            label9.Text = dt3.Rows[0][0].ToString();
            label10.Text = dt3.Rows[0][2].ToString();
            label11.Text = dt3.Rows[0][3].ToString();
            textBox2.Text = dt3.Rows[0][4].ToString();
            label13.Text = dt3.Rows[0][5].ToString();
            label14.Text = dt3.Rows[0][6].ToString();

            label2.TextAlign = ContentAlignment.TopCenter;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            string loai = "";
            string congdung = "";
            if (comboBox1.SelectedIndex != -1)
            {
                loai = comboBox1.SelectedValue.ToString();
            }
            else loai = "";
            if (comboBox2.SelectedIndex != -1)
            {
                congdung = comboBox2.SelectedValue.ToString();
            }
            else congdung = "";

            MonAnDao dao = new MonAnDao();
            dataGridView1.DataSource = dao.TimKiem(ten, loai, congdung);
            DinhDangDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            MonAnDao dao = new MonAnDao();

            DataTable dt3 = dao.LayTheoMa(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            label2.Text = dt3.Rows[0][1].ToString();
            label9.Text = dt3.Rows[0][0].ToString();
            label10.Text = dt3.Rows[0][2].ToString();
            label11.Text = dt3.Rows[0][3].ToString();
            textBox2.Text = dt3.Rows[0][4].ToString();
            label13.Text = dt3.Rows[0][5].ToString();
            label14.Text = dt3.Rows[0][6].ToString();

            label2.TextAlign = ContentAlignment.TopCenter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();
            UC_ThemMonAn uc = new UC_ThemMonAn();
            form.HienThiTrang(uc);
        }
    }
}

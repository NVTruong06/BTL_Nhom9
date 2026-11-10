using LTTQ_BTL.BLL;
using LTTQ_BTL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.MonAn
{
    public partial class UC_ThemMonAn : UserControl
    {
        MonAnBLL bll1 = new MonAnBLL();
        NguyenLieuBLL bll2 = new NguyenLieuBLL();
        LoaiCongDungBLL bll3 = new LoaiCongDungBLL();

        private string anhGoc;
        public UC_ThemMonAn()
        {
            InitializeComponent();
        }

        private void TinhGia()
        {
            decimal gia = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                gia += decimal.Parse(row.Cells[5].Value.ToString()) * decimal.Parse(row.Cells[3].Value.ToString());
            }
            textBox5.Text = gia.ToString();
        }

        private void DinhDangDGV1()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].FillWeight = 20;
            dataGridView1.Columns[1].FillWeight = 30;
            dataGridView1.Columns[2].FillWeight = 20;
            dataGridView1.Columns[3].FillWeight = 20;
            dataGridView1.Columns[4].FillWeight = 10;
            dataGridView1.Columns[5].FillWeight = 20;
            dataGridView1.Columns[6].FillWeight = 10;
            dataGridView1.Columns[7].FillWeight = 10;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DinhDangDGV2()
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowHeadersVisible = false;

            dataGridView2.Columns[0].HeaderText = "Mã nguyên liệu";
            dataGridView2.Columns[1].HeaderText = "Tên nguyên liệu";
            dataGridView2.Columns[2].HeaderText = "Đơn vị tính";
            dataGridView2.Columns[3].HeaderText = "Số lượng";
            dataGridView2.Columns[4].HeaderText = "Đơn giá";

            dataGridView2.Columns[0].FillWeight = 20;
            dataGridView2.Columns[1].FillWeight = 40;
            dataGridView2.Columns[2].FillWeight = 20;
            dataGridView2.Columns[3].FillWeight = 20;
            dataGridView2.Columns[4].FillWeight = 20;

            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UC_ThemMonAn_Load(object sender, EventArgs e)
        {

            textBox3.Multiline = true;
            textBox3.WordWrap = true;


            DataTable dt = bll2.DSNguyenLieuThemMonAn("");

            dataGridView2.DataSource = dt;

            DinhDangDGV2();

            dataGridView1.Columns.Add("MaNguyenLieu", "Mã nguyên liệu");
            dataGridView1.Columns.Add("TenNguyenLieu", "Tên nguyên liệu");
            dataGridView1.Columns.Add("DonVi", "Đơn vị");
            dataGridView1.Columns.Add("DonGiaBan", "Đơn giá bán");
            DataGridViewButtonColumn btnGiam = new DataGridViewButtonColumn();

            btnGiam.Name = "btnGiam";
            btnGiam.HeaderText = "";
            btnGiam.Text = "-";
            btnGiam.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(btnGiam);
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            DataGridViewButtonColumn btnThem = new DataGridViewButtonColumn();

            btnThem.Name = "btnThem";
            btnThem.HeaderText = "";
            btnThem.Text = "+";
            btnThem.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(btnThem);
            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();

            btnXoa.Name = "btnXoa";
            btnXoa.HeaderText = "";
            btnXoa.Text = "🗑";
            btnXoa.UseColumnTextForButtonValue = true;

            btnGiam.FlatStyle = FlatStyle.Flat;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatStyle = FlatStyle.Flat;

            dataGridView1.Columns.Add(btnXoa);

            DinhDangDGV1();

            DataTable dt2 = bll3.DSLoai();
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
            DataTable dt3 = bll3.DSCongDung();
            comboBox2.DataSource = dt3;
            comboBox2.DisplayMember = "TenCongDung";
            comboBox2.ValueMember = "MaCongDung";

            textBox5.ReadOnly = true;
            textBox5.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ten = textBox6.Text.Trim();

            DataTable dt = bll2.DSNguyenLieuThemMonAn(ten);

            dataGridView2.DataSource = dt;

            DinhDangDGV2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maMon = dataGridView1.Rows[e.RowIndex].Cells["MaNguyenLieu"].Value.ToString();

            string tenCot = dataGridView1.Columns[e.ColumnIndex].Name;

            decimal sl = bll2.LaySoLuong(maMon);

            if (tenCot == "btnGiam")
            {
                if (int.TryParse(dataGridView1.CurrentRow.Cells[5].Value.ToString(), out int soluong))
                {
                    if (soluong > 0) dataGridView1.CurrentRow.Cells[5].Value = soluong - 1;
                }
            }
            else if (tenCot == "btnThem")
            {
                if (int.TryParse(dataGridView1.CurrentRow.Cells[5].Value.ToString(), out int soluong))
                {
                    if (soluong < sl) dataGridView1.CurrentRow.Cells[5].Value = soluong + 1;
                }
            }
            else if (tenCot == "btnXoa")
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
            TinhGia();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = bll2.LayNguyenLieuThemMonAn(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == row.Cells[0].Value.ToString()) return;
            }
            int sl;
            if (int.TryParse(textBox7.Text, out int soluong)) sl = soluong;
            else sl = 1;

            if (sl > bll2.LaySoLuong(dataGridView2.CurrentRow.Cells[0].Value.ToString())) return;
            DataRow r = dt.Rows[0];

            dataGridView1.Rows.Add(
                r["MaNguyenLieu"],
                r["TenNguyenLieu"],
                r["DonViTinh"],
                r["DonGiaBan"],
                "-",
                sl,
                "+",
                "xóa"
            );
            TinhGia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bll1.KiemTraMon(textBox1.Text))
            {
                MessageBox.Show("Ma trung");
                return;
            }

            if(textBox1.Text == "" || textBox2.Text == "")
            {
                return;
            }


            
            string thuMuc = @"D:\Microsoft VS Code\LTTQ\LTTQ_BTL\Resources\img\";
            string tenAnh = textBox1.Text.Trim() + Path.GetExtension(anhGoc);

            string duongDanMoi = Path.Combine(thuMuc, tenAnh);
            File.Copy(anhGoc, duongDanMoi, true);

            bll1.ThemMonAn(textBox1.Text, textBox2.Text, comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(),
                textBox3.Text, textBox4.Text, decimal.Parse(textBox5.Text.ToString()), duongDanMoi);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bll1.ThemNguyenLieuMonAn(textBox1.Text.Trim(), row.Cells[0].Value.ToString(), decimal.Parse(row.Cells[5].Value.ToString()));
            }

            duongDanMoi = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Title = "Them anh";
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if(file.ShowDialog() == DialogResult.OK)
            {
                anhGoc = file.FileName;
                pictureBox1.ImageLocation = anhGoc;
            }
        }
    }
}

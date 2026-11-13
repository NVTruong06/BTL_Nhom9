using LTTQ_BTL.Dao;
using LTTQ_BTL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LTTQ_BTL.BLL;

namespace LTTQ_BTL.Views.MonAn
{
    public partial class UC_MonAn : UserControl
    {
        MonAnBLL bll1 = new MonAnBLL();
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
            try
            {
            MonAnDao dao = new MonAnDao();

                dataGridView1.DataSource = bll1.DSMonAn();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox1.Text.Trim();
                string loai = (comboBox1.SelectedIndex != -1) ? comboBox1.SelectedValue.ToString() : "";
                string congdung = (comboBox2.SelectedIndex != -1) ? comboBox2.SelectedValue.ToString() : "";

                DataTable dt = bll1.TimKiem(ten, loai, congdung);
                if (dt.Rows.Count == 0)
            {
                    MessageBox.Show("Không tìm thấy món ăn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                dataGridView1.DataSource = dt;
            DinhDangDGV();
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            MonAnDao dao = new MonAnDao();

                string maMon = dataGridView1.CurrentRow.Cells[0].Value?.ToString();
                if (string.IsNullOrEmpty(maMon))
                    return;

                DataTable dt3 = bll1.LayTheoMa(maMon);
                if (dt3.Rows.Count == 0)
                    return;

                DataRow row = dt3.Rows[0];
                label2.Text = row[1]?.ToString() ?? "";
                label9.Text = row[0]?.ToString() ?? "";
                label10.Text = row[2]?.ToString() ?? "";
                label11.Text = row[3]?.ToString() ?? "";
                textBox2.Text = row[4]?.ToString() ?? "";
                label13.Text = row[5]?.ToString() ?? "";
                label14.Text = row[6]?.ToString() ?? "";

                string hinhAnh = row[7]?.ToString() ?? "";
                pictureBox1.ImageLocation = hinhAnh;

            label2.TextAlign = ContentAlignment.TopCenter;
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();
            UC_ThemMonAn uc = new UC_ThemMonAn();
            form.HienThiTrang(uc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormMain form = (FormMain)this.FindForm();
            UC_SuaMonAn uc = new UC_SuaMonAn(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            form.HienThiTrang(uc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maMon = dataGridView1.CurrentRow
                .Cells["MaMonAn"].Value?.ToString();

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa món ăn này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                bll1.XoaMonAn(maMon);
                MessageBox.Show("Xóa món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = bll1.DSMonAn();
                DinhDangDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}

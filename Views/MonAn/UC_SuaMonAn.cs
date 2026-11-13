using LTTQ_BTL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.MonAn
{
    public partial class UC_SuaMonAn : UserControl
    {
        string maMA;
        MonAnBLL bll1 = new MonAnBLL();
        NguyenLieuBLL bll2 = new NguyenLieuBLL();
        LoaiCongDungBLL bll3 = new LoaiCongDungBLL();

        private string anhGoc = "";
        public UC_SuaMonAn(string ma)
        {
            InitializeComponent();
            maMA = ma;
        }

        private void TinhGia()
        {
            decimal gia = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
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
        private void UC_SuaMonAn_Load(object sender, EventArgs e)
        {
            try
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
                textBox1.ReadOnly = true;
                textBox1.Enabled = false;

                DataTable dt1 = bll1.LayTheoMa(maMA);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow drMon = dt1.Rows[0];
                textBox1.Text = drMon[0]?.ToString() ?? "";
                textBox2.Text = drMon[1]?.ToString() ?? "";
                textBox3.Text = drMon[4]?.ToString() ?? "";
                textBox4.Text = drMon[5]?.ToString() ?? "";
                textBox5.Text = drMon[6]?.ToString() ?? "";

                comboBox2.SelectedValue = drMon[2]?.ToString() ?? "";
                comboBox1.SelectedValue = drMon[3]?.ToString() ?? "";

                string hinhAnh = drMon[7]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(hinhAnh) && System.IO.File.Exists(hinhAnh))
                {
                    pictureBox1.ImageLocation = hinhAnh;
                }

                DataTable dt4 = bll1.LayNguyenLieu_MonAn(maMA);
                foreach (DataRow row in dt4.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaNguyenLieu"],
                        row["TenNguyenLieu"],
                        row["DonViTinh"],
                        row["DonGiaBan"],
                        "-",
                        row["SoLuong"],
                        "+",
                        "xóa"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = textBox6.Text.Trim();
                DataTable dt = bll2.DSNguyenLieuThemMonAn(ten);
                dataGridView2.DataSource = dt;
                DinhDangDGV2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    MessageBox.Show("Tên món ăn không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại và công dụng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một nguyên liệu cho món ăn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("MaMonAn", typeof(string));
                dt.Columns.Add("MaNguyenLieu", typeof(string));
                dt.Columns.Add("SoLuong", typeof(decimal));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (!decimal.TryParse(row.Cells[5].Value?.ToString() ?? "0", out decimal sl) || sl <= 0)
                    {
                        MessageBox.Show($"Số lượng nguyên liệu không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dt.Rows.Add(
                        textBox1.Text,
                        row.Cells[0].Value?.ToString() ?? "",
                        sl
                    );
                }

                string duongDanMoi = "";
                if (anhGoc != "")
                {
                    string thuMuc = @"D:\Microsoft VS Code\LTTQ\LTTQ_BTL\Resources\img\";
                    string tenAnh = textBox1.Text.Trim() + Path.GetExtension(anhGoc);
                    duongDanMoi = Path.Combine(thuMuc, tenAnh);
                    File.Copy(anhGoc, duongDanMoi, true);
                }
                else
                {
                    DataTable dt1 = bll1.LayTheoMa(textBox1.Text.Trim());
                    if (dt1.Rows.Count > 0)
                    {
                        duongDanMoi = dt1.Rows[0][7]?.ToString() ?? "";
                    }
                }

                if (!decimal.TryParse(textBox5.Text, out decimal gia) || gia <= 0)
                {
                    gia = 0;
                }

                bool ketQua = bll1.SuaMonAn(textBox1.Text, textBox2.Text, comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), 
                    textBox3.Text.Trim(), textBox4.Text.Trim(), gia, duongDanMoi, dt);

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain form = (FormMain)this.FindForm();
                    UC_MonAn uc = new UC_MonAn();
                    form.HienThiTrang(uc);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain form = (FormMain)this.FindForm();
            UC_MonAn uc = new UC_MonAn();
            form.HienThiTrang(uc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Title = "Them anh";
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (file.ShowDialog() == DialogResult.OK)
            {
                anhGoc = file.FileName;
                pictureBox1.ImageLocation = anhGoc;
            }
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
                if (decimal.TryParse(dataGridView1.CurrentRow.Cells[5].Value.ToString(), out decimal soluong))
                {
                    if (soluong > 0) dataGridView1.CurrentRow.Cells[5].Value = soluong - 1;
                }
            }
            else if (tenCot == "btnThem")
            {
                if (decimal.TryParse(dataGridView1.CurrentRow.Cells[5].Value.ToString(), out decimal soluong))
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

            if (sl > bll2.LaySoLuong(dataGridView2.CurrentRow.Cells[0].Value.ToString()) && sl > 0) return;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            string ten = textBox6.Text.Trim();

            DataTable dt = bll2.DSNguyenLieuThemMonAn(ten);

            dataGridView2.DataSource = dt;

            DinhDangDGV2();
        }
    }
}

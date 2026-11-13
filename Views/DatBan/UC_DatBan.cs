using LTTQ_BTL.BLL;
using LTTQ_BTL.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.DatBan
{
    public partial class UC_DatBan : UserControl
    {
        PhieuDatBanBLL bll = new PhieuDatBanBLL();
        MonAnBLL bll2 = new MonAnBLL();
        LoaiCongDungBLL bll3 = new LoaiCongDungBLL();

        bool Nhap = false;

        public UC_DatBan()
        {
            InitializeComponent();
        }

        private void DinhDangDGV()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].HeaderText = "Mã phiếu";
            dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[2].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[3].HeaderText = "Ngày đặt";
            dataGridView1.Columns[4].HeaderText = "Ngày dùng";
            dataGridView1.Columns[5].HeaderText = "Tổng tiền";

            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 30;
            dataGridView1.Columns[2].FillWeight = 30;
            dataGridView1.Columns[3].FillWeight = 20;
            dataGridView1.Columns[4].FillWeight = 20;
            dataGridView1.Columns[5].FillWeight = 20;

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

            dataGridView2.Columns[0].FillWeight = 20;
            dataGridView2.Columns[1].FillWeight = 40;
            dataGridView2.Columns[2].FillWeight = 30;
            dataGridView2.Columns[3].FillWeight = 20;
            dataGridView2.Columns[4].FillWeight = 20;
            dataGridView2.Columns[5].FillWeight = 10;

            //dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void DinhDangDGV3()
        {
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.RowHeadersVisible = false;

            dataGridView3.Columns[0].HeaderText = "Mã món";
            dataGridView3.Columns[1].HeaderText = "Tên món";
            dataGridView3.Columns[2].HeaderText = "Mã loại";
            dataGridView3.Columns[3].HeaderText = "Số lượng";
            dataGridView3.Columns[4].HeaderText = "Đơn giá";
            dataGridView3.Columns[5].HeaderText = "Giảm giá";
            dataGridView3.Columns[6].HeaderText = "Thành tiền";

            dataGridView3.Columns[0].FillWeight = 10;
            dataGridView3.Columns[1].FillWeight = 30;
            dataGridView3.Columns[2].FillWeight = 20;
            dataGridView3.Columns[3].FillWeight = 20;
            dataGridView3.Columns[4].FillWeight = 20;
            dataGridView3.Columns[5].FillWeight = 20;
            dataGridView3.Columns[6].FillWeight = 20;

            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView3.Enabled = false;
        }
        private void TrangThaiXem()
        {
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            dataGridView2.Enabled = false;
        }
        private void TrangThaiNhap()
        {
            textBox1.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            dataGridView2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string tenMon = textBox6.Text.Trim();
                string maCongDung = comboBox4.SelectedValue?.ToString() ?? "";
                string maLoai = comboBox3.SelectedValue?.ToString() ?? "";

                dataGridView2.Rows.Clear();
                DataTable dt = bll2.TimKiemMonAn_PhieuDatBan(tenMon, maLoai, maCongDung);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy món ăn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                foreach (DataRow row in dt.Rows)
                {
                    dataGridView2.Rows.Add(row["MaMonAN"], row["TenMonAn"], row["DonGia"], "0", "0", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_DatBan_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bll.DSPhieuDatBan();
                dataGridView1.DataSource = dt;
                DinhDangDGV();

                dataGridView2.Columns.Add("MaMonAn", "Mã món ăn");
                dataGridView2.Columns.Add("TenMonAn", "Tên món ăn");
                dataGridView2.Columns.Add("DonGia", "Đơn giá");
                dataGridView2.Columns.Add("SoLuong", "Số lượng");
                dataGridView2.Columns.Add("GiamGia", "Giảm giá");

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "Chon";
                chk.HeaderText = "";
                chk.Width = 50;

                dataGridView2.Columns.Add(chk);
                DinhDangDGV2();
                dataGridView2.Columns["Chon"].ReadOnly = false;

                DataTable dt2 = bll2.DSMonAn_DatBan();
                foreach (DataRow row in dt2.Rows)
                {
                    dataGridView2.Rows.Add(row["MaMonAN"], row["TenMonAn"], row["DonGia"], "0", "0", false);
                }

                DataTable dt3 = bll3.DSCongDung();
                comboBox3.DataSource = dt3;
                comboBox3.DisplayMember = "TenCongDung";
                comboBox3.ValueMember = "MaCongDung";
                comboBox3.SelectedIndex = -1;

                DataTable dt4 = bll3.DSLoai();
                comboBox4.DataSource = dt4;
                comboBox4.DisplayMember = "TenLoai";
                comboBox4.ValueMember = "MaLoai";
                comboBox4.SelectedIndex = -1;

                TrangThaiXem();
                DinhDangDGV3();

                DataTable dtKhach = bll.DSKhach();
                comboBox1.DataSource = dtKhach;
                comboBox1.DisplayMember = "TenKhach";
                comboBox1.ValueMember = "MaKhach";

                DataTable dtNhanVien = bll.DSNhanVien();
                comboBox2.DataSource = dtNhanVien;
                comboBox2.DisplayMember = "TenNhanVien";
                comboBox2.ValueMember = "MaNhanVien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name != "Chon"
                && dataGridView2.Columns[e.ColumnIndex].Name != "SoLuong" && dataGridView2.Columns[e.ColumnIndex].Name != "GiamGia")
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.Rows.Clear();
                if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow || dataGridView1.SelectedRows.Count == 0)
                {
                    return;
                }

                string maPhieu = dataGridView1.CurrentRow.Cells[0]?.Value?.ToString();
                if (string.IsNullOrEmpty(maPhieu))
                    return;

                DataTable dt1 = bll.LayPhieuDatBan(maPhieu);
                if (dt1.Rows.Count == 0)
                    return;

                DataRow drPhieu = dt1.Rows[0];
                textBox1.Text = drPhieu[0]?.ToString() ?? "";
                textBox4.Text = drPhieu[5]?.ToString() ?? "";
                comboBox1.SelectedValue = drPhieu[1]?.ToString() ?? "";
                comboBox2.SelectedValue = drPhieu[2]?.ToString() ?? "";

                if (DateTime.TryParse(drPhieu[3]?.ToString() ?? "", out DateTime ngayDat))
                    dateTimePicker1.Value = ngayDat;
                if (DateTime.TryParse(drPhieu[4]?.ToString() ?? "", out DateTime ngayDung))
                    dateTimePicker2.Value = ngayDung;

                DataTable dt2 = bll.DSChiTietPhieuDat(maPhieu);
                foreach (DataRow row in dt2.Rows)
                {
                    dataGridView3.Rows.Add(
                        row[0]?.ToString() ?? "",
                        row[1]?.ToString() ?? "",
                        row[2]?.ToString() ?? "",
                        row[3]?.ToString() ?? "",
                        row[4]?.ToString() ?? "",
                        row[5]?.ToString() ?? "",
                        row[6]?.ToString() ?? "");
                }

                TrangThaiXem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = Convert.ToBoolean(row.Cells[5].Value ?? false);

                if (isChecked)
                {
                    DataTable dt = bll2.LayTheoMa_PhieuDatBan(row.Cells[0].Value.ToString());

                    DataRow r = dt.Rows[0];
                    if (row.Cells[3].Value == null || !int.TryParse(row.Cells[3].Value.ToString(), out int soluong))
                    {
                        MessageBox.Show("So luong khong hop le");
                        return;
                    }
                    if (row.Cells[4].Value == null || !decimal.TryParse(row.Cells[4].Value.ToString(), out decimal giamgia))
                    {
                        MessageBox.Show("Giam Gia khong hop le");
                        return;
                    }
                    else giamgia = Math.Clamp(giamgia, 0, 100);
                    decimal thanhtien = decimal.Parse(row.Cells[2].Value.ToString()) * soluong;
                    decimal thanhtien2 = thanhtien * ((100 - giamgia) / 100);
                    dataGridView3.Rows.Add(
                        r["MaMonAn"],
                        r["TenMonAn"],
                        r["MaLoai"],
                        soluong.ToString(),
                        r["DonGia"],
                        giamgia.ToString(),
                        thanhtien2.ToString()
                    );
                }
            }
            decimal tongtien = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                tongtien += decimal.Parse(row.Cells[6].Value.ToString());
            }
            textBox4.Text = tongtien.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nhap == false)
            {
                Nhap = true;
                TrangThaiNhap();
                button1.Text = "Xác nhận";
                button2.Enabled = false;
                button3.Enabled = false;

                textBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox4.Text = "0";
                dataGridView3.Rows.Clear();
            }
            else
            {
                Nhap = false;
                TrangThaiXem();
                button1.Text = "Nhập";

                try
                {
                    string maPhieu = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(maPhieu))
                    {
                        MessageBox.Show("Mã phiếu không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (comboBox2.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dataGridView3.Rows.Count == 0)
                    {
                        MessageBox.Show("Phiếu đặt bàn phải có ít nhất một món ăn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(textBox4.Text, out decimal tongTien) || tongTien <= 0)
                    {
                        MessageBox.Show("Tổng tiền phải là số dương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataTable dt1 = bll.LayPhieuDatBan(maPhieu);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã phiếu đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataTable dtChiTiet = new DataTable();
                    dtChiTiet.Columns.Add("MaPhieu", typeof(string));
                    dtChiTiet.Columns.Add("MaMonAn", typeof(string));
                    dtChiTiet.Columns.Add("MaLoai", typeof(string));
                    dtChiTiet.Columns.Add("SoLuong", typeof(int));
                    dtChiTiet.Columns.Add("DonGia", typeof(decimal));
                    dtChiTiet.Columns.Add("GiamGia", typeof(decimal));
                    dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (!decimal.TryParse(row.Cells[3].Value?.ToString() ?? "0", out decimal soLuong) || soLuong <= 0)
                            continue;

                        if (!decimal.TryParse(row.Cells[4].Value?.ToString() ?? "0", out decimal donGia) ||
                            !decimal.TryParse(row.Cells[5].Value?.ToString() ?? "0", out decimal giamGia) ||
                            !decimal.TryParse(row.Cells[6].Value?.ToString() ?? "0", out decimal thanhTien))
                            continue;

                        dtChiTiet.Rows.Add(
                            maPhieu,
                            row.Cells[0]?.Value?.ToString() ?? "",
                            row.Cells[2]?.Value?.ToString() ?? "",
                            soLuong,
                            donGia,
                            giamGia,
                            thanhTien
                        );
                    }

                    if (dtChiTiet.Rows.Count == 0)
                    {
                        MessageBox.Show("Phiếu không có món ăn hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool result = bll.ThemPhieuDatBan(
                        maPhieu,
                        comboBox1.SelectedValue?.ToString() ?? "",
                        comboBox2.SelectedValue?.ToString() ?? "",
                        dateTimePicker1.Value.Date,
                        dateTimePicker2.Value.Date,
                        tongTien,
                        dtChiTiet
                    );

                    if (result)
                    {
                        MessageBox.Show("Đặt bàn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = bll.DSPhieuDatBan();
                        DinhDangDGV();
                    }
                    else
                    {
                        MessageBox.Show("Đặt bàn không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi đặt bàn: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Nhap == false)
            {
                Nhap = true;
                TrangThaiNhap();
                button2.Text = "Xác nhận";
                button1.Enabled = false;
                button3.Enabled = false;

                dataGridView3.Rows.Clear();
            }
            else
            {
                Nhap = false;
                TrangThaiXem();
                button2.Text = "Sửa";

                try
                {
                    string maPhieu = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(maPhieu))
                    {
                        MessageBox.Show("Mã phiếu không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (comboBox2.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dataGridView3.Rows.Count == 0)
                    {
                        MessageBox.Show("Phiếu phải có ít nhất một món ăn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(textBox4.Text, out decimal tongTien) || tongTien <= 0)
                    {
                        MessageBox.Show("Tổng tiền phải là số dương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataTable dtChiTiet = new DataTable();
                    dtChiTiet.Columns.Add("MaMonAn", typeof(string));
                    dtChiTiet.Columns.Add("MaLoai", typeof(string));
                    dtChiTiet.Columns.Add("SoLuong", typeof(int));
                    dtChiTiet.Columns.Add("DonGia", typeof(decimal));
                    dtChiTiet.Columns.Add("GiamGia", typeof(decimal));
                    dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (!int.TryParse(row.Cells[3].Value?.ToString() ?? "0", out int soLuong) || soLuong <= 0)
                            continue;

                        if (!decimal.TryParse(row.Cells[4].Value?.ToString() ?? "0", out decimal donGia) ||
                            !decimal.TryParse(row.Cells[5].Value?.ToString() ?? "0", out decimal giamGia) ||
                            !decimal.TryParse(row.Cells[6].Value?.ToString() ?? "0", out decimal thanhTien))
                            continue;

                        dtChiTiet.Rows.Add(
                            row.Cells[0]?.Value?.ToString() ?? "",
                            row.Cells[2]?.Value?.ToString() ?? "",
                            soLuong,
                            donGia,
                            giamGia,
                            thanhTien
                        );
                    }

                    if (dtChiTiet.Rows.Count == 0)
                    {
                        MessageBox.Show("Phiếu không có món ăn hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool result = bll.SuaPhieuDatBan(
                        maPhieu,
                        comboBox1.SelectedValue?.ToString() ?? "",
                        comboBox2.SelectedValue?.ToString() ?? "",
                        dateTimePicker1.Value.Date,
                        dateTimePicker2.Value.Date,
                        tongTien,
                        dtChiTiet
                    );

                    if (result)
                    {
                        MessageBox.Show("Sửa phiếu đặt bàn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = bll.DSPhieuDatBan();
                        DinhDangDGV();
                    }
                    else
                    {
                        MessageBox.Show("Sửa phiếu không thành công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maPhieu = dataGridView1.CurrentRow.Cells["MaPhieu"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                MessageBox.Show("Không lấy được mã phiếu đặt bàn.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu đặt bàn này?\nNguyên liệu đã sử dụng sẽ được hoàn lại kho.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                bll.XoaPhieuDatBan(maPhieu);

                MessageBox.Show("Xóa phiếu đặt bàn thành công!");

                dataGridView1.DataSource = bll.DSPhieuDatBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}

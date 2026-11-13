using LTTQ_BTL.BLL;
using LTTQ_BTL.Dal;
using Microsoft.Data.SqlClient;
using QuanLyNhaHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.Khach
{
    public partial class UC_Khach : UserControl
    {
        Database db = new Database();

        public UC_Khach()
        {
            InitializeComponent();

            LoadDanhSachKhach();
        }

        private void LoadDanhSachKhach()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Khach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            dgvKhach.DataSource = dt;

            if (dgvKhach.Columns.Count > 0)
            {
                try
                {
                    dgvKhach.Columns["MaKhach"].HeaderText = "Mã Khách";
                    dgvKhach.Columns["TenKhach"].HeaderText = "Tên Khách Hàng";
                    dgvKhach.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvKhach.Columns["DienThoai"].HeaderText = "Điện thoại";
                }
                catch { }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maKhach = txtMaKhach.Text.Trim();
                string tenKhach = txtTenKhach.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string dienThoai = txtDienThoai.Text.Trim();

                if (string.IsNullOrEmpty(maKhach) || string.IsNullOrEmpty(tenKhach))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã khách và Tên khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Khach (MaKhach, TenKhach, DiaChi, DienThoai) VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKhach", maKhach);
                    cmd.Parameters.AddWithValue("@TenKhach", tenKhach);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@DienThoai", dienThoai);

                    int rowCount = cmd.ExecuteNonQuery();
                    if (rowCount > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhach();
                        btnLamMoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKhach.Clear();
            txtTenKhach.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtMaKhach.Focus();
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhach.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhach"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString() == "" ? "" : row.Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value.ToString() == "" ? "" : row.Cells["DienThoai"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKhach = "";

            if (dgvKhach.SelectedRows.Count > 0)
            {
                maKhach = dgvKhach.SelectedRows[0].Cells["MaKhach"].Value?.ToString() ?? "";
            }
            else if (dgvKhach.CurrentRow != null)
            {
                maKhach = dgvKhach.CurrentRow.Cells["MaKhach"].Value?.ToString() ?? "";
            }

            if (string.IsNullOrEmpty(maKhach))
            {
                maKhach = txtMaKhach.Text.Trim();
            }

            if (string.IsNullOrEmpty(maKhach))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có mã '{maKhach}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool kq = KhachHangDAL.XoaKhachHang(maKhach);
                if (kq)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhach();
                    btnLamMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Không tìm thấy mã khách này trong CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
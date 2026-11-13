using LTTQ_BTL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views.HoaDonNhap
{
    public partial class UC_HoaDonNhap : UserControl
    {
        HoaDonNhapBLL bll = new HoaDonNhapBLL();
        public UC_HoaDonNhap()
        {
            InitializeComponent();
        }

        private void DinhDangDGV()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Ngày nhập";
            dataGridView1.Columns[2].HeaderText = "Nhân viên";
            dataGridView1.Columns[3].HeaderText = "Nhà cung cấp";
            dataGridView1.Columns[4].HeaderText = "Tổng tiền";

            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 10;
            dataGridView1.Columns[2].FillWeight = 10;
            dataGridView1.Columns[3].FillWeight = 10;
            dataGridView1.Columns[4].FillWeight = 10;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UC_HoaDonNhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bll.DSHoaDonNhap();
                DinhDangDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow || dataGridView1.SelectedRows.Count == 0)
                {
                    return;
                }

                string maHoaDon = dataGridView1.CurrentRow.Cells[0]?.Value?.ToString();
                if (string.IsNullOrEmpty(maHoaDon))
                    return;

                DataTable dt = bll.ChiTietHoaDon(maHoaDon);
                if (dt.Rows.Count == 0)
                    return;

                DataRow row = dt.Rows[0];
                label13.Text = row[0]?.ToString() ?? "";
                label14.Text = row[1]?.ToString() ?? "";
                label15.Text = row[2]?.ToString() ?? "";
                label16.Text = row[3]?.ToString() ?? "";
                label17.Text = row[4]?.ToString() ?? "";
                label18.Text = row[5]?.ToString() ?? "";
                label19.Text = row[6]?.ToString() ?? "";
                label22.Text = dataGridView1.CurrentRow.Cells[1]?.Value?.ToString() ?? "";
                label20.Text = dataGridView1.CurrentRow.Cells[2]?.Value?.ToString() ?? "";
                label21.Text = dataGridView1.CurrentRow.Cells[3]?.Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}

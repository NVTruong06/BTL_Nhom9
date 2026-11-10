using LTTQ_BTL.Views.MonAn;
using LTTQ_BTL.Views.NguyenLieu;
using QuanLyNhaHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views
{
    public partial class FormMain : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd, int Msg, int wParam, int lParam);
        public FormMain()
        {
            InitializeComponent();
        }

        public void HienThiTrang(UserControl uc)
        {
            panel4.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UC_MonAn uc = new UC_MonAn();
            HienThiTrang(uc);
            button9.Text = "\uE921";
            button8.Text = "\uE923";
            button7.Text = "\uE8BB";

            button9.Font = new Font("Segoe MDL2 Assets", 10);
            button8.Font = new Font("Segoe MDL2 Assets", 10);
            button7.Font = new Font("Segoe MDL2 Assets", 10);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void activeButton(object sender)
        {
            Button btn = (Button)sender;
            button1.BackColor = Color.FromArgb(98, 102, 247);
            button2.BackColor = Color.FromArgb(98, 102, 247);
            button3.BackColor = Color.FromArgb(98, 102, 247);
            button4.BackColor = Color.FromArgb(98, 102, 247);
            button5.BackColor = Color.FromArgb(98, 102, 247);
            button6.BackColor = Color.FromArgb(98, 102, 247);

            btn.BackColor = Color.FromArgb(65, 69, 219);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_MonAn uc = new UC_MonAn();
            HienThiTrang(uc);

            activeButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_NguyenLieu uc = new UC_NguyenLieu();
            HienThiTrang(uc);
            activeButton(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ucNhanSu uc = new ucNhanSu();
            HienThiTrang(uc);
            activeButton(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ucKhach uc = new ucKhach();
            HienThiTrang(uc);
            activeButton(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ucBaoCao uc = new ucBaoCao();
            HienThiTrang(uc);
            activeButton(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                button8.Text = "\uE922";
            }
            else
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                button8.Text = "\uE923";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
    }
}

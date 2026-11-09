using LTTQ_BTL.Views.MonAn;
using LTTQ_BTL.Views.NguyenLieu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTTQ_BTL.Views
{
    public partial class FormMain : Form
    {
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_NguyenLieu uc = new UC_NguyenLieu();
            HienThiTrang(uc);
        }
    }
}

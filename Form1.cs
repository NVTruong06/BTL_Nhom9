using LTTQ_BTL.Dao;
using LTTQ_BTL.Views.NguyenLieu;

namespace LTTQ_BTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void HienThiTrang(UserControl uc)
        {
            panel1.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UC_NguyenLieu uc = new UC_NguyenLieu();
            HienThiTrang(uc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

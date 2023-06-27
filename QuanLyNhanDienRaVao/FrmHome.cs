using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmHome : Form
    {
        Data dt = new Data();
        public FrmHome()
        {
            InitializeComponent();
            timer1.Start();
            //
        }
        private Form formconn;
        private void FrmHome_Load(object sender, EventArgs e)
        {
            dt.updateCamTat0(1);
            dt.updateCamTat0(2);
            if (bunifuLabel9.Text == "0")
            {
                btnDanCu.Enabled = false;
                btnlamat.Enabled = false;
                bunifuButton4.Enabled = false;
                bunifuButton5.Enabled = false;
            }
            try
            {
                bunifuDataGridView1.DataSource = dt.coHA("");
                bunifuDataGridView1.Columns[0].HeaderText = "Mã dân cư";
                bunifuDataGridView1.Columns[1].HeaderText = "Tên dân cư";
                bunifuDataGridView1.Columns[2].HeaderText = "Mã phòng";
                if (bunifuDataGridView1.Rows.Count == 0)
                {
                    bunifuDataGridView2.DataSource = dt.loadBang();

                }
                else
                {
                    //
                    bunifuDataGridView2.DataSource = dt.khongHA("");
                    bunifuDataGridView2.Columns[0].HeaderText = "Mã dân cư";
                    bunifuDataGridView2.Columns[1].HeaderText = "Tên dân cư";
                    bunifuDataGridView2.Columns[2].HeaderText = "Mã phòng";
                }
                
            }
            catch { }
            //
            bunifuButton7.Visible = false;
            //
        }
        private void FormBenTrong(Form fromcon)
        {
            if (formconn != null)
            {
                formconn.Close();
            }
            formconn = fromcon;
            fromcon.TopLevel = false;
            fromcon.FormBorderStyle = FormBorderStyle.None;
            fromcon.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(fromcon);
            bunifuPanel2.Tag = fromcon;
            fromcon.BringToFront();
            fromcon.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuButton3_MouseHover(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmLoadDanCu());
            }
        }

        private void btnDieuKhien_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmDieuKhien());
            }
        }

        public void btnTrucCamera_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmTrucCamera());
            }
            //

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {

            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmTraCuu());
            }
            //
        }

        private void FrmHome_Shown(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuLabel4.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                bunifuLabel7.Visible = false;
                bunifuLabel8.Visible = false;
                //
                FrmDangNhap frmdangnhap = new FrmDangNhap();
                frmdangnhap.Show();
                this.Hide();
            }
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }


        private void btnlamat_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmLaMat());
            }
            //

        }

        private void search1_TextChange(object sender, EventArgs e)
        {
            bunifuDataGridView1.DataSource = dt.coHA(search1.Text);
        }

        private void search2_TextChange(object sender, EventArgs e)
        {
            bunifuDataGridView2.DataSource = dt.khongHA(search2.Text);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FrmHome home = new FrmHome();
                home.bunifuLabel9.Text = bunifuLabel9.Text;
                home.bunifuLabel3.Text = bunifuLabel3.Text;
                home.bunifuLabel2.Text = bunifuLabel2.Text;
                home.bunifuImageButton1.Image = bunifuImageButton1.Image;
                home.bunifuImageButton1.ActiveImage = bunifuImageButton1.ActiveImage;
                home.Show();
                this.Hide();
            }

        }


        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FormBackup());
            }
            //

        }

        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            bunifuPanel2.Width = 1876;
            bunifuPanel2.Location = new Point(43, 33);
            bunifuSeparator1.Visible = false;
            bunifuShadowPanel1.Visible = false;
            bunifuButton7.Visible = true;
            bunifuToolTip3.SetToolTipTitle(btnTraCuu, "Tra cứu dân cư");
            bunifuToolTip3.SetToolTipTitle(btnTrucCamera, "Trực Camera");
            bunifuToolTip3.SetToolTipTitle(btnDieuKhien, "Bảng điều khiển");
            bunifuToolTip3.SetToolTipTitle(btnDanCu, "Tạo tập ảnh dân cư");
            bunifuToolTip3.SetToolTipTitle(btnlamat, "Kiểm soát người lạ");
            bunifuToolTip3.SetToolTipTitle(bunifuButton4, "Tài khoản");
            bunifuToolTip3.SetToolTipTitle(bunifuButton5, "Settings");
            bunifuToolTip3.SetToolTipTitle(bunifuButton3, "Đăng xuất");

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Location = new Point(296, 33);
            bunifuPanel2.Width = 1623;
            bunifuButton7.Visible = false;
            bunifuShadowPanel1.Visible = true;
            bunifuSeparator1.Visible = true;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (dt.ttRa() == 1 || dt.ttVao() == 1)
            {
                bunifuSnackbar1.Show(this, "Xin hãy tắt Camera trước khi thoát!!!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                FormBenTrong(new FrmTaiKhoan());
            }
            //
            //

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            FrmThongTinDanCu dancu = new FrmThongTinDanCu();
            dancu.Show();
        }

        private void bunifuToolTip1_Popup(object sender, BunifuToolTip.PopupEventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel2_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void search1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuToolTip2_Popup(object sender, BunifuToolTip.PopupEventArgs e)
        {

        }

        private void bunifuToolTip3_Popup(object sender, BunifuToolTip.PopupEventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmThongTinDanCu : Form
    {
        Data dt = new Data();
        public FrmThongTinDanCu()
        {
            InitializeComponent();
        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            String ma = txtmadancu.Text;
            dt.deleteCuDan(ma);

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            String phongDK = txtphongdk.Text;
            String name = txtName.Text;
            String sex = cbgt.Text;
            DateTime date = Convert.ToDateTime(bunifuDatePicker1.Text);
            String CMND = txtcmnd.Text;
            DateTime ngayCap = Convert.ToDateTime(bunifuDatePicker2.Text);
            String noiCap = txtnoicap.Text;
            String sdt = txtsdt.Text;
            String ngonNgu = cbxngonngu.Text;
            String thuongTru = txtthuongchu.Text;
            String ngheNghiep = txtnghenghiep.Text;
            String noiLamViec = txtnoilamviec.Text;
            String dantoc = txtdantoc.Text;
            String noiSinh = txtnoisinh.Text;
            String queQuan = txtquequan.Text;
            String email = txtemail.Text;
            dt.themCuDan(phongDK, name, sex, date, CMND, ngayCap, noiCap, sdt, ngonNgu, thuongTru, ngheNghiep, noiLamViec, dantoc, noiSinh, queQuan, email);
        }
    }
}

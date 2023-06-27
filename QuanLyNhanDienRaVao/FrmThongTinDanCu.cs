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
    }
}

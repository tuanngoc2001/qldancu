﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MultiFaceRec
{
    public partial class FrmTaiKhoan : Form
    {
        Data dt = new Data();
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }
        public byte[] ImageToArray(System.Drawing.Image input)
        {
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    input.Save(memory, System.Drawing.Imaging.ImageFormat.Gif);
                    return memory.ToArray();
                }
            }
            catch { return null; }
        }
        public Image toImages(byte[] data)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                bunifuDataGridView1.DataSource = dt.loadTaiKhoan();
                //
                bunifuDataGridView1.Columns[0].HeaderText = "Tên dân cư";
                bunifuDataGridView1.Columns[1].HeaderText = "Mật khẩu";
                bunifuDataGridView1.Columns[2].HeaderText = "Họ tên";
                bunifuDataGridView1.Columns[3].HeaderText = "Ngày sinh";
                bunifuDataGridView1.Columns[4].HeaderText = "Giới tính";
                bunifuDataGridView1.Columns[5].HeaderText = "CMND/CCCD";
                bunifuDataGridView1.Columns[6].HeaderText = "Điện thoại";
                bunifuDataGridView1.Columns[7].HeaderText = "Địa chỉ";
                bunifuDataGridView1.Columns[8].HeaderText = "Chức vụ";
                bunifuDataGridView1.Columns[9].HeaderText = "Hình ảnh";
            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuTextBox2.Text = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            string temp = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            Regex trimmer = new Regex(@"\s\s+");
            bunifuTextBox3.Text = trimmer.Replace(temp, " ");
            bunifuTextBox3.Text = temp;
            bunifuTextBox1.Text = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuDatePicker1.Value = Convert.ToDateTime(bunifuDataGridView1.CurrentRow.Cells[3].Value);
            bunifuDropdown2.Text = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            bunifuTextBox5.Text = bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString();
            bunifuTextBox4.Text = bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString();
            bunifuTextBox6.Text = bunifuDataGridView1.CurrentRow.Cells[7].Value.ToString();
            bunifuDropdown1.Text = bunifuDataGridView1.CurrentRow.Cells[8].Value.ToString();
            //
            try
            {
                pictureBox1.Image = toImages(dt.checkIDImage(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()));
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            if (bunifuTextBox2.Text == String.Empty || bunifuTextBox3.Text == String.Empty
                || bunifuTextBox1.Text == String.Empty || bunifuTextBox5.Text == String.Empty || bunifuTextBox4.Text == String.Empty ||
                 bunifuTextBox6.Text == String.Empty)
            {
                bunifuSnackbar1.Show(this, "Không được để trống!!!",
               Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
            else
            {
                if (dt.checkTK(bunifuTextBox2.Text) == 1)
                {
                    bunifuSnackbar1.Show(this, "Tên tài khoản đã được sử dụng!!!",
                   Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }
                else
                {
                    if (pictureBox1.Image == null)
                    {
                        string temp;
                        if (bunifuDropdown1.Text == "ADMIN")
                        {
                            temp = "1";
                        }
                        else
                        {
                            temp = "0";
                        }
                        dt.themTK(bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox1.Text, bunifuDatePicker1.Value,
                            bunifuDropdown2.Text, bunifuTextBox5.Text, bunifuTextBox4.Text, bunifuTextBox6.Text, bunifuDropdown1.Text, temp, null);
                        //
                        bunifuSnackbar1.Show(this, "Tạo tài khoản thành công!!!",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        //
                        bunifuDataGridView1.DataSource = dt.loadTaiKhoan();
                    }
                    else
                    {
                        byte[] fileByte = ImageToArray(pictureBox1.Image);
                        System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                        //
                        string temp = bunifuDropdown1.SelectedIndex.ToString();
                        dt.themTK(bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox1.Text, bunifuDatePicker1.Value,
                            bunifuDropdown2.Text, bunifuTextBox5.Text, bunifuTextBox4.Text, bunifuTextBox6.Text, bunifuDropdown1.Text, temp, fileBinary);
                        //
                        bunifuSnackbar1.Show(this, "Tạo tài khoản thành công!!!",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        //
                        bunifuDataGridView1.DataSource = dt.loadTaiKhoan();
                    }

                }
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == String.Empty)
            {
                bunifuSnackbar1.Show(this, "Tên đăng nhập không được để trống!!!",
                   Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            else
            {
                if (dt.checkTK(bunifuTextBox2.Text) == 1)
                {
                    dt.xoaTK(bunifuTextBox2.Text);
                    //
                    bunifuSnackbar1.Show(this, "Xóa tài khoản thành công!!!",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    //
                    bunifuDataGridView1.DataSource = dt.loadTaiKhoan();
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Tên tài khoản không tồn tại!!!",
                 Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == String.Empty || bunifuTextBox3.Text == String.Empty
                 || bunifuTextBox1.Text == String.Empty || bunifuTextBox5.Text == String.Empty || bunifuTextBox4.Text == String.Empty ||
                  bunifuTextBox6.Text == String.Empty)
            {
                bunifuSnackbar1.Show(this, "Không được để trống!!!",
               Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
            else
            {
                if (dt.checkTK(bunifuTextBox2.Text) == 0)
                {
                    bunifuSnackbar1.Show(this, "Tên tài khoản không tồn tại!!!",
               Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }
                else
                {
                    string temp;
                    if (bunifuDropdown1.Text == "ADMIN")
                    {
                        temp = "1";
                    }
                    else
                    {
                        temp = "0";
                    }
                    byte[] fileByte = ImageToArray(pictureBox1.Image);
                    System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);
                    dt.suaTK(bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox1.Text, bunifuDatePicker1.Value,
                        bunifuDropdown2.Text, bunifuTextBox5.Text, bunifuTextBox4.Text, bunifuTextBox6.Text, bunifuDropdown1.Text, temp,fileBinary);
                    //
                    bunifuSnackbar1.Show(this, "Sửa tài khoản thành công!!!",
                   Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    //
                    bunifuDataGridView1.DataSource = dt.loadTaiKhoan();
                }
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*jpg;*.jpeg;*.png;*.bmp)|*jpg;*.jpeg;*.png;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }
    }
}

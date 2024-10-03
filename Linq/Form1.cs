using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Linq.Model;
using Linq.Controller;
using Linq.DataLayer;

namespace Linq
{
    public partial class Form1 : Form
    {
        private SanPhamController spcontrol;
        public void LoadData()
        {
            List<SanPham> sanPhams = spcontrol.GetAllSanPham();
            dataGridView2.DataSource = sanPhams;
        }

        public Form1()
        {
            InitializeComponent();
            spcontrol = new SanPhamController();
            LoadData();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham
            {
                MaSanPham = textBox4.Text,
                TenSanPham = textBox3.Text,
                SoLuong = int.Parse(textBox2.Text),
                DonGia = decimal.Parse(textBox1.Text),
                XuatXu = textBox5.Text,
                NgayHetHan = dateTimePicker1.Value,
            };

            spcontrol.AddSanPham(sanPham);

            textBox4.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox5.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MaSP = textBox4.Text;

            bool isDeleted = spcontrol.DeleteSanPham(MaSP);

            if (isDeleted)
            {
                MessageBox.Show("Xóa thành công!");

                textBox4.Text = String.Empty;
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SanPham sanPham = spcontrol.GetSanPhamXuatXuNhatBan();

            if (sanPham != null)
            {
                List<SanPham> SPNhatBanList = new List<SanPham> { sanPham };

                dataGridView1.DataSource = SPNhatBanList;
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
                dataGridView1.DataSource = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string xuatXu = textBox8.Text;

            bool isDeleted = spcontrol.DeleteSanPhamsByXuatXu(xuatXu);

            if (isDeleted)
            {
                MessageBox.Show("Xóa thành công!");

                textBox8.Text = string.Empty;
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SanPham sp = spcontrol.GetSanPhamCoDonGiaCaoNhat();

            if (sp != null)
            {
                List<SanPham> sanPhamMaxList = new List<SanPham> { sp };

                dataGridView1.DataSource = sanPhamMaxList;
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào.");
                dataGridView1.DataSource = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<SanPham> sanPhamsQuaHan = spcontrol.GetSanPhamQuaHan();

            if (sanPhamsQuaHan != null && sanPhamsQuaHan.Count > 0)
            {
                dataGridView1.DataSource = sanPhamsQuaHan;
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào đã quá hạn.");
                dataGridView1.DataSource = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giới hạn đơn giá");
                return;
            }

            List<SanPham> sanPhamsDonGia = spcontrol.GetSanPhamCoDonGia(decimal.Parse(textBox6.Text), decimal.Parse(textBox7.Text));

            if (sanPhamsDonGia != null && sanPhamsDonGia.Count > 0)
            {
                dataGridView1.DataSource = sanPhamsDonGia;
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
                dataGridView1.DataSource = null;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                bool isDeleted = spcontrol.DeleteAllSanPham();

                if (isDeleted)
                {
                    MessageBox.Show("Xóa thành công!");

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Lỗi.");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool isDeleted = spcontrol.DeleteExpiredSanPham();

                if (isDeleted)
                {
                    MessageBox.Show("Xóa thành công!");

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào quá hạn.");
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

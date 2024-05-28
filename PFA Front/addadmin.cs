using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PFA_Front;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Xml.Linq;

namespace PFA_Front
{
    public partial class addadmin : Form
    {
        
        
        public addadmin()
        {
            
            InitializeComponent();
            panel1.Visible=false;
            panel1.Hide();
            showTable();



        }

        




        admin admin = new admin();

        
        private void button_upload_Click(object sender, EventArgs e)
        {


        }



        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void showTable()
        {
            DataGridView_admin.DataSource = admin.getadminlist();
            DataGridView_admin.RowTemplate.Height = 40;
            DataGridView_admin.ColumnHeadersHeight = 30;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_admin.Columns[5];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridView_admin.Columns["id"].Width = 22;

            



        }




        private void registerForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void edit_Click_1(object sender, EventArgs e)
        {
            if (panel1.Visible == false) 
            {
                panel1.Show();
                panel1.Visible = true;
            }

            else
            {
                panel1.Hide();
                panel1.Visible = false;

            }

        }

        private void button_upload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select photo(.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            string fname = textBox4.Text;
            string lname = textBox3.Text;
            string email = textBox2.Text;
            string password = textBox_password.Text;
            string number = textBox1.Text;
            //string city = textBox_city.Text;
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            //Image img = pictureBox1.Image;
            if (!Verify())
            {
                try
                {
                    if (admin.insertAdmin(fname, lname, email, password, number, img))
                    {
                        showTable();
                        MessageBox.Show("u have been registered succesfully", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("some fiels are empty", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        bool Verify()
        {
            string fname = textBox4.Text.Trim();
            string lname = textBox3.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox_password.Text;
            string number = textBox1.Text.Trim();
            //string city = textBox_city.Text.Trim();
            if (fname.Length < 3 || fname.Length > 25)
                MessageBox.Show("fname", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (lname.Length < 3 || lname.Length > 25)
                MessageBox.Show("lname", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (!IsValidEmail(email))
                MessageBox.Show("email", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 25)
                MessageBox.Show("password", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (!number.StartsWith("+216") && !string.IsNullOrEmpty(number))
                MessageBox.Show("number", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (pictureBox1.Image == null)
                MessageBox.Show("Image", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            if (fname.Length < 3 || fname.Length > 25 ||
                lname.Length < 3 || lname.Length > 25 ||
                !IsValidEmail(email) || string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 25 ||
                (number.Length < 8 || number.Length > 13) ||
                (!string.IsNullOrEmpty(number)) ||
                pictureBox1.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this admin?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (DataGridView_admin.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a admin to delete.");
                    return;
                }
                int id = Convert.ToInt32(DataGridView_admin.SelectedRows[0].Cells["id"].Value);
                admin.deleteAdmin(id);
                showTable();

            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (DataGridView_admin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }



            
            string originalemail = Convert.ToString(DataGridView_admin.SelectedRows[0].Cells["email"].Value);
           
            

            admin.UpdateAdmins(textBox_fname.Text, textBox_lname.Text,  textBox_number.Text, originalemail,  textBox_email.Text);
            showTable();
            panel1.Hide();
            
        }
    }
  }


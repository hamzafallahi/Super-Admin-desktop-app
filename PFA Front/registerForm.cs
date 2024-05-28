using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace PFA_Front
{
    public partial class registerForm : Form
    {
        admin admin= new admin();
        public registerForm()
        {
            InitializeComponent();
        }
        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);






        #endregion
        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select photo(.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            if(ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image=Image.FromFile(ofd.FileName);

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string fname = textBox_fname.Text;
            string lname = textBox_lname.Text;
            string email = textBox_email.Text;
            string password = textBox_password.Text;
            string number = textBox_number.Text;
            //string city = textBox_city.Text;
            MemoryStream ms= new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img=ms.ToArray();
            //Image img = pictureBox1.Image;
            if (Verify())
            {
                try { 
                if(admin.insertAdmin(fname, lname, email, password, number, img))
                {
                        showTable();
                    MessageBox.Show("u have been registered succesfully","add admin",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            string fname = textBox_fname.Text.Trim();
            string lname = textBox_lname.Text.Trim();
            string email = textBox_email.Text.Trim();
            string password = textBox_password.Text;
            string number = textBox_number.Text.Trim();
            //string city = textBox_city.Text.Trim();
            if (fname.Length < 3 || fname.Length > 25)
                MessageBox.Show("fname", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (lname.Length < 3 || lname.Length > 25)
                MessageBox.Show("lname", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (!IsValidEmail(email))
                MessageBox.Show("email", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 25)
                MessageBox.Show("password", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (!number.StartsWith("+126") && !string.IsNullOrEmpty(number))
                MessageBox.Show("number", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (pictureBox1.Image == null)
                MessageBox.Show("Image", "add admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            if (fname.Length < 3 || fname.Length > 25 ||
                lname.Length < 3 || lname.Length > 25 ||
                !IsValidEmail(email) || string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 25 ||
                (number.Length < 8 || number.Length > 13) ||
                ( !string.IsNullOrEmpty(number))  ||
                pictureBox1.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            DataGridView_student.DataSource = admin.getadminlist();
            DataGridView_student.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[2];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;




        }


        /*public void showTable()
            {
                DataGridView_student.DataSource = admin.getstudentslist();
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                string imagePath =@+(string)DataGridView_student.Columns[2];
                Image image = Image.FromFile(imagePath);
                imageColumn = (DataGridViewImageColumn)image;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }*/

        private void registerForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
    }
}

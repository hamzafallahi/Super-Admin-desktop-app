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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;

namespace PFA_Front
{
    public partial class users : Form
    {

        public users( )
        {
            InitializeComponent();
            panel1.Hide();
            panel1.Visible = false;
            
        }

        

        admin admin = new admin();



        private void user_Load(object sender, EventArgs e)
        {
            //DataGridView_users.DataSource = admin.getstudentslist();
            //DataGridView_users.DataSource = admin.getstinstructorlist();

        }



        private void searchbtn_Click(object sender, EventArgs e)
        {
            DataGridView_users.Controls.Clear();
            string srch = search.Text;
            if (radioButton_instructor.Checked)
            {

                DataGridView_users.DataSource = admin.getstinstructorlist(srch);
                DataGridView_users.RowTemplate.Height = 30;
                DataGridView_users.ColumnHeadersHeight = 30;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_users.Columns[5];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            }
            else if (radioButton_student.Checked)
            {

                DataGridView_users.DataSource = admin.getstudentslist(srch);
                DataGridView_users.RowTemplate.Height = 30;
                DataGridView_users.ColumnHeadersHeight = 30;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_users.Columns[5];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select photo(.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox3.Image = Image.FromFile(ofd.FileName);

        }
        private void save_Click(object sender, EventArgs e)
        {
            //DataGridViewCellEventArgs e;
            if (DataGridView_users.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }

            string fname = textBox_fname.Text;
            string lname = textBox_lname.Text;
            string phone = textBox_number.Text;
            string email = textBox_email.Text;


            int id = Convert.ToInt32(DataGridView_users.SelectedRows[0].Cells["id"].Value);
            string originalemail = Convert.ToString(DataGridView_users.SelectedRows[0].Cells["email"].Value);
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            admin.UpdateUser(id, originalemail, fname, lname, phone, email, img);
            DataGridView_users.Controls.Clear();

        }



        private void edit_Click(object sender, EventArgs e)
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

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (DataGridView_users.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a user to delete.");
                    return;
                }
                int id = Convert.ToInt32(DataGridView_users.SelectedRows[0].Cells["id"].Value);
                admin.deleteUser(id);
                DataGridView_users.Controls.Clear();

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
             textBox_fname.Text = textBox_lname.Text = textBox_email.Text =  textBox_number.Text = "";

        }
    }
}

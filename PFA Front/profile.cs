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

namespace PFA_Front
{
    public partial class profile : Form
    {
        admin admin = new admin();
        DBconnect connect = new DBconnect();
        public string receivedEmail;
        public profile(string Email)
        {
            receivedEmail=Email;
            InitializeComponent();
            panel1.Hide();
            panel1.Visible = false;
            MySqlCommand command = admin.GetCurrentInfo(receivedEmail);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string name = reader.GetString("name");
                    string lastName = reader.GetString("lname");
                    string mail = reader.GetString("email");
                    string phoneNumber = reader.GetString("number");

                    // Assign column values to labels
                    fname.Text = name;
                    lname.Text = lastName;
                    email.Text = mail;
                    phone.Text = phoneNumber;
                    if (!reader.IsDBNull(reader.GetOrdinal("photo")))
                    {
                        // Read the photo data as a byte array
                        byte[] photoData = (byte[])reader["photo"];

                        // Convert the byte array to an Image
                        using (MemoryStream ms = new MemoryStream(photoData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }


                }
                else

                {
                    MessageBox.Show("errorrrrr", "errrorrr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            connect.closeConnection(); // Close the connection after reading data
        }

        #region Drag Form/ Mover form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);






        #endregion

        

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

        private void save_Click(object sender, EventArgs e)
        {
            MemoryStream ms1 = new MemoryStream();
            pictureBox1.Image.Save(ms1, pictureBox1.Image.RawFormat);
            byte[] img = ms1.ToArray();
            receivedEmail =admin.UpdateAdmin(textBox_fname.Text,textBox_lname.Text, textBox_passwordnew.Text, textBox_number.Text, receivedEmail, img, textBox_email.Text);
            panel1.Hide();
            MySqlCommand command = admin.GetCurrentInfo(receivedEmail);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string name = reader.GetString("name");
                    string lastName = reader.GetString("lname");
                    string mail = reader.GetString("email");
                    string phoneNumber = reader.GetString("number");

                    // Assign column values to labels
                    fname.Text = name;
                    lname.Text = lastName;
                    email.Text = mail;
                    phone.Text = phoneNumber;
                    if (!reader.IsDBNull(reader.GetOrdinal("photo")))
                    {
                        // Read the photo data as a byte array
                        byte[] photoData = (byte[])reader["photo"];

                        // Convert the byte array to an Image
                        using (MemoryStream ms = new MemoryStream(photoData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }


                }
                else

                {
                    MessageBox.Show("errorrrrr", "errrorrr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            connect.closeConnection(); // Close the connection after reading data
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox_password.Text = textBox_fname.Text=textBox_lname.Text= textBox_email.Text= textBox_passwordnew.Text= textBox_number.Text =  "";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select photo(.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}

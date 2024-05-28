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

namespace PFA_Front
{
    public partial class login : Form
    {
        admin admin = new admin();
        public login()
        {
            InitializeComponent();
        }

        #region Drag Form/ Mover form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder 
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (textBox_email.Text == "Email")
            {
                textBox_email.Text = "";
                textBox_email.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (textBox_email.Text == "")
            {
                textBox_email.Text = "Email";
                textBox_email.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (textBox_password.Text == "Password")
            {
                textBox_password.Text = "";
                textBox_password.ForeColor = Color.LightGray;
                textBox_password.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (textBox_password.Text == "")
            {
                textBox_password.Text = "Password";
                textBox_password.ForeColor = Color.Silver;
                textBox_password.UseSystemPasswordChar = false;
            }
        }

        #endregion 





        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = textBox_email.Text;
            string password = textBox_password.Text;

            if (admin.LoginAdmin(email, password) != -1)
            {
                //MessageBox.Show("logged in seccuss", "login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //admin.Email = email;
                Form Form1 = new Form1(email);
                

                Form1.Show();
                this.Hide();



            }

            else

            {
                MessageBox.Show("cordinates are wrong", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

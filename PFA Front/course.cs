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
using System.Windows;

namespace PFA_Front
{
    



        


public partial class course : Form
    {
        admin admin = new admin();
        

        public course()
        {
            InitializeComponent();
        }



        private void course_Load_1(object sender, EventArgs e)
        {


            panel1.Controls.Clear();
            //TopLevel = false;



            int numRows = 0;
            int totalHeight = 0;
            int padding = 30;
            int ControlWidth = 100;
            int ControlHeight = 150;
            var courseDataList = admin.RetrieveCourseDataFromDatabase();

            if (courseDataList != null && courseDataList.Count > 0)
            {
                int maxWidth = panel1.Width - padding * 2;
                int x = padding + 60;
                int y = padding;

                foreach (var userData in courseDataList)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromStream(new MemoryStream(userData.ImageData));
                    pictureBox.Size = new System.Drawing.Size(ControlWidth, ControlHeight);
                    pictureBox.Location = new System.Drawing.Point(x, y);
                    panel1.Controls.Add(pictureBox);
                    pictureBox.Click += (s, ev) =>
                    {
                        panel1.Controls.Clear();
                        // Create and show new form on picture click
                        Form courselandingpage1 = new courselandingpage(userData.id, userData.Title, userData.Subtitle, userData.description, userData.category, userData.courseprice, userData.ImageData);
                        // Use Show() if you want a non-modal form
                        courselandingpage1.TopLevel = false;
                        panel1.Controls.Add(courselandingpage1);
                        courselandingpage1.Size = panel1.Size;
                        // Optionally pass data to the new form
                        //courselandingpage1.SetData(userData);
                        courselandingpage1.Show();
                    };

                    Label nameLabel = new Label();
                    nameLabel.Text = userData.Title;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new System.Drawing.Point(x, y + ControlHeight);
                    panel1.Controls.Add(nameLabel);

                    x += ControlWidth + padding;

                    if (x + ControlWidth > maxWidth)
                    {
                        x = padding + 60;
                        y += ControlHeight + padding * 3;
                    }

                }

                // Calculate total height needed based on the number of rows
                numRows = (courseDataList.Count - 1) / (maxWidth / ControlWidth) + 1;
                totalHeight = numRows * (ControlHeight + padding * 3);

                // If the total height exceeds the form height, show a vertical scrollbar
                if (totalHeight > panel1.Height)
                {
                    AutoScroll = true;
                    AutoScrollMinSize = new System.Drawing.Size(panel1.Width, totalHeight);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No course data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //TopLevel = false;



            int numRows = 0;
            int totalHeight = 0;
            int padding = 30;
            int ControlWidth = 100;
            int ControlHeight = 150;
            var courseDataList = admin.RetrieveCourseDataFromDatabase(search.Text);

            if (courseDataList != null && courseDataList.Count > 0)
            {
                int maxWidth = panel1.Width - padding * 2;
                int x = padding + 60;
                int y = padding;

                foreach (var userData in courseDataList)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromStream(new MemoryStream(userData.ImageData));
                    pictureBox.Size = new System.Drawing.Size(ControlWidth, ControlHeight);
                    pictureBox.Location = new System.Drawing.Point(x, y);
                    panel1.Controls.Add(pictureBox);
                    pictureBox.Click += (s, ev) =>
                    {
                        panel1.Controls.Clear();
                        // Create and show new form on picture click
                        Form courselandingpage1 = new courselandingpage(userData.id, userData.Title, userData.Subtitle, userData.description, userData.category, userData.courseprice, userData.ImageData);
                        // Use Show() if you want a non-modal form
                        courselandingpage1.TopLevel = false; 
                        panel1.Controls.Add(courselandingpage1);
                        courselandingpage1.Size = panel1.Size;
                        // Optionally pass data to the new form
                        //courselandingpage1.SetData(userData);
                        courselandingpage1.Show();
                    };

                    Label nameLabel = new Label();
                    nameLabel.Text = userData.Title;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new System.Drawing.Point(x, y + ControlHeight);
                    panel1.Controls.Add(nameLabel);

                    x += ControlWidth + padding;

                    if (x + ControlWidth > maxWidth)
                    {
                        x = padding + 60;
                        y += ControlHeight + padding * 3;
                    }

                }

                // Calculate total height needed based on the number of rows
                numRows = (courseDataList.Count - 1) / (maxWidth / ControlWidth) + 1;
                totalHeight = numRows * (ControlHeight + padding * 3);

                // If the total height exceeds the form height, show a vertical scrollbar
                if (totalHeight > panel1.Height)
                {
                    AutoScroll = true;
                    AutoScrollMinSize = new System.Drawing.Size(panel1.Width, totalHeight);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No course data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void srch_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //TopLevel = false;



            int numRows = 0;
            int totalHeight = 0;
            int padding = 30;
            int ControlWidth = 100;
            int ControlHeight = 150;
            var courseDataList = admin.RetrieveCourseDataFromDatabase(search.Text);
            if (courseDataList != null && courseDataList.Count > 0)
            {
                int maxWidth = panel1.Width - padding * 2;
                int x = padding + 60;
                int y = padding;

                foreach (var userData in courseDataList)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromStream(new MemoryStream(userData.ImageData));
                    pictureBox.Size = new System.Drawing.Size(ControlWidth, ControlHeight);
                    pictureBox.Location = new System.Drawing.Point(x, y);
                    panel1.Controls.Add(pictureBox);
                    pictureBox.Click += (s, ev) =>
                    {
                        panel1.Controls.Clear();
                        // Create and show new form on picture click
                        Form courselandingpage1 = new courselandingpage(userData.id, userData.Title, userData.Subtitle, userData.description, userData.category, userData.courseprice, userData.ImageData);
                        // Use Show() if you want a non-modal form
                        courselandingpage1.TopLevel = false;
                        panel1.Controls.Add(courselandingpage1);
                        courselandingpage1.Size = panel1.Size;
                        // Optionally pass data to the new form
                        //courselandingpage1.SetData(userData);
                        courselandingpage1.Show();
                    };
                    Label nameLabel = new Label();
                    nameLabel.Text = userData.Title;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new System.Drawing.Point(x, y + ControlHeight);
                    panel1.Controls.Add(nameLabel);

                    x += ControlWidth + padding;

                    if (x + ControlWidth > maxWidth)
                    {
                        x = padding + 60;
                        y += ControlHeight + padding * 3;
                    }
                }

                // Calculate total height needed based on the number of rows
                numRows = (courseDataList.Count - 1) / (maxWidth / ControlWidth) + 1;
                totalHeight = numRows * (ControlHeight + padding * 3);

                // If the total height exceeds the form height, show a vertical scrollbar
                if (totalHeight > panel1.Height)
                {
                    AutoScroll = true;
                    AutoScrollMinSize = new System.Drawing.Size(panel1.Width, totalHeight);
                }
            }
            else
            {
               System.Windows.Forms.MessageBox.Show("No course data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }




}

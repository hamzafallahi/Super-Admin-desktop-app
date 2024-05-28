using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFA_Front
{
    public partial class courselandingpage : Form
    {
        admin admin = new admin();
        public courselandingpage(int id,string title="",string sub = "", string desc = "",string cat = "", int price=0, byte[] img=null)
        {
            InitializeComponent();
            label1.Text = title;
            label2.Text = sub;
            label3.Text = desc;
            label4.Text = cat;
            label5.Text = "Price : "+price.ToString()+" DT";
            img1.Image = Image.FromStream(new MemoryStream(img));
            DataGridView_users.DataSource = admin.getsubstudentslist(id);
            DataGridView_users.RowTemplate.Height = 30;
            DataGridView_users.ColumnHeadersHeight = 30;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_users.Columns[5];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

        }

    }
}

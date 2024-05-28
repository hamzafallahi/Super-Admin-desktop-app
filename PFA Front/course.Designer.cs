namespace PFA_Front
{
    partial class course
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.srch = new FontAwesome.Sharp.IconButton();
            this.search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // srch
            // 
            this.srch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.srch.IconColor = System.Drawing.Color.Black;
            this.srch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.srch.IconSize = 20;
            this.srch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.srch.Location = new System.Drawing.Point(656, 26);
            this.srch.Name = "srch";
            this.srch.Size = new System.Drawing.Size(66, 23);
            this.srch.TabIndex = 23;
            this.srch.Text = "search";
            this.srch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.srch.UseVisualStyleBackColor = true;
            this.srch.Click += new System.EventHandler(this.srch_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(341, 29);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(309, 20);
            this.search.TabIndex = 22;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 524);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(104)))));
            this.panel2.Location = new System.Drawing.Point(-3, -5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 79);
            this.panel2.TabIndex = 25;
            // 
            // course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 597);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.srch);
            this.Controls.Add(this.search);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "course";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.course_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton srch;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}


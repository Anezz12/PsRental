namespace PsRental
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PsMenu = new System.Windows.Forms.Button();
            this.CustumerMenu = new System.Windows.Forms.Button();
            this.RentalMenu = new System.Windows.Forms.Button();
            this.ReturnMenu = new System.Windows.Forms.Button();
            this.UserMenu = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 126);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1125, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "x";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(442, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 34);
            this.label6.TabIndex = 9;
            this.label6.Text = "Main Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(421, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "RENTAL PS YK";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(352, 225);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(393, 322);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            // 
            // PsMenu
            // 
            this.PsMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PsMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PsMenu.Location = new System.Drawing.Point(147, 147);
            this.PsMenu.Name = "PsMenu";
            this.PsMenu.Size = new System.Drawing.Size(129, 53);
            this.PsMenu.TabIndex = 11;
            this.PsMenu.Text = "PS";
            this.PsMenu.UseVisualStyleBackColor = false;
            this.PsMenu.Click += new System.EventHandler(this.PsMenu_Click);
            // 
            // CustumerMenu
            // 
            this.CustumerMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CustumerMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustumerMenu.Location = new System.Drawing.Point(282, 147);
            this.CustumerMenu.Name = "CustumerMenu";
            this.CustumerMenu.Size = new System.Drawing.Size(129, 53);
            this.CustumerMenu.TabIndex = 12;
            this.CustumerMenu.Text = "CUSTUMER";
            this.CustumerMenu.UseVisualStyleBackColor = false;
            this.CustumerMenu.Click += new System.EventHandler(this.CustumerMenu_Click);
            // 
            // RentalMenu
            // 
            this.RentalMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.RentalMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RentalMenu.Location = new System.Drawing.Point(417, 147);
            this.RentalMenu.Name = "RentalMenu";
            this.RentalMenu.Size = new System.Drawing.Size(129, 53);
            this.RentalMenu.TabIndex = 13;
            this.RentalMenu.Text = "RENTAL";
            this.RentalMenu.UseVisualStyleBackColor = false;
            this.RentalMenu.Click += new System.EventHandler(this.RentalMenu_Click);
            // 
            // ReturnMenu
            // 
            this.ReturnMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ReturnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnMenu.Location = new System.Drawing.Point(552, 147);
            this.ReturnMenu.Name = "ReturnMenu";
            this.ReturnMenu.Size = new System.Drawing.Size(129, 53);
            this.ReturnMenu.TabIndex = 14;
            this.ReturnMenu.Text = "RETURN";
            this.ReturnMenu.UseVisualStyleBackColor = false;
            this.ReturnMenu.Click += new System.EventHandler(this.ReturnMenu_Click);
            // 
            // UserMenu
            // 
            this.UserMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.UserMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserMenu.Location = new System.Drawing.Point(687, 147);
            this.UserMenu.Name = "UserMenu";
            this.UserMenu.Size = new System.Drawing.Size(129, 53);
            this.UserMenu.TabIndex = 15;
            this.UserMenu.Text = "USER";
            this.UserMenu.UseVisualStyleBackColor = false;
            this.UserMenu.Click += new System.EventHandler(this.UserMenu_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(483, 592);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 53);
            this.button6.TabIndex = 17;
            this.button6.Text = "Logout";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(822, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 53);
            this.button1.TabIndex = 18;
            this.button1.Text = "Dashbord";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 742);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.UserMenu);
            this.Controls.Add(this.ReturnMenu);
            this.Controls.Add(this.RentalMenu);
            this.Controls.Add(this.CustumerMenu);
            this.Controls.Add(this.PsMenu);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Button PsMenu;
        private System.Windows.Forms.Button CustumerMenu;
        private System.Windows.Forms.Button RentalMenu;
        private System.Windows.Forms.Button ReturnMenu;
        private System.Windows.Forms.Button UserMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
    }
}
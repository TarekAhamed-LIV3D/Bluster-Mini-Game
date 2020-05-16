namespace BLUSTER
{
    partial class Bluster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bluster));
            this.movebabckgroundtimer = new System.Windows.Forms.Timer(this.components);
            this.mothership = new System.Windows.Forms.PictureBox();
            this.movbullettimer = new System.Windows.Forms.Timer(this.components);
            this.moveenemies = new System.Windows.Forms.Timer(this.components);
            this.Enemybulletspeedtimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mothership)).BeginInit();
            this.SuspendLayout();
            // 
            // movebabckgroundtimer
            // 
            this.movebabckgroundtimer.Enabled = true;
            this.movebabckgroundtimer.Interval = 10;
            this.movebabckgroundtimer.Tick += new System.EventHandler(this.movebabckgroundtimer_Tick);
            // 
            // mothership
            // 
            this.mothership.BackColor = System.Drawing.Color.Transparent;
            this.mothership.Image = ((System.Drawing.Image)(resources.GetObject("mothership.Image")));
            this.mothership.Location = new System.Drawing.Point(275, 400);
            this.mothership.Name = "mothership";
            this.mothership.Size = new System.Drawing.Size(50, 50);
            this.mothership.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mothership.TabIndex = 0;
            this.mothership.TabStop = false;
            this.mothership.Click += new System.EventHandler(this.mothership_Click);
            // 
            // movbullettimer
            // 
            this.movbullettimer.Enabled = true;
            this.movbullettimer.Interval = 5;
            this.movbullettimer.Tick += new System.EventHandler(this.movbullettimer_Tick);
            // 
            // moveenemies
            // 
            this.moveenemies.Enabled = true;
            this.moveenemies.Tick += new System.EventHandler(this.moveenemies_Tick);
            // 
            // Enemybulletspeedtimer
            // 
            this.Enemybulletspeedtimer.Enabled = true;
            this.Enemybulletspeedtimer.Interval = 30;
            this.Enemybulletspeedtimer.Tick += new System.EventHandler(this.Enemybulletspeedtimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Montserrat Subrayada", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(205, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "EXIT To MAIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(205, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Replay";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Permanent Marker", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(97, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Location = new System.Drawing.Point(-1, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Location = new System.Drawing.Point(537, 9);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bluster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mothership);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "Bluster";
            this.Text = "BLUSTER";
            this.Load += new System.EventHandler(this.Bluster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bluster_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Bluster_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Bluster_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mothership)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer movebabckgroundtimer;
        private System.Windows.Forms.PictureBox mothership;
        private System.Windows.Forms.Timer movbullettimer;
        private System.Windows.Forms.Timer moveenemies;
        private System.Windows.Forms.Timer Enemybulletspeedtimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


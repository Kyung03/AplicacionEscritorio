namespace horno_datos_servidor.forms
{
    partial class usu_agr
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
            this.btn_usu_agr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_nom_usu = new System.Windows.Forms.TextBox();
            this.txt_con_usu = new System.Windows.Forms.TextBox();
            this.txt_tip_usu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_usu_agr
            // 
            this.btn_usu_agr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_usu_agr.Location = new System.Drawing.Point(290, 250);
            this.btn_usu_agr.Name = "btn_usu_agr";
            this.btn_usu_agr.Size = new System.Drawing.Size(75, 33);
            this.btn_usu_agr.TabIndex = 0;
            this.btn_usu_agr.Text = "Agregar";
            this.btn_usu_agr.UseVisualStyleBackColor = true;
            this.btn_usu_agr.Click += new System.EventHandler(this.Btn_usu_agr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(149, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contrasena";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(389, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "00/00/0000";
            // 
            // txt_nom_usu
            // 
            this.txt_nom_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom_usu.Location = new System.Drawing.Point(153, 118);
            this.txt_nom_usu.Name = "txt_nom_usu";
            this.txt_nom_usu.Size = new System.Drawing.Size(139, 26);
            this.txt_nom_usu.TabIndex = 7;
            // 
            // txt_con_usu
            // 
            this.txt_con_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_con_usu.Location = new System.Drawing.Point(153, 204);
            this.txt_con_usu.Name = "txt_con_usu";
            this.txt_con_usu.PasswordChar = '*';
            this.txt_con_usu.Size = new System.Drawing.Size(139, 26);
            this.txt_con_usu.TabIndex = 8;
            // 
            // txt_tip_usu
            // 
            this.txt_tip_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tip_usu.FormattingEnabled = true;
            this.txt_tip_usu.Location = new System.Drawing.Point(393, 117);
            this.txt_tip_usu.Name = "txt_tip_usu";
            this.txt_tip_usu.Size = new System.Drawing.Size(128, 28);
            this.txt_tip_usu.TabIndex = 9;
            // 
            // usu_agr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.txt_tip_usu);
            this.Controls.Add(this.txt_con_usu);
            this.Controls.Add(this.txt_nom_usu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_usu_agr);
            this.MaximumSize = new System.Drawing.Size(700, 350);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "usu_agr";
            this.Text = "usu_agr";
            this.Load += new System.EventHandler(this.Usu_agr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_usu_agr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nom_usu;
        private System.Windows.Forms.TextBox txt_con_usu;
        private System.Windows.Forms.ComboBox txt_tip_usu;
    }
}
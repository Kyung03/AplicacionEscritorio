namespace horno_datos_servidor.forms
{
    partial class jef_agr
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
            this.txt_nom_jef = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_agr_jef = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ape_jef = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cod_jef = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_nom_jef
            // 
            this.txt_nom_jef.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom_jef.Location = new System.Drawing.Point(191, 121);
            this.txt_nom_jef.Name = "txt_nom_jef";
            this.txt_nom_jef.Size = new System.Drawing.Size(100, 26);
            this.txt_nom_jef.TabIndex = 11;
            this.txt_nom_jef.TextChanged += new System.EventHandler(this.Txt_nom_fun_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(377, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "00/00/0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha de creacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Añadir jefe de turno";
            // 
            // btn_agr_jef
            // 
            this.btn_agr_jef.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agr_jef.Location = new System.Drawing.Point(299, 237);
            this.btn_agr_jef.Name = "btn_agr_jef";
            this.btn_agr_jef.Size = new System.Drawing.Size(75, 28);
            this.btn_agr_jef.TabIndex = 6;
            this.btn_agr_jef.Text = "Añadir";
            this.btn_agr_jef.UseVisualStyleBackColor = true;
            this.btn_agr_jef.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(375, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Apellido";
            // 
            // txt_ape_jef
            // 
            this.txt_ape_jef.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ape_jef.Location = new System.Drawing.Point(379, 120);
            this.txt_ape_jef.Name = "txt_ape_jef";
            this.txt_ape_jef.Size = new System.Drawing.Size(100, 26);
            this.txt_ape_jef.TabIndex = 13;
            this.txt_ape_jef.TextChanged += new System.EventHandler(this.Txt_ape_fun_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Codigo";
            // 
            // txt_cod_jef
            // 
            this.txt_cod_jef.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod_jef.Location = new System.Drawing.Point(191, 186);
            this.txt_cod_jef.Name = "txt_cod_jef";
            this.txt_cod_jef.Size = new System.Drawing.Size(100, 26);
            this.txt_cod_jef.TabIndex = 15;
            // 
            // jef_agr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.txt_cod_jef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ape_jef);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_nom_jef);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_agr_jef);
            this.MaximumSize = new System.Drawing.Size(700, 350);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "jef_agr";
            this.Text = "jef_agr";
            this.Load += new System.EventHandler(this.Jef_agr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nom_jef;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_agr_jef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ape_jef;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cod_jef;
    }
}
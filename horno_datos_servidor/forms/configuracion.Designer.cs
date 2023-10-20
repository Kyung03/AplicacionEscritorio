namespace horno_datos_servidor.forms
{
    partial class configuracion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_csv = new System.Windows.Forms.TextBox();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.txt_res = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_csv_mcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_min = new System.Windows.Forms.TextBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cofiguraciones";
            // 
            // txt_csv
            // 
            this.txt_csv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_csv.Location = new System.Drawing.Point(92, 120);
            this.txt_csv.Name = "txt_csv";
            this.txt_csv.Size = new System.Drawing.Size(300, 26);
            this.txt_csv.TabIndex = 1;
            // 
            // txt_dir
            // 
            this.txt_dir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dir.Location = new System.Drawing.Point(92, 181);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(300, 26);
            this.txt_dir.TabIndex = 2;
            // 
            // txt_res
            // 
            this.txt_res.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_res.Location = new System.Drawing.Point(92, 236);
            this.txt_res.Name = "txt_res";
            this.txt_res.Size = new System.Drawing.Size(620, 26);
            this.txt_res.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre del archivo csv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Directorio donde se aloja el archivo csv";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Directorio del archivo de resplado";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(340, 403);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 31);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(582, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "Variables EAF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(327, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 27);
            this.button3.TabIndex = 9;
            this.button3.Text = "Base de datos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(92, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Variables MCC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // txt_csv_mcc
            // 
            this.txt_csv_mcc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_csv_mcc.Location = new System.Drawing.Point(412, 120);
            this.txt_csv_mcc.Name = "txt_csv_mcc";
            this.txt_csv_mcc.Size = new System.Drawing.Size(300, 26);
            this.txt_csv_mcc.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(409, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre del archivo csv mcc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(409, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tiempo de espera de lectura";
            // 
            // txt_min
            // 
            this.txt_min.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_min.Location = new System.Drawing.Point(412, 181);
            this.txt_min.Name = "txt_min";
            this.txt_min.Size = new System.Drawing.Size(100, 26);
            this.txt_min.TabIndex = 15;
            this.txt_min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // txt_log
            // 
            this.txt_log.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log.Location = new System.Drawing.Point(92, 297);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(612, 26);
            this.txt_log.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Directorio del registro de la consola";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(518, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "minutos";
            // 
            // configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.txt_min);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_csv_mcc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_res);
            this.Controls.Add(this.txt_dir);
            this.Controls.Add(this.txt_csv);
            this.Controls.Add(this.label1);
            this.Name = "configuracion";
            this.Text = "configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_csv;
        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.TextBox txt_res;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_csv_mcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_min;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
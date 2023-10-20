namespace horno_datos_servidor.forms
{
    partial class config_var_mcc
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
            this.btn_gua_mcc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_var_mcc = new System.Windows.Forms.TextBox();
            this.box_var_mcc = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_gua_mcc
            // 
            this.btn_gua_mcc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gua_mcc.Location = new System.Drawing.Point(361, 360);
            this.btn_gua_mcc.Name = "btn_gua_mcc";
            this.btn_gua_mcc.Size = new System.Drawing.Size(75, 31);
            this.btn_gua_mcc.TabIndex = 0;
            this.btn_gua_mcc.Text = "Guardar";
            this.btn_gua_mcc.UseVisualStyleBackColor = true;
            this.btn_gua_mcc.Click += new System.EventHandler(this.Btn_gua_mcc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Variables del archivo MCC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de variables";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(451, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Variable seleccionada";
            // 
            // txt_var_mcc
            // 
            this.txt_var_mcc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_var_mcc.Location = new System.Drawing.Point(454, 191);
            this.txt_var_mcc.Name = "txt_var_mcc";
            this.txt_var_mcc.Size = new System.Drawing.Size(165, 26);
            this.txt_var_mcc.TabIndex = 4;
            // 
            // box_var_mcc
            // 
            this.box_var_mcc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_var_mcc.FormattingEnabled = true;
            this.box_var_mcc.ItemHeight = 18;
            this.box_var_mcc.Location = new System.Drawing.Point(112, 116);
            this.box_var_mcc.Name = "box_var_mcc";
            this.box_var_mcc.Size = new System.Drawing.Size(241, 184);
            this.box_var_mcc.TabIndex = 5;
            this.box_var_mcc.Click += new System.EventHandler(this.Box_var_mcc_Click);
            // 
            // config_var_mcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.box_var_mcc);
            this.Controls.Add(this.txt_var_mcc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_gua_mcc);
            this.Name = "config_var_mcc";
            this.Text = "config_var_mcc";
            this.Load += new System.EventHandler(this.Config_var_mcc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_gua_mcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_var_mcc;
        private System.Windows.Forms.ListBox box_var_mcc;
    }
}
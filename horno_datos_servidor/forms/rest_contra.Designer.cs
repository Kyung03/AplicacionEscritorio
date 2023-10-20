namespace horno_datos_servidor.forms
{
    partial class rest_contra
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_contra = new System.Windows.Forms.TextBox();
            this.txt_contra_ver = new System.Windows.Forms.TextBox();
            this.btn_rest_contra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restablecer contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nueva contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Escribir contraseña nuevamente";
            // 
            // txt_contra
            // 
            this.txt_contra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contra.Location = new System.Drawing.Point(273, 108);
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.PasswordChar = '*';
            this.txt_contra.Size = new System.Drawing.Size(130, 26);
            this.txt_contra.TabIndex = 3;
            // 
            // txt_contra_ver
            // 
            this.txt_contra_ver.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contra_ver.Location = new System.Drawing.Point(273, 174);
            this.txt_contra_ver.Name = "txt_contra_ver";
            this.txt_contra_ver.PasswordChar = '*';
            this.txt_contra_ver.Size = new System.Drawing.Size(130, 26);
            this.txt_contra_ver.TabIndex = 4;
            // 
            // btn_rest_contra
            // 
            this.btn_rest_contra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rest_contra.Location = new System.Drawing.Point(299, 241);
            this.btn_rest_contra.Name = "btn_rest_contra";
            this.btn_rest_contra.Size = new System.Drawing.Size(75, 25);
            this.btn_rest_contra.TabIndex = 5;
            this.btn_rest_contra.Text = "Aceptar";
            this.btn_rest_contra.UseVisualStyleBackColor = true;
            this.btn_rest_contra.Click += new System.EventHandler(this.Btn_rest_contra_Click);
            // 
            // rest_contra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.btn_rest_contra);
            this.Controls.Add(this.txt_contra_ver);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(700, 350);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "rest_contra";
            this.Text = "rest_contra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_contra;
        private System.Windows.Forms.TextBox txt_contra_ver;
        private System.Windows.Forms.Button btn_rest_contra;
    }
}
namespace WindowsFormsApp1
{
    partial class FormB
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
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nhandulieutuFormA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_guidulieusangFormA = new System.Windows.Forms.TextBox();
            this.btn_chuyenFormA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dữ liệu nhận từ Form A";
            // 
            // tb_nhandulieutuFormA
            // 
            this.tb_nhandulieutuFormA.Location = new System.Drawing.Point(263, 59);
            this.tb_nhandulieutuFormA.Name = "tb_nhandulieutuFormA";
            this.tb_nhandulieutuFormA.ReadOnly = true;
            this.tb_nhandulieutuFormA.Size = new System.Drawing.Size(377, 26);
            this.tb_nhandulieutuFormA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dữ liệu gửi sang Form A";
            // 
            // tb_guidulieusangFormA
            // 
            this.tb_guidulieusangFormA.Location = new System.Drawing.Point(273, 132);
            this.tb_guidulieusangFormA.Name = "tb_guidulieusangFormA";
            this.tb_guidulieusangFormA.Size = new System.Drawing.Size(377, 26);
            this.tb_guidulieusangFormA.TabIndex = 1;
            this.tb_guidulieusangFormA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_guidulieusangFormA_KeyDown);
            // 
            // btn_chuyenFormA
            // 
            this.btn_chuyenFormA.Location = new System.Drawing.Point(263, 242);
            this.btn_chuyenFormA.Name = "btn_chuyenFormA";
            this.btn_chuyenFormA.Size = new System.Drawing.Size(202, 62);
            this.btn_chuyenFormA.TabIndex = 2;
            this.btn_chuyenFormA.Text = "Chuyển sang Form A";
            this.btn_chuyenFormA.UseVisualStyleBackColor = true;
            this.btn_chuyenFormA.Click += new System.EventHandler(this.btn_chuyenFormA_Click);
            // 
            // FormB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_chuyenFormA);
            this.Controls.Add(this.tb_guidulieusangFormA);
            this.Controls.Add(this.tb_nhandulieutuFormA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FormB";
            this.Text = "FormB";
            this.Load += new System.EventHandler(this.FormB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nhandulieutuFormA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_guidulieusangFormA;
        private System.Windows.Forms.Button btn_chuyenFormA;
    }
}
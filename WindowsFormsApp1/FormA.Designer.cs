namespace WindowsFormsApp1
{
    partial class FormA
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
            this.tb_dulieuguiFormB = new System.Windows.Forms.TextBox();
            this.btn_chuyenFormB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nhandulieutuFormB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập dữ liệu cần chuyển sang form B";
            // 
            // tb_dulieuguiFormB
            // 
            this.tb_dulieuguiFormB.Location = new System.Drawing.Point(332, 55);
            this.tb_dulieuguiFormB.Name = "tb_dulieuguiFormB";
            this.tb_dulieuguiFormB.Size = new System.Drawing.Size(254, 26);
            this.tb_dulieuguiFormB.TabIndex = 1;
            // 
            // btn_chuyenFormB
            // 
            this.btn_chuyenFormB.Location = new System.Drawing.Point(300, 298);
            this.btn_chuyenFormB.Name = "btn_chuyenFormB";
            this.btn_chuyenFormB.Size = new System.Drawing.Size(210, 65);
            this.btn_chuyenFormB.TabIndex = 2;
            this.btn_chuyenFormB.Text = "Chuyển sang form B";
            this.btn_chuyenFormB.UseVisualStyleBackColor = true;
            this.btn_chuyenFormB.Click += new System.EventHandler(this.btn_chuyenFormB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lấy dữ liệu từ Form B";
            // 
            // tb_nhandulieutuFormB
            // 
            this.tb_nhandulieutuFormB.Location = new System.Drawing.Point(332, 133);
            this.tb_nhandulieutuFormB.Name = "tb_nhandulieutuFormB";
            this.tb_nhandulieutuFormB.ReadOnly = true;
            this.tb_nhandulieutuFormB.Size = new System.Drawing.Size(254, 26);
            this.tb_nhandulieutuFormB.TabIndex = 1;
            // 
            // FormA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_chuyenFormB);
            this.Controls.Add(this.tb_nhandulieutuFormB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_dulieuguiFormB);
            this.Controls.Add(this.label1);
            this.Name = "FormA";
            this.Text = "FormA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_dulieuguiFormB;
        private System.Windows.Forms.Button btn_chuyenFormB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nhandulieutuFormB;
    }
}
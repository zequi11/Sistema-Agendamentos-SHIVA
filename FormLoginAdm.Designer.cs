namespace SistemaDeAgendementos
{
    partial class FormLoginAdm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSenhaAdmin = new TextBox();
            txtUserAdmin = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(259, 186);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(190, 23);
            label3.Name = "label3";
            label3.Size = new Size(209, 30);
            label3.TabIndex = 10;
            label3.Text = "Bem-Vinda Noemia!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 149);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 9;
            label2.Text = "Senha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(191, 117);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 8;
            label1.Text = "Usuário:";
            // 
            // txtSenhaAdmin
            // 
            txtSenhaAdmin.Location = new Point(247, 146);
            txtSenhaAdmin.Name = "txtSenhaAdmin";
            txtSenhaAdmin.PasswordChar = '*';
            txtSenhaAdmin.Size = new Size(100, 23);
            txtSenhaAdmin.TabIndex = 7;
            // 
            // txtUserAdmin
            // 
            txtUserAdmin.Location = new Point(247, 117);
            txtUserAdmin.Name = "txtUserAdmin";
            txtUserAdmin.Size = new Size(100, 23);
            txtUserAdmin.TabIndex = 6;
            // 
            // FormLoginAdm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 333);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSenhaAdmin);
            Controls.Add(txtUserAdmin);
            Name = "FormLoginAdm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FormLoginAdm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSenhaAdmin;
        private TextBox txtUserAdmin;
    }
}

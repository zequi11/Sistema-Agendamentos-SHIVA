﻿namespace SistemaDeAgendementos
{
    partial class FormVerFichas
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
            dataGridFichas = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridFichas).BeginInit();
            SuspendLayout();
            // 
            // dataGridFichas
            // 
            dataGridFichas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFichas.Location = new Point(451, 29);
            dataGridFichas.Name = "dataGridFichas";
            dataGridFichas.Size = new Size(337, 370);
            dataGridFichas.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(105, 297);
            button1.Name = "button1";
            button1.Size = new Size(109, 37);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormVerFichas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridFichas);
            Name = "FormVerFichas";
            Text = "FormVerFichas";
            ((System.ComponentModel.ISupportInitialize)dataGridFichas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridFichas;
        private Button button1;
    }
}
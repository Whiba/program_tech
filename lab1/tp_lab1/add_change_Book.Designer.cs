namespace tp_lab1
{
    partial class add_change_Book
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
            this.book_name_text = new System.Windows.Forms.TextBox();
            this.publ_text = new System.Windows.Forms.TextBox();
            this.year_text = new System.Windows.Forms.TextBox();
            this.str_numb_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.author_combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Автор:";
            // 
            // book_name_text
            // 
            this.book_name_text.Location = new System.Drawing.Point(131, 36);
            this.book_name_text.Name = "book_name_text";
            this.book_name_text.Size = new System.Drawing.Size(172, 20);
            this.book_name_text.TabIndex = 2;
            // 
            // publ_text
            // 
            this.publ_text.Location = new System.Drawing.Point(131, 66);
            this.publ_text.Name = "publ_text";
            this.publ_text.Size = new System.Drawing.Size(172, 20);
            this.publ_text.TabIndex = 3;
            // 
            // year_text
            // 
            this.year_text.Location = new System.Drawing.Point(131, 96);
            this.year_text.MaxLength = 4;
            this.year_text.Name = "year_text";
            this.year_text.Size = new System.Drawing.Size(172, 20);
            this.year_text.TabIndex = 4;
            // 
            // str_numb_text
            // 
            this.str_numb_text.Location = new System.Drawing.Point(131, 126);
            this.str_numb_text.MaxLength = 4;
            this.str_numb_text.Name = "str_numb_text";
            this.str_numb_text.Size = new System.Drawing.Size(172, 20);
            this.str_numb_text.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Название книги:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Издательство:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Год издания:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Количество страниц:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // author_combo
            // 
            this.author_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.author_combo.FormattingEnabled = true;
            this.author_combo.Location = new System.Drawing.Point(131, 6);
            this.author_combo.Name = "author_combo";
            this.author_combo.Size = new System.Drawing.Size(172, 21);
            this.author_combo.TabIndex = 11;
            // 
            // add_change_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 180);
            this.Controls.Add(this.author_combo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.str_numb_text);
            this.Controls.Add(this.year_text);
            this.Controls.Add(this.publ_text);
            this.Controls.Add(this.book_name_text);
            this.Controls.Add(this.label1);
            this.Name = "add_change_Book";
            this.Text = "Работа с данными книг";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox book_name_text;
        private System.Windows.Forms.TextBox publ_text;
        private System.Windows.Forms.TextBox year_text;
        private System.Windows.Forms.TextBox str_numb_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox author_combo;
    }
}
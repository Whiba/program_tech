namespace LibraryClient
{
    partial class Add_Journal
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.libr_comboBox = new System.Windows.Forms.ComboBox();
            this.reader_comboBox = new System.Windows.Forms.ComboBox();
            this.book_comboBox = new System.Windows.Forms.ComboBox();
            this.number_textBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Библиотекарь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Читатель:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Книга:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Количество:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата выдачи:";
            // 
            // libr_comboBox
            // 
            this.libr_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.libr_comboBox.FormattingEnabled = true;
            this.libr_comboBox.Location = new System.Drawing.Point(100, 6);
            this.libr_comboBox.Name = "libr_comboBox";
            this.libr_comboBox.Size = new System.Drawing.Size(172, 21);
            this.libr_comboBox.TabIndex = 5;
            // 
            // reader_comboBox
            // 
            this.reader_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reader_comboBox.FormattingEnabled = true;
            this.reader_comboBox.Location = new System.Drawing.Point(100, 33);
            this.reader_comboBox.Name = "reader_comboBox";
            this.reader_comboBox.Size = new System.Drawing.Size(172, 21);
            this.reader_comboBox.TabIndex = 6;
            // 
            // book_comboBox
            // 
            this.book_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.book_comboBox.FormattingEnabled = true;
            this.book_comboBox.Location = new System.Drawing.Point(100, 60);
            this.book_comboBox.Name = "book_comboBox";
            this.book_comboBox.Size = new System.Drawing.Size(172, 21);
            this.book_comboBox.TabIndex = 7;
            // 
            // number_textBox
            // 
            this.number_textBox.Location = new System.Drawing.Point(100, 87);
            this.number_textBox.Name = "number_textBox";
            this.number_textBox.Size = new System.Drawing.Size(172, 20);
            this.number_textBox.TabIndex = 8;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(100, 113);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker.TabIndex = 9;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(109, 139);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 10;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // Add_Journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 169);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.number_textBox);
            this.Controls.Add(this.book_comboBox);
            this.Controls.Add(this.reader_comboBox);
            this.Controls.Add(this.libr_comboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Add_Journal";
            this.Text = "Добавит запись в журнал";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox libr_comboBox;
        private System.Windows.Forms.ComboBox reader_comboBox;
        private System.Windows.Forms.ComboBox book_comboBox;
        private System.Windows.Forms.TextBox number_textBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button ok_button;
    }
}
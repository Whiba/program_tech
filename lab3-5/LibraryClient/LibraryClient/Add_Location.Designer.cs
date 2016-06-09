namespace LibraryClient
{
    partial class Add_Location
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
            this.book_comboBox = new System.Windows.Forms.ComboBox();
            this.floor_comboBox = new System.Windows.Forms.ComboBox();
            this.arrang_comboBox = new System.Windows.Forms.ComboBox();
            this.sector_textBox = new System.Windows.Forms.TextBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Книга:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Полка:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Как стоит:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Сектор библиотеки:";
            // 
            // book_comboBox
            // 
            this.book_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.book_comboBox.FormattingEnabled = true;
            this.book_comboBox.Location = new System.Drawing.Point(58, 6);
            this.book_comboBox.Name = "book_comboBox";
            this.book_comboBox.Size = new System.Drawing.Size(214, 21);
            this.book_comboBox.TabIndex = 4;
            // 
            // floor_comboBox
            // 
            this.floor_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.floor_comboBox.FormattingEnabled = true;
            this.floor_comboBox.Location = new System.Drawing.Point(58, 33);
            this.floor_comboBox.Name = "floor_comboBox";
            this.floor_comboBox.Size = new System.Drawing.Size(214, 21);
            this.floor_comboBox.TabIndex = 5;
            // 
            // arrang_comboBox
            // 
            this.arrang_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arrang_comboBox.FormattingEnabled = true;
            this.arrang_comboBox.Location = new System.Drawing.Point(77, 60);
            this.arrang_comboBox.Name = "arrang_comboBox";
            this.arrang_comboBox.Size = new System.Drawing.Size(195, 21);
            this.arrang_comboBox.TabIndex = 6;
            // 
            // sector_textBox
            // 
            this.sector_textBox.Location = new System.Drawing.Point(126, 87);
            this.sector_textBox.Name = "sector_textBox";
            this.sector_textBox.Size = new System.Drawing.Size(146, 20);
            this.sector_textBox.TabIndex = 7;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(103, 113);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 8;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // Add_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.sector_textBox);
            this.Controls.Add(this.arrang_comboBox);
            this.Controls.Add(this.floor_comboBox);
            this.Controls.Add(this.book_comboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Add_Location";
            this.Text = "Добавить местоположение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox book_comboBox;
        private System.Windows.Forms.ComboBox floor_comboBox;
        private System.Windows.Forms.ComboBox arrang_comboBox;
        private System.Windows.Forms.TextBox sector_textBox;
        private System.Windows.Forms.Button ok_button;
    }
}
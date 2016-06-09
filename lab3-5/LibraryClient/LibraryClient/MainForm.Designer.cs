namespace LibraryClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.my_groupBox = new System.Windows.Forms.GroupBox();
            this.page_label = new System.Windows.Forms.Label();
            this.right_button = new System.Windows.Forms.Button();
            this.left_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.table_comboBox = new System.Windows.Forms.ComboBox();
            this.friend_groupBox = new System.Windows.Forms.GroupBox();
            this.friend_page_label = new System.Windows.Forms.Label();
            this.friend_right_button = new System.Windows.Forms.Button();
            this.friend_left_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.friend_delete_button = new System.Windows.Forms.Button();
            this.friend_update_button = new System.Windows.Forms.Button();
            this.friend_add_button = new System.Windows.Forms.Button();
            this.friend_table_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.switch_button = new System.Windows.Forms.Button();
            this.thousand_button = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.my_groupBox.SuspendLayout();
            this.friend_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(656, 480);
            this.dataGridView.TabIndex = 0;
            // 
            // my_groupBox
            // 
            this.my_groupBox.Controls.Add(this.page_label);
            this.my_groupBox.Controls.Add(this.right_button);
            this.my_groupBox.Controls.Add(this.left_button);
            this.my_groupBox.Controls.Add(this.label2);
            this.my_groupBox.Controls.Add(this.label1);
            this.my_groupBox.Controls.Add(this.delete_button);
            this.my_groupBox.Controls.Add(this.update_button);
            this.my_groupBox.Controls.Add(this.add_button);
            this.my_groupBox.Controls.Add(this.table_comboBox);
            this.my_groupBox.Location = new System.Drawing.Point(674, 12);
            this.my_groupBox.Name = "my_groupBox";
            this.my_groupBox.Size = new System.Drawing.Size(137, 203);
            this.my_groupBox.TabIndex = 1;
            this.my_groupBox.TabStop = false;
            this.my_groupBox.Text = "Свой сервер";
            // 
            // page_label
            // 
            this.page_label.AutoSize = true;
            this.page_label.Location = new System.Drawing.Point(62, 179);
            this.page_label.Name = "page_label";
            this.page_label.Size = new System.Drawing.Size(13, 13);
            this.page_label.TabIndex = 7;
            this.page_label.Text = "1";
            // 
            // right_button
            // 
            this.right_button.Location = new System.Drawing.Point(102, 174);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(28, 23);
            this.right_button.TabIndex = 2;
            this.right_button.Text = ">";
            this.right_button.UseVisualStyleBackColor = true;
            this.right_button.Click += new System.EventHandler(this.right_button_Click);
            // 
            // left_button
            // 
            this.left_button.Location = new System.Drawing.Point(9, 174);
            this.left_button.Name = "left_button";
            this.left_button.Size = new System.Drawing.Size(28, 23);
            this.left_button.TabIndex = 6;
            this.left_button.Text = "<";
            this.left_button.UseVisualStyleBackColor = true;
            this.left_button.Click += new System.EventHandler(this.left_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Переключить страницу:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбрать таблицу:";
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(9, 127);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(121, 23);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Удалить";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(9, 98);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(121, 23);
            this.update_button.TabIndex = 2;
            this.update_button.Text = "Изменить";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(9, 69);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(121, 23);
            this.add_button.TabIndex = 1;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // table_comboBox
            // 
            this.table_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.table_comboBox.FormattingEnabled = true;
            this.table_comboBox.Items.AddRange(new object[] {
            "Книги",
            "Жанры",
            "Виды расстановки",
            "Авторы",
            "Виды полок",
            "Журнал",
            "Библиотекари",
            "Местоположения",
            "Читатели",
            "Виды статусов читателя"});
            this.table_comboBox.Location = new System.Drawing.Point(9, 42);
            this.table_comboBox.Name = "table_comboBox";
            this.table_comboBox.Size = new System.Drawing.Size(121, 21);
            this.table_comboBox.TabIndex = 0;
            this.table_comboBox.SelectedIndexChanged += new System.EventHandler(this.table_comboBox_SelectedIndexChanged);
            // 
            // friend_groupBox
            // 
            this.friend_groupBox.Controls.Add(this.friend_page_label);
            this.friend_groupBox.Controls.Add(this.friend_right_button);
            this.friend_groupBox.Controls.Add(this.friend_left_button);
            this.friend_groupBox.Controls.Add(this.label5);
            this.friend_groupBox.Controls.Add(this.friend_delete_button);
            this.friend_groupBox.Controls.Add(this.friend_update_button);
            this.friend_groupBox.Controls.Add(this.friend_add_button);
            this.friend_groupBox.Controls.Add(this.friend_table_comboBox);
            this.friend_groupBox.Controls.Add(this.label4);
            this.friend_groupBox.Location = new System.Drawing.Point(674, 250);
            this.friend_groupBox.Name = "friend_groupBox";
            this.friend_groupBox.Size = new System.Drawing.Size(137, 203);
            this.friend_groupBox.TabIndex = 2;
            this.friend_groupBox.TabStop = false;
            this.friend_groupBox.Text = "Сервер друга";
            // 
            // friend_page_label
            // 
            this.friend_page_label.AutoSize = true;
            this.friend_page_label.Location = new System.Drawing.Point(62, 179);
            this.friend_page_label.Name = "friend_page_label";
            this.friend_page_label.Size = new System.Drawing.Size(13, 13);
            this.friend_page_label.TabIndex = 8;
            this.friend_page_label.Text = "1";
            // 
            // friend_right_button
            // 
            this.friend_right_button.Location = new System.Drawing.Point(102, 174);
            this.friend_right_button.Name = "friend_right_button";
            this.friend_right_button.Size = new System.Drawing.Size(28, 23);
            this.friend_right_button.TabIndex = 7;
            this.friend_right_button.Text = ">";
            this.friend_right_button.UseVisualStyleBackColor = true;
            // 
            // friend_left_button
            // 
            this.friend_left_button.Location = new System.Drawing.Point(9, 174);
            this.friend_left_button.Name = "friend_left_button";
            this.friend_left_button.Size = new System.Drawing.Size(28, 23);
            this.friend_left_button.TabIndex = 6;
            this.friend_left_button.Text = "<";
            this.friend_left_button.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Переключить страницу:";
            // 
            // friend_delete_button
            // 
            this.friend_delete_button.Location = new System.Drawing.Point(9, 127);
            this.friend_delete_button.Name = "friend_delete_button";
            this.friend_delete_button.Size = new System.Drawing.Size(121, 23);
            this.friend_delete_button.TabIndex = 4;
            this.friend_delete_button.Text = "Удалить";
            this.friend_delete_button.UseVisualStyleBackColor = true;
            this.friend_delete_button.Click += new System.EventHandler(this.friend_delete_button_Click);
            // 
            // friend_update_button
            // 
            this.friend_update_button.Location = new System.Drawing.Point(9, 98);
            this.friend_update_button.Name = "friend_update_button";
            this.friend_update_button.Size = new System.Drawing.Size(121, 23);
            this.friend_update_button.TabIndex = 3;
            this.friend_update_button.Text = "Изменить";
            this.friend_update_button.UseVisualStyleBackColor = true;
            this.friend_update_button.Click += new System.EventHandler(this.friend_update_button_Click);
            // 
            // friend_add_button
            // 
            this.friend_add_button.Location = new System.Drawing.Point(9, 69);
            this.friend_add_button.Name = "friend_add_button";
            this.friend_add_button.Size = new System.Drawing.Size(121, 23);
            this.friend_add_button.TabIndex = 2;
            this.friend_add_button.Text = "Добавить";
            this.friend_add_button.UseVisualStyleBackColor = true;
            this.friend_add_button.Click += new System.EventHandler(this.friend_add_button_Click);
            // 
            // friend_table_comboBox
            // 
            this.friend_table_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.friend_table_comboBox.FormattingEnabled = true;
            this.friend_table_comboBox.Items.AddRange(new object[] {
            "Должность",
            "Сотрудник.",
            "Страна",
            "Производитель",
            "Журнал производства",
            "Продукция",
            "Журнал поставок.",
            "Стоимость",
            "Магазин",
            "Профиль"});
            this.friend_table_comboBox.Location = new System.Drawing.Point(9, 42);
            this.friend_table_comboBox.Name = "friend_table_comboBox";
            this.friend_table_comboBox.Size = new System.Drawing.Size(121, 21);
            this.friend_table_comboBox.TabIndex = 1;
            this.friend_table_comboBox.SelectedIndexChanged += new System.EventHandler(this.friend_table_comboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Выбрать таблицу:";
            // 
            // switch_button
            // 
            this.switch_button.Location = new System.Drawing.Point(695, 221);
            this.switch_button.Name = "switch_button";
            this.switch_button.Size = new System.Drawing.Size(91, 23);
            this.switch_button.TabIndex = 3;
            this.switch_button.Text = "Переключить";
            this.switch_button.UseVisualStyleBackColor = true;
            this.switch_button.Click += new System.EventHandler(this.switch_button_Click);
            // 
            // thousand_button
            // 
            this.thousand_button.Location = new System.Drawing.Point(674, 459);
            this.thousand_button.Name = "thousand_button";
            this.thousand_button.Size = new System.Drawing.Size(137, 23);
            this.thousand_button.TabIndex = 4;
            this.thousand_button.Text = "Добавить 100 000";
            this.thousand_button.UseVisualStyleBackColor = true;
            this.thousand_button.Click += new System.EventHandler(this.thousand_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 504);
            this.Controls.Add(this.thousand_button);
            this.Controls.Add(this.switch_button);
            this.Controls.Add(this.friend_groupBox);
            this.Controls.Add(this.my_groupBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Клиент";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.my_groupBox.ResumeLayout(false);
            this.my_groupBox.PerformLayout();
            this.friend_groupBox.ResumeLayout(false);
            this.friend_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox my_groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.ComboBox table_comboBox;
        private System.Windows.Forms.Label page_label;
        private System.Windows.Forms.Button right_button;
        private System.Windows.Forms.Button left_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox friend_groupBox;
        private System.Windows.Forms.Label friend_page_label;
        private System.Windows.Forms.Button friend_right_button;
        private System.Windows.Forms.Button friend_left_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button friend_delete_button;
        private System.Windows.Forms.Button friend_update_button;
        private System.Windows.Forms.Button friend_add_button;
        private System.Windows.Forms.ComboBox friend_table_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button switch_button;
        private System.Windows.Forms.Button thousand_button;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


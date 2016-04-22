namespace tp_lab1
{
    partial class workForm
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
            this.tableData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.catalogComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.changeUserButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.oneleft_button = new System.Windows.Forms.Button();
            this.right_button = new System.Windows.Forms.Button();
            this.grantleft_button = new System.Windows.Forms.Button();
            this.grantright_button = new System.Windows.Forms.Button();
            this.page_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableData
            // 
            this.tableData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableData.Location = new System.Drawing.Point(12, 12);
            this.tableData.Name = "tableData";
            this.tableData.Size = new System.Drawing.Size(441, 288);
            this.tableData.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.catalogComboBox);
            this.groupBox1.Location = new System.Drawing.Point(464, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Каталоги";
            // 
            // catalogComboBox
            // 
            this.catalogComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catalogComboBox.FormattingEnabled = true;
            this.catalogComboBox.Items.AddRange(new object[] {
            "Авторы",
            "Книги"});
            this.catalogComboBox.Location = new System.Drawing.Point(6, 25);
            this.catalogComboBox.Name = "catalogComboBox";
            this.catalogComboBox.Size = new System.Drawing.Size(108, 21);
            this.catalogComboBox.TabIndex = 0;
            this.catalogComboBox.SelectedIndexChanged += new System.EventHandler(this.catalogComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.changeButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Location = new System.Drawing.Point(464, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Действия";
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(6, 88);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(108, 23);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Изменить запись";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 59);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(108, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Удалить запись";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 30);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(108, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить запись";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // changeUserButton
            // 
            this.changeUserButton.Location = new System.Drawing.Point(6, 32);
            this.changeUserButton.Name = "changeUserButton";
            this.changeUserButton.Size = new System.Drawing.Size(108, 23);
            this.changeUserButton.TabIndex = 4;
            this.changeUserButton.Text = "Сменить пользователя";
            this.changeUserButton.UseVisualStyleBackColor = true;
            this.changeUserButton.Click += new System.EventHandler(this.changeUserButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.userLabel);
            this.groupBox4.Controls.Add(this.changeUserButton);
            this.groupBox4.Location = new System.Drawing.Point(464, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 65);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Пользователь";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLabel.Location = new System.Drawing.Point(3, 13);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(112, 15);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Администратор";
            // 
            // oneleft_button
            // 
            this.oneleft_button.Location = new System.Drawing.Point(159, 304);
            this.oneleft_button.Name = "oneleft_button";
            this.oneleft_button.Size = new System.Drawing.Size(36, 23);
            this.oneleft_button.TabIndex = 6;
            this.oneleft_button.Text = "<";
            this.oneleft_button.UseVisualStyleBackColor = true;
            this.oneleft_button.Click += new System.EventHandler(this.oneleft_button_Click);
            // 
            // right_button
            // 
            this.right_button.Location = new System.Drawing.Point(275, 304);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(36, 23);
            this.right_button.TabIndex = 7;
            this.right_button.Text = ">";
            this.right_button.UseVisualStyleBackColor = true;
            this.right_button.Click += new System.EventHandler(this.right_button_Click);
            // 
            // grantleft_button
            // 
            this.grantleft_button.Location = new System.Drawing.Point(117, 304);
            this.grantleft_button.Name = "grantleft_button";
            this.grantleft_button.Size = new System.Drawing.Size(36, 23);
            this.grantleft_button.TabIndex = 8;
            this.grantleft_button.Text = "|<";
            this.grantleft_button.UseVisualStyleBackColor = true;
            this.grantleft_button.Click += new System.EventHandler(this.grantleft_button_Click);
            // 
            // grantright_button
            // 
            this.grantright_button.Location = new System.Drawing.Point(317, 304);
            this.grantright_button.Name = "grantright_button";
            this.grantright_button.Size = new System.Drawing.Size(36, 23);
            this.grantright_button.TabIndex = 9;
            this.grantright_button.Text = ">|";
            this.grantright_button.UseVisualStyleBackColor = true;
            this.grantright_button.Click += new System.EventHandler(this.grantright_button_Click);
            // 
            // page_label
            // 
            this.page_label.AutoSize = true;
            this.page_label.Location = new System.Drawing.Point(201, 309);
            this.page_label.Name = "page_label";
            this.page_label.Size = new System.Drawing.Size(39, 13);
            this.page_label.TabIndex = 10;
            this.page_label.Text = "0/0     ";
            this.page_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 331);
            this.Controls.Add(this.page_label);
            this.Controls.Add(this.grantright_button);
            this.Controls.Add(this.grantleft_button);
            this.Controls.Add(this.right_button);
            this.Controls.Add(this.oneleft_button);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableData);
            this.MaximumSize = new System.Drawing.Size(612, 370);
            this.MinimumSize = new System.Drawing.Size(612, 370);
            this.Name = "workForm";
            this.Text = "Библиотека";
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox catalogComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button changeUserButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button oneleft_button;
        private System.Windows.Forms.Button right_button;
        private System.Windows.Forms.Button grantleft_button;
        private System.Windows.Forms.Button grantright_button;
        private System.Windows.Forms.Label page_label;
    }
}
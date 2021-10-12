namespace AsyncDataBaseAcces
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.sqlTransactionField = new System.Windows.Forms.TextBox();
            this.clean_button = new System.Windows.Forms.Button();
            this.execute_button = new System.Windows.Forms.Button();
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.authors_comboBox = new System.Windows.Forms.ComboBox();
            this.books_count = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.books_count)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql-Transaction:";
            // 
            // sqlTransactionField
            // 
            this.sqlTransactionField.Location = new System.Drawing.Point(18, 50);
            this.sqlTransactionField.Multiline = true;
            this.sqlTransactionField.Name = "sqlTransactionField";
            this.sqlTransactionField.Size = new System.Drawing.Size(609, 97);
            this.sqlTransactionField.TabIndex = 1;
            this.sqlTransactionField.TextChanged += new System.EventHandler(this.sqlTransactionField_TextChanged);
            // 
            // clean_button
            // 
            this.clean_button.Location = new System.Drawing.Point(18, 153);
            this.clean_button.Name = "clean_button";
            this.clean_button.Size = new System.Drawing.Size(103, 43);
            this.clean_button.TabIndex = 2;
            this.clean_button.Text = "Clean";
            this.clean_button.UseVisualStyleBackColor = true;
            // 
            // execute_button
            // 
            this.execute_button.Location = new System.Drawing.Point(524, 153);
            this.execute_button.Name = "execute_button";
            this.execute_button.Size = new System.Drawing.Size(103, 43);
            this.execute_button.TabIndex = 3;
            this.execute_button.Text = "Execute";
            this.execute_button.UseVisualStyleBackColor = true;
            this.execute_button.Click += new System.EventHandler(this.execute_button_Click);
            // 
            // dataViewer
            // 
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Location = new System.Drawing.Point(18, 202);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.Size = new System.Drawing.Size(609, 213);
            this.dataViewer.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // authors_comboBox
            // 
            this.authors_comboBox.FormattingEnabled = true;
            this.authors_comboBox.Location = new System.Drawing.Point(127, 159);
            this.authors_comboBox.Name = "authors_comboBox";
            this.authors_comboBox.Size = new System.Drawing.Size(174, 33);
            this.authors_comboBox.TabIndex = 5;
            this.authors_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // books_count
            // 
            this.books_count.Location = new System.Drawing.Point(398, 159);
            this.books_count.Name = "books_count";
            this.books_count.Size = new System.Drawing.Size(120, 31);
            this.books_count.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 427);
            this.Controls.Add(this.books_count);
            this.Controls.Add(this.authors_comboBox);
            this.Controls.Add(this.dataViewer);
            this.Controls.Add(this.execute_button);
            this.Controls.Add(this.clean_button);
            this.Controls.Add(this.sqlTransactionField);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.books_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sqlTransactionField;
        private System.Windows.Forms.Button clean_button;
        private System.Windows.Forms.Button execute_button;
        private System.Windows.Forms.DataGridView dataViewer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox authors_comboBox;
        private System.Windows.Forms.NumericUpDown books_count;
    }
}


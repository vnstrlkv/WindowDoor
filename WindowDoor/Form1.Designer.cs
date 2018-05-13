namespace WindowDoor
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
            this.button1 = new System.Windows.Forms.Button();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.nameBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkDeaf = new System.Windows.Forms.CheckBox();
            this.checkPipe1 = new System.Windows.Forms.CheckBox();
            this.MaterialBox1 = new System.Windows.Forms.ComboBox();
            this.priceListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.priceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cuttingbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 310);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рассчёт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(391, 88);
            this.widthBox.Margin = new System.Windows.Forms.Padding(2);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(76, 20);
            this.widthBox.TabIndex = 1;
            this.widthBox.TextChanged += new System.EventHandler(this.widthBox_TextChanged);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(500, 26);
            this.heightBox.Margin = new System.Windows.Forms.Padding(2);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(76, 20);
            this.heightBox.TabIndex = 2;
            this.heightBox.TextChanged += new System.EventHandler(this.heightBox_TextChanged);
            // 
            // nameBox1
            // 
            this.nameBox1.Location = new System.Drawing.Point(244, 26);
            this.nameBox1.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox1.Name = "nameBox1";
            this.nameBox1.Size = new System.Drawing.Size(109, 20);
            this.nameBox1.TabIndex = 3;
            this.nameBox1.TextChanged += new System.EventHandler(this.nameBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(391, 64);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(76, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Ширина";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(500, 2);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Высота";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(257, 2);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(76, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Название";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(358, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // checkDeaf
            // 
            this.checkDeaf.AutoSize = true;
            this.checkDeaf.Location = new System.Drawing.Point(13, 195);
            this.checkDeaf.Name = "checkDeaf";
            this.checkDeaf.Size = new System.Drawing.Size(60, 17);
            this.checkDeaf.TabIndex = 8;
            this.checkDeaf.Text = "Глухое";
            this.checkDeaf.UseVisualStyleBackColor = true;
            this.checkDeaf.CheckedChanged += new System.EventHandler(this.checkDeaf_CheckedChanged);
            // 
            // checkPipe1
            // 
            this.checkPipe1.AutoSize = true;
            this.checkPipe1.Location = new System.Drawing.Point(13, 219);
            this.checkPipe1.Name = "checkPipe1";
            this.checkPipe1.Size = new System.Drawing.Size(56, 17);
            this.checkPipe1.TabIndex = 9;
            this.checkPipe1.Text = "Труба";
            this.checkPipe1.UseVisualStyleBackColor = true;
            // 
            // MaterialBox1
            // 
            this.MaterialBox1.FormattingEnabled = true;
            this.MaterialBox1.Items.AddRange(new object[] {
            "ПВХ  пленка прозрачка 200мкм, ширина 1,4м + Тент цветной 620",
            "ПВХ  пленка прозрачка 500мкм ширина 1,4м + Тент цветной 650 ",
            "ПВХ  пленка прозрачка 750мкм ширина 1,4м +Тент цветной 650",
            "ПВХ  пленка прозрачка 500мкм ширина 1,4м",
            "Прозрачная пленка ПВХ 700 МКМ",
            "Сетка баннерная 340 гр белая + печать с одной стороны",
            "Ткань тентовая 650 (если делать без прозрачного - тент)",
            " Ткань тентовая 650+ полоска прозрачная 1,4 (горизонтально)"});
            this.MaterialBox1.Location = new System.Drawing.Point(12, 135);
            this.MaterialBox1.Name = "MaterialBox1";
            this.MaterialBox1.Size = new System.Drawing.Size(586, 21);
            this.MaterialBox1.TabIndex = 10;
            this.MaterialBox1.SelectedIndexChanged += new System.EventHandler(this.MaterialBox1_SelectedIndexChanged);
            // 
            // priceListBindingSource1
            // 
            this.priceListBindingSource1.DataSource = typeof(Prices.PriceList);
            // 
            // priceListBindingSource
            // 
            this.priceListBindingSource.DataSource = typeof(Prices.PriceList);
            // 
            // cuttingbox
            // 
            this.cuttingbox.AutoSize = true;
            this.cuttingbox.Location = new System.Drawing.Point(12, 243);
            this.cuttingbox.Name = "cuttingbox";
            this.cuttingbox.Size = new System.Drawing.Size(110, 17);
            this.cuttingbox.TabIndex = 11;
            this.cuttingbox.Text = "Поперечный рез";
            this.cuttingbox.UseVisualStyleBackColor = true;
            this.cuttingbox.CheckedChanged += new System.EventHandler(this.cuttingbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cuttingbox);
            this.Controls.Add(this.MaterialBox1);
            this.Controls.Add(this.checkPipe1);
            this.Controls.Add(this.checkDeaf);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.nameBox1);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox nameBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkDeaf;
        private System.Windows.Forms.CheckBox checkPipe1;
        private System.Windows.Forms.ComboBox MaterialBox1;
        private System.Windows.Forms.BindingSource priceListBindingSource;
        private System.Windows.Forms.BindingSource priceListBindingSource1;
        private System.Windows.Forms.CheckBox cuttingbox;
    }
}


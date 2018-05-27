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
            this.checkDeaf = new System.Windows.Forms.CheckBox();
            this.checkPipe1 = new System.Windows.Forms.CheckBox();
            this.MaterialBox1 = new System.Windows.Forms.ComboBox();
            this.cuttingbox = new System.Windows.Forms.CheckBox();
            this.paintPipe = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nameBox2 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.openWindow = new System.Windows.Forms.CheckBox();
            this.fullOpenWindow = new System.Windows.Forms.CheckBox();
            this.delivery = new System.Windows.Forms.TextBox();
            this.installWindow = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.metering = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.phoneNumber1 = new System.Windows.Forms.TextBox();
            this.saveClient = new System.Windows.Forms.Button();
            this.priceListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.priceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BDbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 411);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 101);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рассчёт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(420, 26);
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
            this.nameBox1.Location = new System.Drawing.Point(91, 11);
            this.nameBox1.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox1.Name = "nameBox1";
            this.nameBox1.Size = new System.Drawing.Size(236, 20);
            this.nameBox1.TabIndex = 3;
            this.nameBox1.TextChanged += new System.EventHandler(this.nameBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(420, 2);
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
            this.textBox4.Location = new System.Drawing.Point(11, 11);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(76, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Фамилия";
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
            this.checkPipe1.Location = new System.Drawing.Point(79, 220);
            this.checkPipe1.Name = "checkPipe1";
            this.checkPipe1.Size = new System.Drawing.Size(56, 17);
            this.checkPipe1.TabIndex = 9;
            this.checkPipe1.Text = "Труба";
            this.checkPipe1.UseVisualStyleBackColor = true;
            this.checkPipe1.CheckedChanged += new System.EventHandler(this.checkPipe1_CheckedChanged);
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
            // cuttingbox
            // 
            this.cuttingbox.AutoSize = true;
            this.cuttingbox.Location = new System.Drawing.Point(11, 337);
            this.cuttingbox.Name = "cuttingbox";
            this.cuttingbox.Size = new System.Drawing.Size(110, 17);
            this.cuttingbox.TabIndex = 11;
            this.cuttingbox.Text = "Поперечный рез";
            this.cuttingbox.UseVisualStyleBackColor = true;
            this.cuttingbox.CheckedChanged += new System.EventHandler(this.cuttingbox_CheckedChanged);
            // 
            // paintPipe
            // 
            this.paintPipe.AutoSize = true;
            this.paintPipe.Location = new System.Drawing.Point(79, 243);
            this.paintPipe.Name = "paintPipe";
            this.paintPipe.Size = new System.Drawing.Size(87, 17);
            this.paintPipe.TabIndex = 12;
            this.paintPipe.Text = "Грунт трубы";
            this.paintPipe.UseVisualStyleBackColor = true;
            this.paintPipe.CheckedChanged += new System.EventHandler(this.paintPipe_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 35);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Имя";
            // 
            // nameBox2
            // 
            this.nameBox2.Location = new System.Drawing.Point(91, 35);
            this.nameBox2.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox2.Name = "nameBox2";
            this.nameBox2.Size = new System.Drawing.Size(236, 20);
            this.nameBox2.TabIndex = 3;
            this.nameBox2.TextChanged += new System.EventHandler(this.nameBox1_TextChanged);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(284, 110);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(69, 20);
            this.textBox8.TabIndex = 4;
            this.textBox8.Text = "Материал";
            // 
            // openWindow
            // 
            this.openWindow.AutoSize = true;
            this.openWindow.Location = new System.Drawing.Point(79, 195);
            this.openWindow.Name = "openWindow";
            this.openWindow.Size = new System.Drawing.Size(112, 17);
            this.openWindow.TabIndex = 13;
            this.openWindow.Text = "Открывающееся";
            this.openWindow.UseVisualStyleBackColor = true;
            this.openWindow.CheckedChanged += new System.EventHandler(this.openWindow_CheckedChanged);
            // 
            // fullOpenWindow
            // 
            this.fullOpenWindow.AutoSize = true;
            this.fullOpenWindow.Location = new System.Drawing.Point(198, 195);
            this.fullOpenWindow.Name = "fullOpenWindow";
            this.fullOpenWindow.Size = new System.Drawing.Size(170, 17);
            this.fullOpenWindow.TabIndex = 14;
            this.fullOpenWindow.Text = "Полностью открывающееся";
            this.fullOpenWindow.UseVisualStyleBackColor = true;
            this.fullOpenWindow.CheckedChanged += new System.EventHandler(this.fullOpenWindow_CheckedChanged);
            // 
            // delivery
            // 
            this.delivery.Location = new System.Drawing.Point(456, 243);
            this.delivery.Name = "delivery";
            this.delivery.Size = new System.Drawing.Size(100, 20);
            this.delivery.TabIndex = 15;
            this.delivery.Text = "0";
            // 
            // installWindow
            // 
            this.installWindow.Location = new System.Drawing.Point(456, 269);
            this.installWindow.Name = "installWindow";
            this.installWindow.Size = new System.Drawing.Size(100, 20);
            this.installWindow.TabIndex = 15;
            this.installWindow.Text = "0";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(375, 243);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(76, 20);
            this.textBox9.TabIndex = 4;
            this.textBox9.Text = "Доставка";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(375, 267);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(76, 20);
            this.textBox10.TabIndex = 4;
            this.textBox10.Text = "Монтаж";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(375, 316);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(76, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "Замер";
            // 
            // metering
            // 
            this.metering.Location = new System.Drawing.Point(456, 318);
            this.metering.Name = "metering";
            this.metering.Size = new System.Drawing.Size(100, 20);
            this.metering.TabIndex = 15;
            this.metering.Text = "0";
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(91, 59);
            this.phoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(236, 20);
            this.phoneNumber.TabIndex = 3;
            this.phoneNumber.TextChanged += new System.EventHandler(this.nameBox1_TextChanged);
            // 
            // phoneNumber1
            // 
            this.phoneNumber1.Location = new System.Drawing.Point(11, 59);
            this.phoneNumber1.Margin = new System.Windows.Forms.Padding(2);
            this.phoneNumber1.Name = "phoneNumber1";
            this.phoneNumber1.ReadOnly = true;
            this.phoneNumber1.Size = new System.Drawing.Size(76, 20);
            this.phoneNumber1.TabIndex = 6;
            this.phoneNumber1.Text = "Телефон";
            // 
            // saveClient
            // 
            this.saveClient.Location = new System.Drawing.Point(11, 411);
            this.saveClient.Name = "saveClient";
            this.saveClient.Size = new System.Drawing.Size(124, 100);
            this.saveClient.TabIndex = 16;
            this.saveClient.Text = "Сохранить клиента";
            this.saveClient.UseVisualStyleBackColor = true;
            this.saveClient.Click += new System.EventHandler(this.saveClient_Click);
            // 
            // priceListBindingSource1
            // 
            this.priceListBindingSource1.DataSource = typeof(Prices.PriceList);
            // 
            // priceListBindingSource
            // 
            this.priceListBindingSource.DataSource = typeof(Prices.PriceList);
            // 
            // BDbutton
            // 
            this.BDbutton.Location = new System.Drawing.Point(257, 489);
            this.BDbutton.Name = "BDbutton";
            this.BDbutton.Size = new System.Drawing.Size(96, 33);
            this.BDbutton.TabIndex = 17;
            this.BDbutton.Text = "База клиентов";
            this.BDbutton.UseVisualStyleBackColor = true;
            this.BDbutton.Click += new System.EventHandler(this.BDbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 523);
            this.Controls.Add(this.BDbutton);
            this.Controls.Add(this.saveClient);
            this.Controls.Add(this.metering);
            this.Controls.Add(this.installWindow);
            this.Controls.Add(this.delivery);
            this.Controls.Add(this.fullOpenWindow);
            this.Controls.Add(this.openWindow);
            this.Controls.Add(this.paintPipe);
            this.Controls.Add(this.cuttingbox);
            this.Controls.Add(this.MaterialBox1);
            this.Controls.Add(this.checkPipe1);
            this.Controls.Add(this.checkDeaf);
            this.Controls.Add(this.phoneNumber1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.nameBox2);
            this.Controls.Add(this.nameBox1);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.CheckBox checkDeaf;
        private System.Windows.Forms.CheckBox checkPipe1;
        private System.Windows.Forms.ComboBox MaterialBox1;
        private System.Windows.Forms.BindingSource priceListBindingSource;
        private System.Windows.Forms.BindingSource priceListBindingSource1;
        private System.Windows.Forms.CheckBox cuttingbox;
        private System.Windows.Forms.CheckBox paintPipe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox nameBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.CheckBox openWindow;
        private System.Windows.Forms.CheckBox fullOpenWindow;
        private System.Windows.Forms.TextBox delivery;
        private System.Windows.Forms.TextBox installWindow;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox metering;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.TextBox phoneNumber1;
        private System.Windows.Forms.Button saveClient;
        private System.Windows.Forms.Button BDbutton;
    }
}


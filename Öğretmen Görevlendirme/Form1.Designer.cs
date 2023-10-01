namespace Öğretmen_Görevlendirme
{
    partial class Form1
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
            this.distributeBtn = new System.Windows.Forms.Button();
            this.bolgeBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ogretmenBtn = new System.Windows.Forms.Button();
            this.bolgelerCombo = new System.Windows.Forms.ComboBox();
            this.bransCombo = new System.Windows.Forms.ComboBox();
            this.ihtiyacBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.bolgelerList = new System.Windows.Forms.ListBox();
            this.secilenbolgelerList = new System.Windows.Forms.ListBox();
            this.bolgesecBtn = new System.Windows.Forms.Button();
            this.bolgesilBtn = new System.Windows.Forms.Button();
            this.raporBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // distributeBtn
            // 
            this.distributeBtn.Enabled = false;
            this.distributeBtn.Location = new System.Drawing.Point(373, 28);
            this.distributeBtn.Name = "distributeBtn";
            this.distributeBtn.Size = new System.Drawing.Size(112, 79);
            this.distributeBtn.TabIndex = 0;
            this.distributeBtn.Text = "Dağıt";
            this.distributeBtn.UseVisualStyleBackColor = true;
            this.distributeBtn.Visible = false;
            this.distributeBtn.Click += new System.EventHandler(this.distributeBtn_Click);
            // 
            // bolgeBtn
            // 
            this.bolgeBtn.Location = new System.Drawing.Point(12, 28);
            this.bolgeBtn.Name = "bolgeBtn";
            this.bolgeBtn.Size = new System.Drawing.Size(221, 23);
            this.bolgeBtn.TabIndex = 1;
            this.bolgeBtn.Text = "Bölgeler Dosyası";
            this.bolgeBtn.UseVisualStyleBackColor = true;
            this.bolgeBtn.Click += new System.EventHandler(this.bolgeBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "xlsx dosyaları (*.xlsx)|*.xlsx|xls dosyaları (*.xls)|*.xls";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 481);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1039, 97);
            this.textBox1.TabIndex = 2;
            // 
            // ogretmenBtn
            // 
            this.ogretmenBtn.Enabled = false;
            this.ogretmenBtn.Location = new System.Drawing.Point(12, 57);
            this.ogretmenBtn.Name = "ogretmenBtn";
            this.ogretmenBtn.Size = new System.Drawing.Size(221, 23);
            this.ogretmenBtn.TabIndex = 3;
            this.ogretmenBtn.Text = "Öğretmen Listesi";
            this.ogretmenBtn.UseVisualStyleBackColor = true;
            this.ogretmenBtn.Visible = false;
            this.ogretmenBtn.Click += new System.EventHandler(this.ogretmenBtn_Click);
            // 
            // bolgelerCombo
            // 
            this.bolgelerCombo.Enabled = false;
            this.bolgelerCombo.FormattingEnabled = true;
            this.bolgelerCombo.Location = new System.Drawing.Point(12, 124);
            this.bolgelerCombo.Name = "bolgelerCombo";
            this.bolgelerCombo.Size = new System.Drawing.Size(325, 23);
            this.bolgelerCombo.TabIndex = 4;
            this.bolgelerCombo.Text = "Eğitim Bölgeleri";
            this.bolgelerCombo.Visible = false;
            this.bolgelerCombo.SelectedIndexChanged += new System.EventHandler(this.bolgelerCombo_SelectedIndexChanged);
            // 
            // bransCombo
            // 
            this.bransCombo.Enabled = false;
            this.bransCombo.FormattingEnabled = true;
            this.bransCombo.Location = new System.Drawing.Point(12, 164);
            this.bransCombo.Name = "bransCombo";
            this.bransCombo.Size = new System.Drawing.Size(643, 23);
            this.bransCombo.TabIndex = 5;
            this.bransCombo.Text = "Brans";
            this.bransCombo.Visible = false;
            this.bransCombo.SelectedIndexChanged += new System.EventHandler(this.bransCombo_SelectedIndexChanged);
            // 
            // ihtiyacBtn
            // 
            this.ihtiyacBtn.Enabled = false;
            this.ihtiyacBtn.Location = new System.Drawing.Point(12, 84);
            this.ihtiyacBtn.Name = "ihtiyacBtn";
            this.ihtiyacBtn.Size = new System.Drawing.Size(221, 23);
            this.ihtiyacBtn.TabIndex = 6;
            this.ihtiyacBtn.Text = "İhtiyaç Listesi";
            this.ihtiyacBtn.UseVisualStyleBackColor = true;
            this.ihtiyacBtn.Visible = false;
            this.ihtiyacBtn.Click += new System.EventHandler(this.ihtiyacBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(962, 28);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(89, 22);
            this.resetBtn.TabIndex = 7;
            this.resetBtn.Text = "Sıfırla";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // bolgelerList
            // 
            this.bolgelerList.Enabled = false;
            this.bolgelerList.FormattingEnabled = true;
            this.bolgelerList.ItemHeight = 15;
            this.bolgelerList.Location = new System.Drawing.Point(12, 209);
            this.bolgelerList.Name = "bolgelerList";
            this.bolgelerList.Size = new System.Drawing.Size(221, 229);
            this.bolgelerList.TabIndex = 9;
            this.bolgelerList.Visible = false;
            // 
            // secilenbolgelerList
            // 
            this.secilenbolgelerList.Enabled = false;
            this.secilenbolgelerList.FormattingEnabled = true;
            this.secilenbolgelerList.ItemHeight = 15;
            this.secilenbolgelerList.Location = new System.Drawing.Point(396, 209);
            this.secilenbolgelerList.Name = "secilenbolgelerList";
            this.secilenbolgelerList.Size = new System.Drawing.Size(221, 229);
            this.secilenbolgelerList.TabIndex = 10;
            this.secilenbolgelerList.Visible = false;
            // 
            // bolgesecBtn
            // 
            this.bolgesecBtn.Enabled = false;
            this.bolgesecBtn.Location = new System.Drawing.Point(262, 276);
            this.bolgesecBtn.Name = "bolgesecBtn";
            this.bolgesecBtn.Size = new System.Drawing.Size(75, 23);
            this.bolgesecBtn.TabIndex = 11;
            this.bolgesecBtn.Text = "==>";
            this.bolgesecBtn.UseVisualStyleBackColor = true;
            this.bolgesecBtn.Visible = false;
            this.bolgesecBtn.Click += new System.EventHandler(this.bolgesecBtn_Click);
            // 
            // bolgesilBtn
            // 
            this.bolgesilBtn.Enabled = false;
            this.bolgesilBtn.Location = new System.Drawing.Point(262, 322);
            this.bolgesilBtn.Name = "bolgesilBtn";
            this.bolgesilBtn.Size = new System.Drawing.Size(75, 23);
            this.bolgesilBtn.TabIndex = 12;
            this.bolgesilBtn.Text = "<==";
            this.bolgesilBtn.UseVisualStyleBackColor = true;
            this.bolgesilBtn.Visible = false;
            this.bolgesilBtn.Click += new System.EventHandler(this.bolgesilBtn_Click);
            // 
            // raporBtn
            // 
            this.raporBtn.Enabled = false;
            this.raporBtn.Location = new System.Drawing.Point(517, 28);
            this.raporBtn.Name = "raporBtn";
            this.raporBtn.Size = new System.Drawing.Size(118, 79);
            this.raporBtn.TabIndex = 8;
            this.raporBtn.Text = "Raporla";
            this.raporBtn.UseVisualStyleBackColor = true;
            this.raporBtn.Visible = false;
            this.raporBtn.Click += new System.EventHandler(this.raporBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 599);
            this.Controls.Add(this.bolgesilBtn);
            this.Controls.Add(this.bolgesecBtn);
            this.Controls.Add(this.secilenbolgelerList);
            this.Controls.Add(this.bolgelerList);
            this.Controls.Add(this.raporBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.ihtiyacBtn);
            this.Controls.Add(this.bransCombo);
            this.Controls.Add(this.bolgelerCombo);
            this.Controls.Add(this.ogretmenBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bolgeBtn);
            this.Controls.Add(this.distributeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button distributeBtn;
        private Button bolgeBtn;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private Button ogretmenBtn;
        private ComboBox bolgelerCombo;
        private Button ihtiyacBtn;
        private Button resetBtn;
        private ComboBox bransCombo;
        private ListBox bolgelerList;
        private ListBox secilenbolgelerList;
        private Button bolgesecBtn;
        private Button bolgesilBtn;
        private Button raporBtn;
    }
}
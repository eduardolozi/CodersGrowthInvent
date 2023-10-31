namespace CrudWinFormsBancoMemoria
{
    partial class CadastroPokemon
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            checkBox1 = new CheckBox();
            cboTipoPrincipal = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            cboTipoSecundario = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 54);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(33, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(210, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 127);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 2;
            label2.Text = "Apelido";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(33, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(210, 27);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 210);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 4;
            label3.Text = "Nível";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(33, 314);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(210, 27);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 291);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Altura";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(33, 621);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Shiny";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cboTipoPrincipal
            // 
            cboTipoPrincipal.FormattingEnabled = true;
            cboTipoPrincipal.Location = new Point(33, 482);
            cboTipoPrincipal.Name = "cboTipoPrincipal";
            cboTipoPrincipal.Size = new Size(210, 28);
            cboTipoPrincipal.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 459);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 10;
            label5.Text = "Tipo Principal";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 540);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 12;
            label6.Text = "Tipo Principal";
            // 
            // cboTipoSecundario
            // 
            cboTipoSecundario.FormattingEnabled = true;
            cboTipoSecundario.Location = new Point(33, 563);
            cboTipoSecundario.Name = "cboTipoSecundario";
            cboTipoSecundario.Size = new Size(210, 28);
            cboTipoSecundario.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(33, 400);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(210, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 377);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 14;
            label7.Text = "Data de captura";
            // 
            // button1
            // 
            button1.Location = new Point(372, 665);
            button1.Name = "button1";
            button1.Size = new Size(94, 35);
            button1.TabIndex = 15;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CadastroPokemon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 712);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(cboTipoSecundario);
            Controls.Add(label5);
            Controls.Add(cboTipoPrincipal);
            Controls.Add(checkBox1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "CadastroPokemon";
            Text = "Cadastro de Pokemon";
            Load += CadastroPokemon_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private CheckBox checkBox1;
        private ComboBox cboTipoPrincipal;
        private Label label5;
        private Label label6;
        private ComboBox cboTipoSecundario;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private Button button1;
    }
}
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtNome = new TextBox();
            txtApelido = new TextBox();
            label2 = new Label();
            txtNivel = new TextBox();
            label3 = new Label();
            txtAltura = new TextBox();
            label4 = new Label();
            checkBoxShiny = new CheckBox();
            comboBoxTipoPrincipal = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            comboBoxTipoSecundario = new ComboBox();
            dataPickerCaptura = new DateTimePicker();
            label7 = new Label();
            botaoAdicionar = new Button();
            botaoCancelar = new Button();
            fotoPokemon = new PictureBox();
            botaoImagem = new Button();
            txtFoto = new TextBox();
            erroNoCampo = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erroNoCampo).BeginInit();
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
            // txtNome
            // 
            txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNome.Location = new Point(33, 77);
            txtNome.MaxLength = 11;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(322, 27);
            txtNome.TabIndex = 1;
            txtNome.KeyPress += AoApertarTeclaNoTxtNome;
            // 
            // txtApelido
            // 
            txtApelido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtApelido.Location = new Point(33, 150);
            txtApelido.MaxLength = 20;
            txtApelido.Name = "txtApelido";
            txtApelido.Size = new Size(322, 27);
            txtApelido.TabIndex = 3;
            txtApelido.KeyPress += AoApertarTeclaNoTxtApelido;
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
            // txtNivel
            // 
            txtNivel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNivel.Location = new Point(33, 233);
            txtNivel.MaxLength = 3;
            txtNivel.Name = "txtNivel";
            txtNivel.Size = new Size(322, 27);
            txtNivel.TabIndex = 5;
            txtNivel.KeyPress += AoApertarTeclaNoTxtNivel;
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
            // txtAltura
            // 
            txtAltura.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAltura.Location = new Point(33, 314);
            txtAltura.MaxLength = 4;
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(322, 27);
            txtAltura.TabIndex = 7;
            txtAltura.KeyPress += AoApertarTeclaNoTxtAltura;
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
            // checkBoxShiny
            // 
            checkBoxShiny.AutoSize = true;
            checkBoxShiny.Location = new Point(33, 621);
            checkBoxShiny.Name = "checkBoxShiny";
            checkBoxShiny.Size = new Size(66, 24);
            checkBoxShiny.TabIndex = 8;
            checkBoxShiny.Text = "Shiny";
            checkBoxShiny.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipoPrincipal
            // 
            comboBoxTipoPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxTipoPrincipal.FormattingEnabled = true;
            comboBoxTipoPrincipal.Location = new Point(33, 482);
            comboBoxTipoPrincipal.Name = "comboBoxTipoPrincipal";
            comboBoxTipoPrincipal.Size = new Size(322, 28);
            comboBoxTipoPrincipal.TabIndex = 9;
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
            label6.Size = new Size(117, 20);
            label6.TabIndex = 12;
            label6.Text = "Tipo Secundário";
            // 
            // comboBoxTipoSecundario
            // 
            comboBoxTipoSecundario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxTipoSecundario.FormattingEnabled = true;
            comboBoxTipoSecundario.Location = new Point(33, 563);
            comboBoxTipoSecundario.Name = "comboBoxTipoSecundario";
            comboBoxTipoSecundario.Size = new Size(322, 28);
            comboBoxTipoSecundario.TabIndex = 11;
            // 
            // dataPickerCaptura
            // 
            dataPickerCaptura.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataPickerCaptura.Location = new Point(33, 400);
            dataPickerCaptura.Name = "dataPickerCaptura";
            dataPickerCaptura.Size = new Size(322, 27);
            dataPickerCaptura.TabIndex = 13;
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
            // botaoAdicionar
            // 
            botaoAdicionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            botaoAdicionar.Location = new Point(33, 665);
            botaoAdicionar.Name = "botaoAdicionar";
            botaoAdicionar.Size = new Size(170, 35);
            botaoAdicionar.TabIndex = 15;
            botaoAdicionar.Text = "Adicionar Pokemon";
            botaoAdicionar.UseVisualStyleBackColor = true;
            botaoAdicionar.Click += AoClicarBotaoAdicionar;
            // 
            // botaoCancelar
            // 
            botaoCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            botaoCancelar.Location = new Point(770, 665);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(104, 35);
            botaoCancelar.TabIndex = 16;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = true;
            botaoCancelar.Click += AoClicarBotaoCancelar;
            // 
            // fotoPokemon
            // 
            fotoPokemon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fotoPokemon.Location = new Point(411, 54);
            fotoPokemon.Name = "fotoPokemon";
            fotoPokemon.Size = new Size(478, 372);
            fotoPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            fotoPokemon.TabIndex = 17;
            fotoPokemon.TabStop = false;
            // 
            // botaoImagem
            // 
            botaoImagem.Anchor = AnchorStyles.Right;
            botaoImagem.Location = new Point(411, 467);
            botaoImagem.Name = "botaoImagem";
            botaoImagem.Size = new Size(145, 29);
            botaoImagem.TabIndex = 18;
            botaoImagem.Text = "Buscar imagem";
            botaoImagem.UseVisualStyleBackColor = true;
            botaoImagem.Click += AoClicarNoBotaoBuscarImagem;
            // 
            // txtFoto
            // 
            txtFoto.Anchor = AnchorStyles.Right;
            txtFoto.Location = new Point(411, 432);
            txtFoto.Name = "txtFoto";
            txtFoto.Size = new Size(478, 27);
            txtFoto.TabIndex = 19;
            // 
            // erroNoCampo
            // 
            erroNoCampo.ContainerControl = this;
            // 
            // CadastroPokemon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 712);
            Controls.Add(txtFoto);
            Controls.Add(botaoImagem);
            Controls.Add(fotoPokemon);
            Controls.Add(botaoCancelar);
            Controls.Add(botaoAdicionar);
            Controls.Add(label7);
            Controls.Add(dataPickerCaptura);
            Controls.Add(label6);
            Controls.Add(comboBoxTipoSecundario);
            Controls.Add(label5);
            Controls.Add(comboBoxTipoPrincipal);
            Controls.Add(checkBoxShiny);
            Controls.Add(txtAltura);
            Controls.Add(label4);
            Controls.Add(txtNivel);
            Controls.Add(label3);
            Controls.Add(txtApelido);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "CadastroPokemon";
            Text = "Cadastro de Pokemon";
            Load += CadastroPokemon_Load;
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).EndInit();
            ((System.ComponentModel.ISupportInitialize)erroNoCampo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private TextBox txtApelido;
        private Label label2;
        private TextBox txtNivel;
        private Label label3;
        private TextBox txtAltura;
        private Label label4;
        private CheckBox checkBoxShiny;
        private ComboBox comboBoxTipoPrincipal;
        private Label label5;
        private Label label6;
        private ComboBox comboBoxTipoSecundario;
        private DateTimePicker dataPickerCaptura;
        private Label label7;
        private Button botaoAdicionar;
        private Button botaoCancelar;
        private PictureBox fotoPokemon;
        private Button botaoImagem;
        private TextBox txtFoto;
        private ErrorProvider erroNoCampo;
    }
}
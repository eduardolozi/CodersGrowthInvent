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
            cbShiny = new CheckBox();
            cboTipoPrincipal = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            cboTipoSecundario = new ComboBox();
            dtpCaptura = new DateTimePicker();
            label7 = new Label();
            botaoAdicionar = new Button();
            botaoCancelar = new Button();
            nomeErrorProvider = new ErrorProvider(components);
            apelidoErrorProvider = new ErrorProvider(components);
            nivelErrorProvider = new ErrorProvider(components);
            alturaErrorProvider = new ErrorProvider(components);
            dataErrorProvider = new ErrorProvider(components);
            fotoPokemon = new PictureBox();
            botaoImagem = new Button();
            txtFoto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nomeErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apelidoErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nivelErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alturaErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).BeginInit();
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
            // cbShiny
            // 
            cbShiny.AutoSize = true;
            cbShiny.Location = new Point(33, 621);
            cbShiny.Name = "cbShiny";
            cbShiny.Size = new Size(66, 24);
            cbShiny.TabIndex = 8;
            cbShiny.Text = "Shiny";
            cbShiny.UseVisualStyleBackColor = true;
            // 
            // cboTipoPrincipal
            // 
            cboTipoPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboTipoPrincipal.FormattingEnabled = true;
            cboTipoPrincipal.Location = new Point(33, 482);
            cboTipoPrincipal.Name = "cboTipoPrincipal";
            cboTipoPrincipal.Size = new Size(322, 28);
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
            label6.Size = new Size(117, 20);
            label6.TabIndex = 12;
            label6.Text = "Tipo Secundário";
            // 
            // cboTipoSecundario
            // 
            cboTipoSecundario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboTipoSecundario.FormattingEnabled = true;
            cboTipoSecundario.Location = new Point(33, 563);
            cboTipoSecundario.Name = "cboTipoSecundario";
            cboTipoSecundario.Size = new Size(322, 28);
            cboTipoSecundario.TabIndex = 11;
            // 
            // dtpCaptura
            // 
            dtpCaptura.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpCaptura.Location = new Point(33, 400);
            dtpCaptura.Name = "dtpCaptura";
            dtpCaptura.Size = new Size(322, 27);
            dtpCaptura.TabIndex = 13;
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
            botaoAdicionar.Click += aoClicarBotaoAdicionar;
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
            botaoCancelar.Click += aoClicarBotaoCancelar;
            // 
            // nomeErrorProvider
            // 
            nomeErrorProvider.ContainerControl = this;
            // 
            // apelidoErrorProvider
            // 
            apelidoErrorProvider.ContainerControl = this;
            // 
            // nivelErrorProvider
            // 
            nivelErrorProvider.ContainerControl = this;
            // 
            // alturaErrorProvider
            // 
            alturaErrorProvider.ContainerControl = this;
            // 
            // dataErrorProvider
            // 
            dataErrorProvider.ContainerControl = this;
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
            Controls.Add(dtpCaptura);
            Controls.Add(label6);
            Controls.Add(cboTipoSecundario);
            Controls.Add(label5);
            Controls.Add(cboTipoPrincipal);
            Controls.Add(cbShiny);
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
            ((System.ComponentModel.ISupportInitialize)nomeErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)apelidoErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)nivelErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)alturaErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).EndInit();
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
        private CheckBox cbShiny;
        private ComboBox cboTipoPrincipal;
        private Label label5;
        private Label label6;
        private ComboBox cboTipoSecundario;
        private DateTimePicker dtpCaptura;
        private Label label7;
        private Button botaoAdicionar;
        private Button botaoCancelar;
        private ErrorProvider nomeErrorProvider;
        private ErrorProvider apelidoErrorProvider;
        private ErrorProvider nivelErrorProvider;
        private ErrorProvider alturaErrorProvider;
        private ErrorProvider dataErrorProvider;
        private PictureBox fotoPokemon;
        private Button botaoImagem;
        private TextBox txtFoto;
    }
}
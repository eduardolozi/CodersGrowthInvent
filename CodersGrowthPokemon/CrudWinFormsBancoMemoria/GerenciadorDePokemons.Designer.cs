﻿namespace CrudWinFormsBancoMemoria
{
    partial class GerenciadorDePokemons
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerenciadorDePokemons));
            pokemonDataGriedView = new DataGridView();
            pokemonBindingSource = new BindingSource(components);
            label1 = new Label();
            btnCriar = new Button();
            btnEditar = new Button();
            btnApagar = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apelidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nivelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shinyDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataDeCapturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipoPrincipalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipoSecundarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fotoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pokemonDataGriedView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pokemonBindingSource).BeginInit();
            SuspendLayout();
            // 
            // pokemonDataGriedView
            // 
            pokemonDataGriedView.AllowUserToAddRows = false;
            pokemonDataGriedView.AllowUserToDeleteRows = false;
            pokemonDataGriedView.AutoGenerateColumns = false;
            pokemonDataGriedView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pokemonDataGriedView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pokemonDataGriedView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, apelidoDataGridViewTextBoxColumn, nivelDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, shinyDataGridViewCheckBoxColumn, dataDeCapturaDataGridViewTextBoxColumn, tipoPrincipalDataGridViewTextBoxColumn, tipoSecundarioDataGridViewTextBoxColumn, fotoDataGridViewTextBoxColumn });
            pokemonDataGriedView.DataSource = pokemonBindingSource;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            pokemonDataGriedView.DefaultCellStyle = dataGridViewCellStyle1;
            pokemonDataGriedView.Location = new Point(32, 72);
            pokemonDataGriedView.Margin = new Padding(3, 2, 3, 2);
            pokemonDataGriedView.Name = "pokemonDataGriedView";
            pokemonDataGriedView.ReadOnly = true;
            pokemonDataGriedView.RowHeadersWidth = 51;
            pokemonDataGriedView.RowTemplate.Height = 29;
            pokemonDataGriedView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pokemonDataGriedView.Size = new Size(1103, 424);
            pokemonDataGriedView.TabIndex = 0;
            pokemonDataGriedView.CellDoubleClick += AoClicarDuasVezesNaCelulaDeFoto;
            pokemonDataGriedView.CellFormatting += FormatandoAsCedulasDeFoto;
            // 
            // pokemonBindingSource
            // 
            pokemonBindingSource.DataSource = typeof(Models.Pokemon);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(439, 19);
            label1.Name = "label1";
            label1.Size = new Size(287, 37);
            label1.TabIndex = 1;
            label1.Text = "LISTA DE POKEMONS";
            // 
            // btnCriar
            // 
            btnCriar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCriar.Location = new Point(859, 500);
            btnCriar.Margin = new Padding(3, 2, 3, 2);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(82, 22);
            btnCriar.TabIndex = 2;
            btnCriar.Text = "Criar";
            btnCriar.UseVisualStyleBackColor = true;
            btnCriar.Click += AoClicarNoBotaoAdicionar;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.Location = new Point(958, 500);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(82, 22);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += AoClicarNoBotaoEditar;
            // 
            // btnApagar
            // 
            btnApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApagar.Location = new Point(1054, 500);
            btnApagar.Margin = new Padding(3, 2, 3, 2);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(82, 22);
            btnApagar.TabIndex = 4;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += AoClicarBotaoApagar;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apelidoDataGridViewTextBoxColumn
            // 
            apelidoDataGridViewTextBoxColumn.DataPropertyName = "Apelido";
            apelidoDataGridViewTextBoxColumn.HeaderText = "Apelido";
            apelidoDataGridViewTextBoxColumn.Name = "apelidoDataGridViewTextBoxColumn";
            apelidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nivelDataGridViewTextBoxColumn
            // 
            nivelDataGridViewTextBoxColumn.DataPropertyName = "Nivel";
            nivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            nivelDataGridViewTextBoxColumn.Name = "nivelDataGridViewTextBoxColumn";
            nivelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            alturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shinyDataGridViewCheckBoxColumn
            // 
            shinyDataGridViewCheckBoxColumn.DataPropertyName = "Shiny";
            shinyDataGridViewCheckBoxColumn.HeaderText = "Shiny";
            shinyDataGridViewCheckBoxColumn.Name = "shinyDataGridViewCheckBoxColumn";
            shinyDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dataDeCapturaDataGridViewTextBoxColumn
            // 
            dataDeCapturaDataGridViewTextBoxColumn.DataPropertyName = "DataDeCaptura";
            dataDeCapturaDataGridViewTextBoxColumn.HeaderText = "DataDeCaptura";
            dataDeCapturaDataGridViewTextBoxColumn.Name = "dataDeCapturaDataGridViewTextBoxColumn";
            dataDeCapturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoPrincipalDataGridViewTextBoxColumn
            // 
            tipoPrincipalDataGridViewTextBoxColumn.DataPropertyName = "TipoPrincipal";
            tipoPrincipalDataGridViewTextBoxColumn.HeaderText = "TipoPrincipal";
            tipoPrincipalDataGridViewTextBoxColumn.Name = "tipoPrincipalDataGridViewTextBoxColumn";
            tipoPrincipalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoSecundarioDataGridViewTextBoxColumn
            // 
            tipoSecundarioDataGridViewTextBoxColumn.DataPropertyName = "TipoSecundario";
            tipoSecundarioDataGridViewTextBoxColumn.HeaderText = "TipoSecundario";
            tipoSecundarioDataGridViewTextBoxColumn.Name = "tipoSecundarioDataGridViewTextBoxColumn";
            tipoSecundarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fotoDataGridViewTextBoxColumn
            // 
            fotoDataGridViewTextBoxColumn.DataPropertyName = "Foto";
            fotoDataGridViewTextBoxColumn.HeaderText = "Foto";
            fotoDataGridViewTextBoxColumn.Name = "fotoDataGridViewTextBoxColumn";
            fotoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GerenciadorDePokemons
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 531);
            Controls.Add(btnApagar);
            Controls.Add(btnEditar);
            Controls.Add(btnCriar);
            Controls.Add(label1);
            Controls.Add(pokemonDataGriedView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "GerenciadorDePokemons";
            Text = "Gerenciamento de Pokemons";
            Load += FormataDisplayDaData;
            ((System.ComponentModel.ISupportInitialize)pokemonDataGriedView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pokemonBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView pokemonDataGriedView;
        private Label label1;
        private Button btnCriar;
        private Button btnEditar;
        private Button btnApagar;
        private BindingSource pokemonBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apelidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn shinyDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataDeCapturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoPrincipalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoSecundarioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fotoDataGridViewTextBoxColumn;
    }
}
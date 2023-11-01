namespace CrudWinFormsBancoMemoria
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
            pokemonDataGriedView = new DataGridView();
            label1 = new Label();
            btnCriar = new Button();
            btnEditar = new Button();
            btnApagar = new Button();
            ((System.ComponentModel.ISupportInitialize)pokemonDataGriedView).BeginInit();
            SuspendLayout();
            // 
            // pokemonDataGriedView
            // 
            pokemonDataGriedView.AllowUserToAddRows = false;
            pokemonDataGriedView.AllowUserToDeleteRows = false;
            pokemonDataGriedView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pokemonDataGriedView.Location = new Point(37, 96);
            pokemonDataGriedView.Name = "pokemonDataGriedView";
            pokemonDataGriedView.ReadOnly = true;
            pokemonDataGriedView.RowHeadersWidth = 51;
            pokemonDataGriedView.RowTemplate.Height = 29;
            pokemonDataGriedView.Size = new Size(1261, 565);
            pokemonDataGriedView.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(502, 25);
            label1.Name = "label1";
            label1.Size = new Size(362, 46);
            label1.TabIndex = 1;
            label1.Text = "LISTA DE POKEMONS";
            // 
            // btnCriar
            // 
            btnCriar.Location = new Point(982, 667);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(94, 29);
            btnCriar.TabIndex = 2;
            btnCriar.Text = "Criar";
            btnCriar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(1095, 667);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnApagar
            // 
            btnApagar.Location = new Point(1204, 667);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(94, 29);
            btnApagar.TabIndex = 4;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 708);
            Controls.Add(btnApagar);
            Controls.Add(btnEditar);
            Controls.Add(btnCriar);
            Controls.Add(label1);
            Controls.Add(pokemonDataGriedView);
            Name = "Form1";
            Text = "Form1";
            Load += GerenciadorDePokemons_Load;
            ((System.ComponentModel.ISupportInitialize)pokemonDataGriedView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView pokemonDataGriedView;
        private Label label1;
        private Button btnCriar;
        private Button btnEditar;
        private Button btnApagar;
    }
}
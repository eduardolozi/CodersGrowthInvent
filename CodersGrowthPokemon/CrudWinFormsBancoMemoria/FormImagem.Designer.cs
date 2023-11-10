namespace CrudWinFormsBancoMemoria
{
    partial class FormImagem
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
            fotoPokemon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).BeginInit();
            SuspendLayout();
            // 
            // fotoPokemon
            // 
            fotoPokemon.Location = new Point(36, 29);
            fotoPokemon.Name = "fotoPokemon";
            fotoPokemon.Size = new Size(470, 425);
            fotoPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            fotoPokemon.TabIndex = 0;
            fotoPokemon.TabStop = false;
            // 
            // FormImagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 501);
            Controls.Add(fotoPokemon);
            Name = "FormImagem";
            Text = "Foto do Pokemon";
            Load += FormImagem_Load;
            ((System.ComponentModel.ISupportInitialize)fotoPokemon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox fotoPokemon;
    }
}
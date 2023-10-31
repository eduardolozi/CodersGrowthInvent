using CrudWinFormsBancoMemoria.Models;

namespace CrudWinFormsBancoMemoria
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemons = new List<Pokemon>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Setup_DataGriedView();

        }

        private void Setup_DataGriedView()
        {
            pokemonDataGriedView.ColumnCount = 8;
            pokemonDataGriedView.Columns[0].Name = "Id";
            pokemonDataGriedView.Columns[1].Name = "Nome";
            pokemonDataGriedView.Columns[2].Name = "Apelido";
            pokemonDataGriedView.Columns[3].Name = "Nível";
            pokemonDataGriedView.Columns[4].Name = "Data de Captura";
            pokemonDataGriedView.Columns[5].Name = "Tipo Principal";
            pokemonDataGriedView.Columns[6].Name = "Tipo Secundário";
            pokemonDataGriedView.Columns[7].Name = "Altura";
        }


    }
}
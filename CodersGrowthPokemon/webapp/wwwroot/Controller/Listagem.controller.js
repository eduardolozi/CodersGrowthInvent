sap.ui.define([
    "./BaseController",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
    "../Repositorios/PokemonRepository",
    "../Services/ProcessarEventos"
], (BaseController, JSONModel, formatter, Filter, FilterOperator, PokemonRepository, ProcessarEventos) => {
    "use strict"

    const nomeModeloPokemons = "pokemons";
    let roteador;

    return BaseController.extend("webapp.Controller.Listagem", {
        formatter: formatter,

        onInit() {
            const paginaDeListagem = "listagem";

            roteador = this._retornaRoteador();
            roteador.getRoute(paginaDeListagem).attachMatched(this._aoCoincidirRota, this); 
            
        },

        _carregarPokemons() {
            PokemonRepository.obterTodosOsPokemons()
            .then(response => {
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemons);
                })
        },

        aoFiltrarPokemons(evento) {
            ProcessarEventos.processarEvento(() => {
                const parametroParaConsulta = "query";
                const consulta = evento.getParameter(parametroParaConsulta);

                if(consulta) {
                    PokemonRepository.obterTodosOsPokemons(consulta)
                        .then (pokemons => this.getView().setModel(new JSONModel(pokemons), nomeModeloPokemons));
                        return
                } 
                this._carregarPokemons();
            })
        },

        _aoCoincidirRota() {
            ProcessarEventos.processarEvento(() => {
                this._carregarPokemons();
            })
        },

        aoClicarEmUmaLinhaDaTabela(evento) {
            ProcessarEventos.processarEvento(() => {
                const nomeParametroId = "id";
                const nomePaginaDeDetalhes = "detalhes";
                const items = evento.getSource();
                const idDoPokemonClicado = items.getBindingContext(nomeModeloPokemons).getProperty(nomeParametroId);
                roteador = this._retornaRoteador();
    
                roteador.navTo(nomePaginaDeDetalhes, {
                    detalhesPath: idDoPokemonClicado
                })
            })
        },

        aoClicarNoBotaoAdicionar() {
            ProcessarEventos.processarEvento(() => {
                const nomePaginaDeCadastro = "cadastro";
                roteador = this._retornaRoteador();
    
                roteador.navTo(nomePaginaDeCadastro, {})
            })
        }

    });
})
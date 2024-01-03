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
                const idListaDePokemons = "listaDePokemons";
                const itensDaLista = "items";
                const campoNome = "nome";
                const parametroParaConsulta = "query";
                const filtros = [];
                const consulta = evento.getParameter(parametroParaConsulta);
                let listaDePokemons;
                let pokemonsDaLista;
    
                if (consulta) {
                    PokemonRepository.obterTodosOsPokemons(consulta)
                        .then(pokemons => {
                            pokemons.forEach(() => {
                                filtros.push(new Filter(campoNome, FilterOperator.Contains, consulta));
                            })
                            listaDePokemons = this.byId(idListaDePokemons);
                            pokemonsDaLista = listaDePokemons.getBinding(itensDaLista);
                            pokemonsDaLista.filter(filtros);
                        })
                }
                else {
                    listaDePokemons = this.byId(idListaDePokemons);
                    pokemonsDaLista = listaDePokemons.getBinding(itensDaLista);
                    pokemonsDaLista.filter(filtros);
                }
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
                roteador = this._retornaRoteador();
    
                roteador.navTo(nomePaginaDeDetalhes, {
                    detalhesPath: window.encodeURIComponent(items.getBindingContext(nomeModeloPokemons).getProperty(nomeParametroId))
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
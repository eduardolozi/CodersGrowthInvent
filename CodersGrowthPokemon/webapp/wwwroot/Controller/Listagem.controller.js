sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
    "use strict"
    const nomeModeloPokemons = "pokemons";
    let roteador;

    return Controller.extend("webapp.Controller.Listagem", {
        formatter: formatter,

        onInit() {
            this._carregarPokemons();
        },

        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _carregarPokemons() {
            const urlApi = "/pokemons";

            fetch(urlApi)
                .then(response => {
                    return response.json();
                })
                .then(response => {
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemons);
                })
                .catch(erro => {
                    console.log(erro);
                });
        },

        aoFiltrarPokemons(evento) {
            const idListaDePokemons = "listaDePokemons";
            const itensDaLista = "items";
            const campoNome = "nome";
            const parametroParaConsulta = "query";
            const filtros = [];
            const consulta = evento.getParameter(parametroParaConsulta);
            let listaDePokemons;
            let pokemonsDaLista;

            if (consulta) {
                this._obterPokemonPeloNome(consulta)
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
        },

        _obterPokemonPeloNome(nome) {
            const urlApi = `/pokemons?nome=${nome}`

            return fetch(urlApi)
            .then(response => response.json())
            .catch(erro => console.log(erro))
        },

        aoClicarEmUmaLinhaDaTabela(evento) {
            const nomeParametroId = "id";
            const nomePaginaDeDetalhes = "detalhes";
            const items = evento.getSource();
            roteador = this._retornaRoteador();

            roteador.navTo(nomePaginaDeDetalhes, {
                detalhesPath: window.encodeURIComponent(items.getBindingContext(nomeModeloPokemons).getProperty(nomeParametroId))
            })
        },

        aoClicarNoBotaoAdicionar() {
            const nomePaginaDeCadastro = "cadastro";
            roteador = this._retornaRoteador();

            roteador.navTo(nomePaginaDeCadastro, {})
        }

    });
})
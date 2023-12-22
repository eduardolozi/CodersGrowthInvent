sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
    "use strict"
    const nomeModeloPokemons = "pokemons";

    return Controller.extend("webapp.Controller.Listagem", {
        formatter: formatter,
        onInit() {
            this._carregarPokemons();
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
            if (consulta) {
                filtros.push(new Filter(campoNome, FilterOperator.Contains, consulta));
            }
            const oList = this.byId(idListaDePokemons);
            const oBinding = oList.getBinding(itensDaLista);
            oBinding.filter(filtros);
        },

        aoClicarEmUmaLinhaDaTabela(evento) {
            const nomeParametroId = "id";
            const nomePaginaDeDetalhes = "detalhes";

            const items = evento.getSource();
            const roteador = this.getOwnerComponent().getRouter();
            roteador.navTo(nomePaginaDeDetalhes, {
                detalhesPath: window.encodeURIComponent(items.getBindingContext(nomeModeloPokemons).getProperty(nomeParametroId))
            })
        },

        aoClicarNoBotaoAdicionar() {
            const nomePaginaDeCadastro = "cadastro";

            const roteador = this.getOwnerComponent().getRouter();
            roteador.navTo(nomePaginaDeCadastro, {})
        }

    });
})
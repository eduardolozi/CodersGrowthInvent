sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/core/routing/History",

], (Controller, JSONModel, formatter, History) => {
    "use strict"
    return Controller.extend("webapp.Controller.Detalhes", {
        formatter: formatter,

        onInit() {
            const rotaDetalhes = "detalhes";
            const roteador = this.getOwnerComponent().getRouter();

			roteador.getRoute(rotaDetalhes).attachPatternMatched(this.noObjetoCorrespondente, this);
        },

        noObjetoCorrespondente(evento) {
            const argumentos = "arguments";

            let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)
            this._carregarPokemon(indice)
        },

        _carregarPokemon(indice) {
            const rotaApi = `/pokemons/${indice}`;
            const nomeModeloPokemon = "detalhePokemon";

            fetch(rotaApi)
            .then(response => {
                return response.json()
            })
            .then(response => {
                this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
            })
            .catch(erro => {
                console.log(erro);
            })
        },

        aoClicarBotaoVoltar() {
            const paginaDeListagem = "listagem";
            const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();
            const paginaAnteriorNoHistorico = -1;

            if (hashAnterior !== undefined) {
				window.history.go(paginaAnteriorNoHistorico);
			} else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo(paginaDeListagem, {}, true);
			}
        },

        aoClicarBotaoVerCard() {
            const caminhoCardPokemon = "webapp.View.CardPokemon";

            this.pDialog ??= this.loadFragment({
                name: caminhoCardPokemon
            });
            this.pDialog.then((card) => card.open());
        },

        aoFecharDialog() {
            const idCardPokemon = "cardPokemon";

            this.byId(idCardPokemon).close();
        }
    })
})
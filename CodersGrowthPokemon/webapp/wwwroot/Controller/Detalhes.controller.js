sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/core/routing/History",

], (Controller, JSONModel, formatter, History) => {
    "use strict"
    const nomeModeloPokemon = "detalhePokemon";
    let roteador;

    return Controller.extend("webapp.Controller.Detalhes", {
        formatter: formatter,

        onInit() {
            const rotaDetalhes = "detalhes";
            roteador = this._retornaRoteador();

			roteador.getRoute(rotaDetalhes).attachPatternMatched(this.aoCoincidirRota, this);
        },

        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _carregarPokemon(indice) {
            const rotaApi = `/pokemons/${indice}`;

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

        aoCoincidirRota(evento) {
            const argumentos = "arguments";
            let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)

            this._carregarPokemon(indice)
        },

        aoClicarBotaoVoltar() {
            const paginaDeListagem = "listagem";
            const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();
            const paginaAnteriorNoHistorico = -1;
            roteador = this._retornaRoteador();

            if (hashAnterior !== undefined) {
				window.history.go(paginaAnteriorNoHistorico);
			} else {
				roteador.navTo(paginaDeListagem, {}, true);
			}
        },

        aoClicarBotaoEditar() {
            const nomePaginaDeCadastro = "cadastro";
            const nomeParametroId = "id";
            const parametroId = this.getView().getModel(nomeModeloPokemon).getProperty(nomeParametroId)
            roteador = this._retornaRoteador();
            
            roteador.navTo(nomePaginaDeCadastro, {
                id: window.encodeURIComponent(parametroId)
            })
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
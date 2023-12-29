sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/m/MessageBox"
], (Controller, JSONModel, formatter, MessageBox) => {
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

        _retornaIdDoPokemon() {
            return this.getView().getModel(nomeModeloPokemon).getProperty("/id");
        },

        _retornaNomeDoPokemon() {
            return this.getView().getModel(nomeModeloPokemon).getProperty("/nome");
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

        _removePokemon(indice) {
            const rotaApi = `/pokemons/${indice}`;
            const metodoDoFetch = "DELETE";

            fetch(rotaApi, {
                method: metodoDoFetch
            })
            .then(response => response.json)
            .catch(erro => console.log(erro))
        },

        aoCoincidirRota(evento) {
            const argumentos = "arguments";
            let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)

            this._carregarPokemon(indice)
        },

        aoClicarBotaoVoltar() {
            const paginaDeListagem = "listagem";
            
            roteador = this._retornaRoteador();
            roteador.navTo(paginaDeListagem, {}, true);
        },

        aoClicarBotaoEditar() {
            const nomePaginaDeCadastro = "cadastro";
            const nomeParametroId = "/id";
            const parametroId = this.getView().getModel(nomeModeloPokemon).getProperty(nomeParametroId)
            
            roteador = this._retornaRoteador();
            roteador.navTo(nomePaginaDeCadastro, {
                id: window.encodeURIComponent(parametroId)
            })
        },   

        aoClicarBotaoRemover() {
            const nomeDoPokemon = this._retornaNomeDoPokemon();
            const mensagemDeConfirmacao = `Deseja mesmo cancelar o pokemon ${nomeDoPokemon}`
            const idDoPokemon = this._retornaIdDoPokemon();
            const nomePaginaListagem = "listagem";
            const sim = "Sim";
            const nao = "Não";

            MessageBox.information(mensagemDeConfirmacao, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        this._removePokemon(idDoPokemon);
                        roteador = this._retornaRoteador();
                        roteador.navTo(nomePaginaListagem, {})
                    } 
                }
            });
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
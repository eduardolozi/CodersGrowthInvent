sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], (Controller, formatter, History, MessageBox, JSONModel) => {
    "use strict"
    const sim = "Sim";
    const nao = "Não";
    const nomeModeloPokemon = "pokemon"
    return Controller.extend("webapp.Controller.Cadastro", {
        formatter: formatter,

        onInit() {
            this.getView().setModel(new JSONModel({}), nomeModeloPokemon);
        },

        _salvarPokemon() {
            const urlFetch = "/pokemons"
            const dados = JSON.stringify(this.getView().getModel(nomeModeloPokemon).getData())
            console.log(dados)
            fetch(urlFetch, {
                method: "POST",
            }).then(response => {
                return response.json();
            }).then(response => {
                console.log(response)
            })
        },

        aoClicarNoBotaoDeVoltar(oEvent) {
            const paginaDeListagem = "listagem";
            const oHistory = History.getInstance();
			const sPreviousHash = oHistory.getPreviousHash();
            const paginaAnteriorNoHistorico = -1;

            if (sPreviousHash !== undefined) {
				window.history.go(paginaAnteriorNoHistorico);
			} else {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo(paginaDeListagem, {}, true);
			}
        },

        aoClicarNoBotaoDeSalvar(oEvent) {
            const mensagemAoClicarEmSalvar = "Salvar o Pokémon criado?";

            MessageBox.information(mensagemAoClicarEmSalvar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (oAction) => {
                    if (oAction === sim) {
                        this._salvarPokemon();
                        this.aoClicarNoBotaoDeVoltar();
                    } 
                }
            });
        },

        aoClicarNoBotaoDeCancelar(oEvent) {
            const mensagemAoClicarEmCancelar = "Cancelar a criação do Pokémon?"

            MessageBox.alert(mensagemAoClicarEmCancelar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (oAction) => {
                    if (oAction === sim) {
                        this.aoClicarNoBotaoDeVoltar();
                    } 
                }
            });
        }

    });
})
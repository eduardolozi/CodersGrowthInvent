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

        _salvarPokemon(oEvent) {
            const urlFetch = "/pokemons/"
            const dados = this.getView().getModel(nomeModeloPokemon).getData();
            const novoPokemon = {
                nome: dados.nome,
                apelido: dados.apelido,
                nivel: parseInt(dados.nivel),
                altura: parseFloat(dados.altura),
                dataDeCaptura: dados.dataDeCaptura,
                tipoPrincipal: parseInt(dados.tipoPrincipal),
                tipoSecundario: (dados.tipoSecundario === undefined) ? null : parseInt(dados.tipoSecundario),
                shiny: (dados.shiny === undefined) ? false : true,
                foto: null
            }

            
            console.log(novoPokemon)
            fetch(urlFetch, {
                method: "POST",
                body: JSON.stringify(novoPokemon),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }).then(response => {
                return response.json();
            }).then(data => {
                const nomePaginaDeDetalhes = "detalhes";
                const idPokemon = data.id;
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(nomePaginaDeDetalhes, {detalhesPath: idPokemon});
            }).catch(error => {
                console.log(error)
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
                        this._salvarPokemon(oEvent);
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
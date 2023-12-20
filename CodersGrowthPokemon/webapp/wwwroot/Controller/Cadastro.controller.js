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
            const novoPokemon = {
                nome: this.getView().getModel(nomeModeloPokemon).getProperty("/nome"),
                apelido: this.getView().getModel(nomeModeloPokemon).getProperty("/apelido"),
                nivel: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty("/nivel")),
                altura: parseFloat(this.getView().getModel(nomeModeloPokemon).getProperty("/altura")),
                dataDeCaptura: this.getView().getModel(nomeModeloPokemon).getProperty("/dataDeCaptura"),
                tipoPrincipal: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty("/tipoPrincipal")),
                tipoSecundario: (this.getView().getModel(nomeModeloPokemon).getProperty("/tipoSecundario") === undefined) ? null : parseInt(this.getView().getModel(nomeModeloPokemon).getProperty("/tipoSecundario")),
                shiny: (this.getView().getModel(nomeModeloPokemon).getProperty("/shiny") === undefined) ? false : true,
                foto: (this.getView().getModel(nomeModeloPokemon).getProperty("/foto") === undefined) ? null : this.getView().byId("inputFoto").getValue()
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
        },

        aoCarregarImagem(oEvent) {
            var arquivo = oEvent.getParameters("files").files[0];
            var leitor = new FileReader();
            leitor.readAsArrayBuffer(arquivo);
            leitor.onload = (evt) => {
                const arrayDeBytes = new Uint8Array(evt.target.result);
                let stringBinaria = '';
                for (let i = 0; i < arrayDeBytes.byteLength; i++) {
                    stringBinaria += String.fromCharCode(arrayDeBytes[i]);
                }
                let base64 = window.btoa( stringBinaria );
                this.getView().byId("inputFoto").setValue(base64);
                this.getView().byId("fotoDoPokemon").setSrc(base64);
            }
        }
    });
})
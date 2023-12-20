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

        noObjetoCorrespondente(oEvent) {
            const argumentos = "arguments";

            let indice = window.decodeURIComponent(oEvent.getParameter(argumentos).detalhesPath)
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
                if(response.foto != null) {
                    let blob = this._converteBase64ParaBlob(response.foto);
                    response.foto = URL.createObjectURL(blob);
                }
                this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
            })
            .catch(erro => {
                console.log(erro);
            })
        },

        _converteBase64ParaBlob(stringBase64, tipoConteudo='', tamanhoDoPedaco=512) {
            const caracteresEmBytes = atob(stringBase64);
            const bytesArquivo = [];
          
            for (let offset = 0; offset < caracteresEmBytes.length; offset += tamanhoDoPedaco) {
              const pedaco = caracteresEmBytes.slice(offset, offset + tamanhoDoPedaco);
          
              const numerosDosBytes = new Array(pedaco.length);
              for (let i = 0; i < pedaco.length; i++) {
                numerosDosBytes[i] = pedaco.charCodeAt(i);
              }
          
              const byteArray = new Uint8Array(numerosDosBytes);
              bytesArquivo.push(byteArray);
            }
          
            const blob = new Blob(bytesArquivo, {type: tipoConteudo});
            return blob;
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

        aoClicarBotaoVerCard(oEvent) {
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
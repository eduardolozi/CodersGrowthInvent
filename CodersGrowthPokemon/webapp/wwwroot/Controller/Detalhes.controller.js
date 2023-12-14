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
            const oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detalhes").attachPatternMatched(this._carregarPokemon, this);
        },

        _carregarPokemon() {
            
            let url = window.location.href.split("/");
            let idNaUrl = url.length - 1;
            let idPokemon = url[idNaUrl];

            fetch(`/pokemons/${idPokemon}`)
            .then(response => {
                return response.json()
            })
            .then(response => {
                if(response.foto != null) {
                    let blob = this._converteBase64ParaBlob(response.foto);
                    response.foto = URL.createObjectURL(blob);
                }
                this.getView().setModel(new JSONModel(response), "detalhePokemon");
            })
            .catch(error => {
                console.log(error);
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

        onNavBack() {
            const oHistory = History.getInstance();
			const sPreviousHash = oHistory.getPreviousHash();

            if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("listagem", {}, true);
			}
        }
    })
})
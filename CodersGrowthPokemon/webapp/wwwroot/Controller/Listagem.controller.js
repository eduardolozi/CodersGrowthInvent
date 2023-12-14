sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
    "use strict"
    return Controller.extend("webapp.Controller.Listagem", {
        formatter: formatter,
        onInit() {
            this._carregarPokemons();
        },

        _carregarPokemons() {
            fetch("/pokemons")
                .then(response => {
                    return response.json();
                })
                .then(response => {
                    const pokemonsResponse = Object.entries(response)
                    for(let i=0;i<pokemonsResponse.length;i++) {
                        if(pokemonsResponse[i][1].foto != null) {
                            let blob = this._converteBase64ParaBlob(pokemonsResponse[i][1].foto);
                            pokemonsResponse[i][1].foto = URL.createObjectURL(blob);
                        }
                    }
                    
                    this.getView().setModel(new JSONModel(response), "pokemons");
                })
                .catch(error => {
                    console.log(error);
                });
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

        aoFiltrarPokemons(oEvent) {
            const aFilter = [];
            const sQuery = oEvent.getParameter("query");
            if (sQuery) {
                aFilter.push(new Filter("nome", FilterOperator.Contains, sQuery));
            }
            const oList = this.byId("listaDePokemons");
            const oBinding = oList.getBinding("items");
            oBinding.filter(aFilter);
        },

        aoClicarEmUmaLinhaDaTabela(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("detalhes", {
                detalhesPath: window.encodeURIComponent(oItem.getBindingContext("pokemons").getProperty("id"))
            })
        }

    });
})
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

        _converteBase64ParaBlob(b64Data, contentType='', sliceSize=512) {
            const byteCharacters = atob(b64Data);
            const byteArrays = [];
          
            for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
              const slice = byteCharacters.slice(offset, offset + sliceSize);
          
              const byteNumbers = new Array(slice.length);
              for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
              }
          
              const byteArray = new Uint8Array(byteNumbers);
              byteArrays.push(byteArray);
            }
          
            const blob = new Blob(byteArrays, {type: contentType});
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
                detalhesPath: window.encodeURIComponent(oItem.getBindingContext("pokemons>id").getPath().substr(1))
            })
          }

    });
})
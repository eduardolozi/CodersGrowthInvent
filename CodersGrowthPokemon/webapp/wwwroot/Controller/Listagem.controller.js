sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
    "use strict"
    const nomeModeloPokemons = "pokemons";

    return Controller.extend("webapp.Controller.Listagem", {
        formatter: formatter,
        onInit() {
            this._carregarPokemons();
        },

        _carregarPokemons() {
            const urlApi = "/pokemons";

            fetch(urlApi)
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
                    
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemons);
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
            const idListaDePokemons = "listaDePokemons";
            const itensDaLista = "items";
            const campoNome = "nome";
            const parametroParaConsulta = "query";

            const aFilter = [];
            const sQuery = oEvent.getParameter(parametroParaConsulta);
            if (sQuery) {
                aFilter.push(new Filter(campoNome, FilterOperator.Contains, sQuery));
            }
            const oList = this.byId(idListaDePokemons);
            const oBinding = oList.getBinding(itensDaLista);
            oBinding.filter(aFilter);
        },

        aoClicarEmUmaLinhaDaTabela(oEvent) {
            const nomeParametroId = "id";
            const nomePaginaDeDetalhes = "detalhes";

            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(nomePaginaDeDetalhes, {
                detalhesPath: window.encodeURIComponent(oItem.getBindingContext(nomeModeloPokemons).getProperty(nomeParametroId))
            })
        }

    });
})
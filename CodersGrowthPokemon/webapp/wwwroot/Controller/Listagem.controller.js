sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter"
], (Controller, JSONModel, formatter) => {
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
                    Object.entries(reponse).forEach(([key, value]) => {
                        console.log(response);
                        if(key=='foto') {
                            value = this._converteBase64ParaBlob(value);
                            console.log(value);
                            value = URL.createObjectURL(value);
                            console.log(value);
                        }
                    })
                    
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
          }



    });
})
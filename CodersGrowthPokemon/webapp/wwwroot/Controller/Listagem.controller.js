sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter"
], (Controller, JSONModel) => {
    "use strict"
    return Controller.extend("webapp.Controller.Listagem", {

        onInit() {
            this._carregarPokemons();
        },

        _carregarPokemons() {
            fetch("/pokemons")
                .then(response => {
                    return response.json();
                })
                .then(response => {
                    this.getView().setModel(new JSONModel(response), "pokemons");
                })
                .catch(error => {
                    console.log(error);
                });
        }
    });
})
sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"
], (Controller, JSONModel) => {
    "use strict"
    return Controller.extend("webapp.Controller.Listagem", {
        onInit() {
            // const pokemonsJSON = fetch("https://localhost:7237/pokemons")
            //     .then(response => {
            //         if(!response.ok) return new Error("Requisicao falhou");
            //         if(response.status === 404) return new Error("Nao encontrou resultados");
            //         return response.json
            //     })
            // pokemonsJSON.then((e) => this.getView().setModel(pokemonsJSON, "view")).catch((e) => console.log("errooooooo" + e.message));

            
        },

        carregarPokemons() {
            fetch("/pokemons")
                .then(response => {
                    return response.json();
                })
                .then(response => {
                   this.getView().setModel(new JSONModel(response, "pokemons")) 
                })
                .catch(error => {
                    console.log(error);
                });
        }
    });
})
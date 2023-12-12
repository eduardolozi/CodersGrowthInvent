sap.ui.define([
], () => {
"use strict";

    return {
        formataShiny(shiny) {
            return ((shiny==true) ? "Sim" : "Não");
        },

        formataTipo(tipo) {            
        const tipos = ["Água", "Fogo", "Planta", "Elétrico", "Gelo", "Lutador", "Psíquico", "Terra", "Voador", "Veneno", "Rocha", "Inseto", "Fantasma", "Noturno", "Aço", "Dragão", "Normal"];
        const INDEX_DO_POKEMON = tipo - 1;
        return ((tipo < 1 || tipo > 17) ? "Nenhum" : tipos[INDEX_DO_POKEMON]); 
        }
    }
})

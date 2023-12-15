sap.ui.define([
], () => {
"use strict";

    return {
        formataShiny(shiny) {
            const sim = "sim";
            const nao = "não";
            return (shiny == true) ? sim : nao;
        },

        formataTipo(tipo) {            
            const tipos = ["Água", "Fogo", "Planta", "Elétrico", "Gelo", "Lutador", "Psíquico", "Terra", "Voador", "Veneno", "Rocha", "Inseto", "Fantasma", "Noturno", "Aço", "Dragão", "Normal"];
            const INDEX_DO_POKEMON = tipo - 1;
            const nenhumTipo = "nenhum"

            return (tipo < 1 || tipo > 17) ? nenhumTipo : tipos[INDEX_DO_POKEMON]; 
        },

        formataImagem(foto) {
            const urlImagemIndefinida = "https://imgur.com/M2gmRB7.gif"

            return (foto) ? foto : urlImagemIndefinida;
        }
    }
})

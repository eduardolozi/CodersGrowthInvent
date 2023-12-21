sap.ui.define([
], () => {
"use strict";

    return {
        formataShiny(shiny) {
            const sim = "Sim";
            const nao = "Não";
            return (shiny == true) ? sim : nao;
        },

        formataTipo(tipo) {            
            const tipos = ["Água", "Fogo", "Planta", "Elétrico", "Gelo", "Lutador", "Psíquico", "Terra", "Voador", "Veneno", "Rocha", "Inseto", "Fantasma", "Noturno", "Aço", "Dragão", "Normal"];
            const INDEX_DO_POKEMON = tipo - 1;
            const nenhumTipo = "Nenhum"

            return (tipo < 1 || tipo > 17) ? nenhumTipo : tipos[INDEX_DO_POKEMON]; 
        },

        formataImagem(foto) {
            const cabecalhoImagem = "data:image/png;base64,";
            const urlImagemIndefinida = "https://imgur.com/M2gmRB7.gif"
            return (foto ? (cabecalhoImagem + foto) : urlImagemIndefinida)
        }
    }
})

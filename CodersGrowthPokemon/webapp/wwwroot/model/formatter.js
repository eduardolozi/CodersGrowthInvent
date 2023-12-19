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
            const urlImagemIndefinida = "https://imgur.com/M2gmRB7.gif"

            return (foto) ? foto : urlImagemIndefinida;
        },

        converteUrlParaBase64(url, callback) {
            const image = new Image();
            image.crossOrigin='anonymous';
            image.onload = () => {
                const canvas = document.createElement('canvas');
                const ctx = canvas.getContext('2d');
                canvas.height = image.naturalHeight;
                canvas.width = image.naturalWidth;
                ctx.drawImage(image, 0, 0);
                const dataUrl = canvas.toDataURL();
                callback && callback(dataUrl)
            }
            image.src = url;
            return image.src;
        }
    }
})

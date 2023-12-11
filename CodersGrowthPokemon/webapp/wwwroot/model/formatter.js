sap.ui.define([
], () => {
"use strict";

    return {
        formataShiny(shiny) {
            return ((shiny==true) ? "Sim" : "Não");
        },

        formataTipo(tipo) {            
            switch(tipo) {
                case 1:
                    return "Agua";
                case 2:
                    return "Fogo";
                case 3:
                    return "Planta";
                case 4:
                    return "Eletrico";
                case 5:
                    return "Gelo";
                case 6:
                    return "Lutador";
                case 7:
                    return "Psiquico";
                case 8:
                    return "Terra";
                case 9:
                    return "Voador";
                case 10:
                    return "Veneno";
                case 11:
                    return "Rocha";
                case 12:
                    return "Inseto";
                case 13:
                    return "Fantasma";
                case 14:
                    return "Noturno";
                case 15:
                    return "Aco";
                case 16:
                    return "Dragao";
                case 17:
                    return "Normal";
                default:
                    return "Nenhum";
            }
        },

        formataImagem(base64) {
            let urlCreator = window.URL || window.webkitURL;
            let url = urlCreator.createObjectURL(base64);
            let foto = xmlDoc.createElement("ImagemPokemon");
            foto.src = url;
            let elemento = xmlDoc.getElementsByTagName("FlexBox");
            elemento[0].appendChild(foto)
        }
    }
})

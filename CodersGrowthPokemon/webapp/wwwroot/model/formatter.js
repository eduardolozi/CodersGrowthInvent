sap.ui.define([
], () => {
"use strict";

    return {
        formatarTipoSecundario: function(tipoSecundario) {
            const oTipo = this.getView("Listagem").getModel("pokemons").getProperty("/tipoSecundario");
            switch(oTipo) {
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
                    return oTipo.getText( "Veneno");
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
                    return tipoSecundario;
            }
        }
    }
})

sap.ui.define([
], () => {
"use strict";
    return {
        _validaNome(nome, i18n) {
            const regex = /A-Za-z/;
            if(!nome.match(regex))  console.log(i18n.getText("NomeApenasLetras"));
        }
    }
})

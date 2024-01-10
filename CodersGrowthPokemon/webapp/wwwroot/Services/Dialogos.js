sap.ui.define([
    "sap/m/MessageBox"
], (MessageBox) => {
"use strict";
    return {
        MessageBox : MessageBox,

        _exibirDialogoDeConfirmacao(texto, i18n) {
            const sim = "sim"
            const nao = "nao";
            const botaoSim = i18n.getText(sim);
            const botaoNao = i18n.getText(nao)
            
            return new Promise((resolve, reject) => {
                MessageBox.confirm(texto, {
                    actions: [botaoSim, botaoNao],
                    emphasizedAction: botaoSim,
                    onClose: resolve
                })
            })
        },

        _exibirDialogoDeSucesso(texto) {
            return new Promise((resolve, reject) => {
                MessageBox.success(texto, {
                    onClose: resolve
                })
            })
        },

        _exibirDialogoDeErro(texto) {
            return new Promise((resolve, reject) => {
                MessageBox.error(texto, {
                    onClose: resolve
                })
            })
        }
    }
});

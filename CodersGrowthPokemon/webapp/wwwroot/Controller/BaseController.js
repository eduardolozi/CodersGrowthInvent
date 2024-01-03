sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "../Services/Mensagens"
], (Controller, Mensagens) => {
	"use strict";

	return Controller.extend("webapp.Controller.BaseController", {
        Mensagens: Mensagens,
        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _retornai18n() {
            const modeloi18n = "i18n"
            return this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
        }, 

        _retornaModeloPokemon() {
            const nomeModeloPokemon = "pokemon"
            return this.getView().getModel(nomeModeloPokemon);
        },

        _retornaIdDoPokemon() {
            const propriedadeId = "/id";
            return this._retornaModeloPokemon().getProperty(propriedadeId);
        }, 

        _injetaI18nNaClasseDeMensagens() {
            const i18n = this._retornai18n()
            Mensagens.Mensagens(i18n)
        },
	});

});
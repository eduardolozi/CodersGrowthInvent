sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";

	return Controller.extend("webapp.Controller.BaseController", {

        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _retornai18n() {
            const modeloi18n = "i18n"
            return this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
        }, 

        _retornaIdDoPokemon() {
            const propriedadeId = "/id";
            return this._retornaModeloPokemon().getProperty(propriedadeId);
        }
	});

});
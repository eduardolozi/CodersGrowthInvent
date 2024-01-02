sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], function (Controller) {
    "use strict";
    return Controller.extend("webapp.Controller.NotFound", {
        onInit: function () {
		},

		_retornaRouter() {
			return this.getOwnerComponent().getRouter();
		},

		aoClicarNoBotaoDeVoltar() {
			const paginaDeListagem = "listagem"
			const roteador = this._retornaRouter();
			roteador.navTo(paginaDeListagem, {})
		}

    });
 });
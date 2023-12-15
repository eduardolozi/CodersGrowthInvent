sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/core/routing/History"
], (Controller, formatter, History) => {
    "use strict"
    return Controller.extend("webapp.Controller.Cadastro", {
        formatter: formatter,

        onInit() {

        },

        aoClicarNoBotaoDeVoltar(oEvent) {
            const paginaDeListagem = "listagem";
            const oHistory = History.getInstance();
			const sPreviousHash = oHistory.getPreviousHash();
            const paginaAnteriorNoHistorico = -1;

            if (sPreviousHash !== undefined) {
				window.history.go(paginaAnteriorNoHistorico);
			} else {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo(paginaDeListagem, {}, true);
			}
        }

    });
})
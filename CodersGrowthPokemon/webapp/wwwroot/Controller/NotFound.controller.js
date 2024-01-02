sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], function (Controller) {
    "use strict";
    return Controller.extend("webapp.Controller.NotFound", {
        onInit: function () {
			var oRouter, oTarget;

			oRouter = this.getRouter();
			oTarget = oRouter.getTarget("notFound");
			oTarget.attachDisplay(function (oEvent) {
				this._oData = oEvent.getParameter("data");
			}, this);
		},

    });
 });
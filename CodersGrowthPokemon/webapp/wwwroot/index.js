sap.ui.define([
	"sap/ui/core/ComponentContainer"
], (ComponentContainer) => {
	"use strict";

	new ComponentContainer({
		name: "webapp",
		settings: {
			id: "webapp"
		},
		async: true
	}).placeAt("content");
});

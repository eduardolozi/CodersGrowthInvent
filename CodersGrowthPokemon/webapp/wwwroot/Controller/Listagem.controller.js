sap.ui.define([
    "sap/ui/core/mvc/Controller"
], (Controller) => {
    return Controller.extend("webapp.Controller.Listagem", {
        onInit() {
            const pokemonsJSON = fetch("http://localhost:7237/pokemons")
                .then(response => response.json)
                .catch(() => console.log("Erro ao pegar os pokemons do banco de dados."))
                .then(() => console.log(pokemonsJSON))
            this.getView().setModel(pokemonsJSON, "view");
        }
    });
});
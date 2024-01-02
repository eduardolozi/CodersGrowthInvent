sap.ui.define([
], () => {
"use strict";

    return {
        obterTodosOsPokemons() {
            const urlApi = "/pokemons";

            return fetch(urlApi)
            .then(response => response.json())
            .catch(erro => console.log(erro))
        },
        
        obterPokemonPorNome(nome) {
            const urlApi = `/pokemons?nome=${nome}`
            
            return fetch(urlApi)
            .then(response => response.json())
            .catch(erro => console.log(erro))
        },

        obterPokemonPorId(indice) {
            const urlApi = `/pokemons/${indice}`;

            return fetch(urlApi)
            .then(response => response.json())
            .catch(erro => console.log(erro))
        },

        atualizarPokemon(pokemonAtualizado) { 
            const idPokemon = pokemonAtualizado.id;           
            const urlApi = `/pokemons/${idPokemon}`;
            const metodoDoFetch = "PUT";

            return fetch(urlApi, {
                method: metodoDoFetch,
                body: JSON.stringify(pokemonAtualizado),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            })
            .then(response => response.json())
            .catch(error => console.log(error))

            
        },

        criarPokemon(novoPokemon) {
            const urlFetch = "/pokemons/";
            const metodoDoFetch = "POST";

            return fetch(urlFetch, {
                method: metodoDoFetch,
                body: JSON.stringify(novoPokemon),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            })
            .then(response => response.json())
            .catch(error => console.log(error))
        },

        removerPokemon(indice) {
            const rotaApi = `/pokemons/${indice}`;
            const metodoDoFetch = "DELETE";

            return fetch(rotaApi, {
                method: metodoDoFetch
            })
            .then(response => response.json)
            .catch(erro => console.log(erro))
        }
    }
        
});
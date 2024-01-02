sap.ui.define([
], () => {
"use strict";

    return {
        obterTodosOsPokemons() {
            const urlApi = "/pokemons";

            fetch(urlApi)
                .then(response => {
                    return response.json();
                })
                .then(response => {
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemons);
                })
                .catch(erro => {
                    console.log(erro);
                });
        },
        
        _obterPokemonPeloNome(nome) {
            const urlApi = `/pokemons?nome=${nome}`
            
            return fetch(urlApi)
            .then(response => response.json())
            .catch(erro => console.log(erro))
        },

        _obterPokemonPeloId(indice) {
            const rotaApi = `/pokemons/${indice}`;

            fetch(rotaApi)
            .then(response => {
                return response.json()
            })
            .then(response => {
                this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
            })
            .catch(erro => {
                console.log(erro);
            })
        },

        _atualizarPokemon() {
            const i18n = this._retornai18n();
            const idPokemon = this._retornaIdDoPokemon()
            const urlFetch = `/pokemons/${idPokemon}`;
            const metodoDoFetch = "PUT";
            const sucessoAoAtualizar = "sucessoAoAtualizar"
            const mensagemSucessoAoAtualizar = i18n.getText(sucessoAoAtualizar);

            const pokemonAtualizado = this._insereCamposNoModeloPokemon()
            pokemonAtualizado.id = this._retornaIdDoPokemon()

            fetch(urlFetch, {
                method: metodoDoFetch,
                body: JSON.stringify(pokemonAtualizado),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }).then(response => {
                return response.json();
            }).then(() => {
                const nomePaginaDeDetalhes = "detalhes";

                MessageBox.success(mensagemSucessoAoAtualizar, {
                    actions: [MessageBox.Action.OK],
                    onClose: () => {
                        roteador = this._retornaRoteador();
                        roteador.navTo(nomePaginaDeDetalhes, {detalhesPath: pokemonAtualizado.id});
                    }
                })
                
            }).catch(error => {
                console.log(error)
            })
        },

        _criarPokemon() {
            const i18n = this._retornai18n();
            const urlFetch = "/pokemons/";
            const metodoDoFetch = "POST";
            const sucessoAoSalvar = "sucessoAoSalvar"
            const mensagemSucessoAoSalvar = i18n.getText(sucessoAoSalvar);

            const novoPokemon = this._insereCamposNoModeloPokemon()

            fetch(urlFetch, {
                method: metodoDoFetch,
                body: JSON.stringify(novoPokemon),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }).then(response => {
                return response.json();
            }).then(data => {
                const nomePaginaDeDetalhes = "detalhes";
                const idPokemon = data.id;

                MessageBox.success(mensagemSucessoAoSalvar, {
                    actions: [MessageBox.Action.OK],
                    onClose: () => {
                        roteador = this._retornaRoteador();
                        roteador.navTo(nomePaginaDeDetalhes, {detalhesPath: idPokemon});
                    }
                })
            }).catch(error => {
                console.log(error)
            })
        },

        _removerPokemon(indice) {
            const rotaApi = `/pokemons/${indice}`;
            const metodoDoFetch = "DELETE";

            fetch(rotaApi, {
                method: metodoDoFetch
            })
            .then(response => response.json)
            .catch(erro => console.log(erro))
        }
    }
        
});
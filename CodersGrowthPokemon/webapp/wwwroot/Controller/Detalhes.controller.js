sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/m/MessageBox",
    "../Repositorios/PokemonRepository",
    "../Services/ProcessarEventos"
], (Controller, JSONModel, formatter, MessageBox, PokemonRepository, ProcessarEventos) => {
    "use strict"
    const nomeModeloPokemon = "detalhePokemon";
    const paginaDeListagem = "listagem";
    let roteador;

    return Controller.extend("webapp.Controller.Detalhes", {
        formatter: formatter,

        onInit() {
            const rotaDetalhes = "detalhes";
            roteador = this._retornaRoteador();

			roteador.getRoute(rotaDetalhes).attachPatternMatched(this.aoCoincidirRota, this);
        },

        _retornai18n() {
            const modeloi18n = "i18n"
            return this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
        },

        _retornaIdDoPokemon() {
            return this.getView().getModel(nomeModeloPokemon).getProperty("/id");
        },

        _retornaNomeDoPokemon() {
            return this.getView().getModel(nomeModeloPokemon).getProperty("/nome");
        },

        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _carregarPokemon(indice) {
            const paginaNaoEncontrada =  "notFound";
            const roteador = this._retornaRoteador();

            PokemonRepository.obterPokemonPorId(indice)
                .then(response => {
                    if(!response.id) {
                        roteador.navTo(paginaNaoEncontrada, {})
                    } 
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
                })
        },

        _removePokemon(indice) {
            PokemonRepository.removerPokemon(indice);
        },

        aoCoincidirRota(evento) {
            ProcessarEventos.processarEvento(() => {
                const argumentos = "arguments";
                let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)
    
                this._carregarPokemon(indice)
            })
        },

        aoClicarBotaoVoltar() {
            ProcessarEventos.processarEvento(() => {
                roteador = this._retornaRoteador();
                roteador.navTo(paginaDeListagem, {}, true);
            })
        },

        aoClicarBotaoEditar() {
            ProcessarEventos.processarEvento(() => {
                const nomePaginaDeCadastro = "cadastro";
                const nomeParametroId = "/id";
                const parametroId = this.getView().getModel(nomeModeloPokemon).getProperty(nomeParametroId)
                
                roteador = this._retornaRoteador();
                roteador.navTo(nomePaginaDeCadastro, {
                    id: window.encodeURIComponent(parametroId)
                })
            })
        },   

        aoClicarBotaoRemover() {
            ProcessarEventos.processarEvento(() => {
                const i18n = this._retornai18n();
                const nomeDoPokemon = this._retornaNomeDoPokemon();
                const mensagemDeConfirmacao = `Deseja mesmo remover o pokemon ${nomeDoPokemon}`
                const idDoPokemon = this._retornaIdDoPokemon();
                const sim = "Sim";
                const nao = "Não";
                const sucessoAoRemover = "sucessoAoRemover";
                const mensagemDeSucessoAoRemover = i18n.getText(sucessoAoRemover);
    
                MessageBox.information(mensagemDeConfirmacao, {
                    actions: [sim, nao],
                    emphasizedAction: sim,
                    onClose: (acao) => {
                        if (acao === sim) {
                            this._removePokemon(idDoPokemon);
                            MessageBox.success(mensagemDeSucessoAoRemover, {
                                actions: [MessageBox.Action.OK],
                                onClose: () => {
                                    roteador = this._retornaRoteador();
                                    roteador.navTo(paginaDeListagem, {});
                                }
                            })
                        } 
                    }
                });
            })
        },

        aoClicarBotaoVerCard() {
            ProcessarEventos.processarEvento(() => {
                const caminhoCardPokemon = "webapp.View.CardPokemon";
    
                this.pDialog ??= this.loadFragment({
                    name: caminhoCardPokemon
                });
                this.pDialog.then((card) => card.open());
            })
        },

        aoFecharDialog() {
            ProcessarEventos.processarEvento(() => {
                const idCardPokemon = "cardPokemon";
    
                this.byId(idCardPokemon).close();
            })
        }
    })
})
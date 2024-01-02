sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/m/MessageBox",
    "../Repositorios/RepositorioFetch"
], (Controller, JSONModel, formatter, MessageBox, RepositorioFetch) => {
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
            
            RepositorioFetch.obterPokemonPorId(indice)
                .then(response => {
                    if(!response.id) {
                        roteador.navTo(paginaNaoEncontrada, {})
                    } 
                    this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
                })
        },

        _removePokemon(indice) {
            RepositorioFetch.removerPokemon(indice);
        },

        _processarEvento: function(action){
            const tipoDaPromise = "catch",
                       tipoBuscado = "function";
            try {
                    var promise = action();
                    if(promise && typeof(promise[tipoDaPromise]) == tipoBuscado){
                            promise.catch(error => MessageBox.error(error.message));
                    }
            } catch (error) {
                    MessageBox.error(error.message);
            }
        },

        aoCoincidirRota(evento) {
            this._processarEvento(() => {
                const argumentos = "arguments";
                let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)
    
                this._carregarPokemon(indice)
            })
        },

        aoClicarBotaoVoltar() {
            this._processarEvento(() => {
                roteador = this._retornaRoteador();
                roteador.navTo(paginaDeListagem, {}, true);
            })
        },

        aoClicarBotaoEditar() {
            this._processarEvento(() => {
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
            this._processarEvento(() => {
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
            this._processarEvento(() => {
                const caminhoCardPokemon = "webapp.View.CardPokemon";
    
                this.pDialog ??= this.loadFragment({
                    name: caminhoCardPokemon
                });
                this.pDialog.then((card) => card.open());
            })
        },

        aoFecharDialog() {
            this._processarEvento(() => {
                const idCardPokemon = "cardPokemon";
    
                this.byId(idCardPokemon).close();
            })
        }
    })
})
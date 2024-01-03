sap.ui.define([
    "./BaseController",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/m/MessageBox",
    "../Repositorios/PokemonRepository",
    "../Services/ProcessarEventos", 
    "../Services/Mensagens"
], (BaseController, JSONModel, formatter, MessageBox, PokemonRepository, ProcessarEventos, Mensagens) => {
    "use strict"

    const nomeModeloPokemon = "detalhePokemon";
    const paginaDeListagem = "listagem";
    let roteador;
    let _i18n;

    return BaseController.extend("webapp.Controller.Detalhes", {
        formatter: formatter,
        BaseController: BaseController,
        Mensagens: Mensagens,
        
        onInit() {
            const rotaDetalhes = "detalhes";
            
            _i18n = this._retornai18n(),
            roteador = this._retornaRoteador();
			roteador.getRoute(rotaDetalhes).attachPatternMatched(this.aoCoincidirRota, this);
            this._injetaI18nNaClasseDeMensagens(this._i18n)
        },

        _retornaNomeDoPokemon() {
            return this.getView().getModel(nomeModeloPokemon).getProperty("/nome");
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
                const mensagemConfirmacaoRemocao = Mensagens._mensagemDeConfirmacaoAoRemover()
                const sim = Mensagens._sim();
                const nao = Mensagens._nao();
                const mensagemDeSucessoAoRemover = Mensagens._mensagemDeSucessoAoRemover();
                const idDoPokemon = this._retornaIdDoPokemon();
    
                MessageBox.information(mensagemConfirmacaoRemocao, {
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
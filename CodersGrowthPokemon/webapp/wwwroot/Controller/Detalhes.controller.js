sap.ui.define([
    "./BaseController",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "../Repositorios/PokemonRepository",
    "../Services/ProcessarEventos", 
    "../Services/Dialogos"
], (BaseController, JSONModel, formatter, PokemonRepository, ProcessarEventos, Dialogos) => {
    "use strict"

    const nomeModeloPokemon = "detalhePokemon";
    const paginaDeListagem = "listagem";
    let i18n;
    let roteador;

    return BaseController.extend("webapp.Controller.Detalhes", {
        formatter: formatter,
        PokemonRepository: PokemonRepository,
        BaseController: BaseController,
        
        onInit() {
            const rotaDetalhes = "detalhes";
            
            roteador = this._retornaRoteador();
			roteador.getRoute(rotaDetalhes).attachPatternMatched(this.aoCoincidirRota, this);
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

        aoCoincidirRota(evento) {
            ProcessarEventos.processarEvento(() => {
                const argumentos = "arguments";
                let indice = window.decodeURIComponent(evento.getParameter(argumentos).detalhesPath)
                
                i18n = this._retornai18n();
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
            ProcessarEventos.processarEvento(async () => {
                const mensagemConfirmacaoDeRemocao = "cofirmacaoDeRemocao"
                const mensagemSucessoDeRemocao = "sucessoAoRemover"
                const textoDialogoConfirmacaoDeRemocao = i18n.getText(mensagemConfirmacaoDeRemocao);
                const textoDialogoSucessoDeRemocao = i18n.getText(mensagemSucessoDeRemocao);
                
                
                try {
                    const dialogo = await Dialogos._exibirDialogoDeConfirmacao(textoDialogoConfirmacaoDeRemocao, i18n)
                    const sim = "Sim";
                    if(dialogo === sim) {
                        const idDoPokemon = this._retornaIdDoPokemon(this.getView(), nomeModeloPokemon);
                        PokemonRepository.removerPokemon(idDoPokemon);
                        await Dialogos._exibirDialogoDeSucesso(textoDialogoSucessoDeRemocao);
                        roteador = this._retornaRoteador();
                        roteador.navTo(paginaDeListagem, {});
                    }
                } catch(e) {
                    console.log(e)
                }
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
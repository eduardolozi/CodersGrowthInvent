sap.ui.define([
    "./BaseController",
    "../model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel", 
    "../Services/Validacoes",
    "sap/ui/core/date/UI5Date",
    "../Repositorios/PokemonRepository", 
    "../Services/ProcessarEventos", 
    "../Services/Dialogos"
], (BaseController, formatter, History, JSONModel, Validacoes, UI5Date, PokemonRepository, ProcessarEventos, Dialogos) => {
    "use strict"
    const nomeModeloPokemon = "pokemon";
    const campoNome = "/nome";
    const campoApelido = "/apelido";
    const campoNivel = "/nivel";
    const campoAltura = "/altura";
    const campoDataDeCaptura = "/dataDeCaptura";
    const campoTipoPrincipal = "/tipoPrincipal";
    const campoTipoSecundario = "/tipoSecundario";
    const campoShiny = "/shiny";
    const campoFoto = "/foto";
    const idInputNome = "inputNome";
    const idInputApelido = "inputApelido";
    const idInputNivel = "inputNivel";
    const idInputAltura = "inputAltura";
    const idInputDataDeCaptura = "inputDataCaptura";
    const idInputShiny = "inputShiny";
    const idInputTipoPrincipal = "inputTipoPrincipal";
    const idInputTipoSecundario = "inputTipoSecundario";
    const idInputFoto = "inputFoto";
    const stringVazia = "";
    const argumentos = "arguments";
    const mensagemDeErro = []
    const nomeRotaCadastro = "cadastro";
    let roteador;
    let i18n;


    return BaseController.extend("webapp.Controller.Cadastro", {
        formatter: formatter,
        Validacoes: Validacoes,     

        onInit() {
            roteador = this._retornaRoteador()
            roteador.getRoute(nomeRotaCadastro).attachMatched(this._aoCoincidirRota, this);    

            i18n = this._retornai18n()
            this._injetaI18nNaValidcao();
            this._defineDatasLimitesDoCampoDeData()
        },

        _injetaI18nNaValidcao() {
            Validacoes.Validacoes(i18n)
        },

        _defineDatasLimitesDoCampoDeData() {
            const diaMinimo = 27;
            const mesMinimo = 1;
            const anoMinimo = 1996;
            const dataMinima = UI5Date.getInstance(anoMinimo, mesMinimo, diaMinimo)
            const dataMaxima = UI5Date.getInstance()

            this.getView().byId(idInputDataDeCaptura).setMinDate(dataMinima);
            this.getView().byId(idInputDataDeCaptura).setMaxDate(dataMaxima);
        },

        _verificaSeEhCadastroOuAtualizacao() {
            const idPokemon = this._retornaIdDoPokemon(this.getView(), nomeModeloPokemon)

            return (idPokemon) ? idPokemon : undefined;
        },

        _limpaOsCampos() {
            const stringVazia = "";
            const statusDoInputRedefinido = "None";

            this.getView().byId(idInputNome).setValue(stringVazia)
            this.getView().byId(idInputNome).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputApelido).setValue(stringVazia)
            this.getView().byId(idInputApelido).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputNivel).setValue(stringVazia)
            this.getView().byId(idInputNivel).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputAltura).setValue(stringVazia)
            this.getView().byId(idInputAltura).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputDataDeCaptura).setValue(stringVazia)
            this.getView().byId(idInputDataDeCaptura).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputShiny).setSelected(false)
            this.getView().byId(idInputShiny).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputTipoPrincipal).setValue(stringVazia)
            this.getView().byId(idInputTipoPrincipal).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputTipoSecundario).setValue(stringVazia)
            this.getView().byId(idInputTipoSecundario).setValueState(statusDoInputRedefinido)

            this.getView().byId(idInputFoto).setValue(stringVazia)
            this.getView().byId(idInputFoto).setValueState(statusDoInputRedefinido)
        },

        _insereCamposNoModeloPokemon() {
            const modeloPokemon = this._retornaModeloPokemon(this.getView(), nomeModeloPokemon);
 
            return {
                nome: modeloPokemon.getProperty(campoNome),
                apelido: modeloPokemon.getProperty(campoApelido),
                nivel: parseInt(modeloPokemon.getProperty(campoNivel)),
                altura: parseFloat(modeloPokemon.getProperty(campoAltura)),
                dataDeCaptura: modeloPokemon.getProperty(campoDataDeCaptura),
                tipoPrincipal: parseInt(modeloPokemon.getProperty(campoTipoPrincipal)),
                tipoSecundario: (!modeloPokemon.getProperty(campoTipoSecundario)) ? null : parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoSecundario)),
                shiny: (!modeloPokemon.getProperty(campoShiny)) ? false : true,
                foto: (!modeloPokemon.getProperty(campoFoto)) ? null : this.getView().byId(idInputFoto).getValue()
            }
        },

        _salvarPokemon() {
            const mensagemSucessoAoSalvar = "sucessoAoSalvar"
            const textoDialogoSucessoAoSalvar = i18n.getText(mensagemSucessoAoSalvar)
            const novoPokemon = this._insereCamposNoModeloPokemon()

            PokemonRepository.criarPokemon(novoPokemon)
            .then(async response => {
                const nomePaginaDeDetalhes = "detalhes";
                const idPokemon = response.id;
                try {
                    await Dialogos._exibirDialogoDeSucesso(textoDialogoSucessoAoSalvar)
                    roteador = this._retornaRoteador();
                    roteador.navTo(nomePaginaDeDetalhes, {detalhesPath: idPokemon});
                } catch (e) {
                    console.log(e);
                }
            })
        },

        _atualizarPokemon() {
            const mensagemSucessoAoAtualizar = "sucessoAoAtualizar"
            const textoDialogoSucessoAoAtualizar = i18n.getText(mensagemSucessoAoAtualizar)

            const pokemonAtualizado = this._insereCamposNoModeloPokemon()
            pokemonAtualizado.id = this._retornaIdDoPokemon(this.getView(), nomeModeloPokemon);

            PokemonRepository.atualizarPokemon(pokemonAtualizado)
            .then(async () => {
                const nomePaginaDeDetalhes = "detalhes";

                try {
                    await Dialogos._exibirDialogoDeSucesso(textoDialogoSucessoAoAtualizar)
                    roteador = this._retornaRoteador();
                    roteador.navTo(nomePaginaDeDetalhes, {detalhesPath: pokemonAtualizado.id});
                } catch(e) {
                    console.log(e)
                }
                
            })
        },

        _carregarPokemon(indice) {
            const paginaNaoEncontrada =  "notFound";
            const roteador = this._retornaRoteador()

            PokemonRepository.obterPokemonPorId(indice)
            .then(response => {
                if(!response.id) {
                    roteador.navTo(paginaNaoEncontrada, {})
                } 
                this.getView().setModel(new JSONModel(response), nomeModeloPokemon);
            })
        },

        _aoCoincidirRota(evento) {
            ProcessarEventos.processarEvento(() => {
                const idPokemon = evento.getParameter(argumentos).id;

                i18n = this._retornai18n(),
                this._limpaOsCampos()
                if(idPokemon != undefined) this._carregarPokemon(idPokemon)
                else this.getView().setModel(new JSONModel({}), nomeModeloPokemon);
            })
        },

        aoClicarNoBotaoDeVoltar() {
            ProcessarEventos.processarEvento(() => {
                const paginaDeListagem = "listagem";
                const historico = History.getInstance();
                const hashAnterior = historico.getPreviousHash();
                const paginaAnteriorNoHistorico = -1;
                roteador = this._retornaRoteador();
    
                if (hashAnterior !== undefined) {
                    window.history.go(paginaAnteriorNoHistorico);
                } else {
                    roteador.navTo(paginaDeListagem, {}, true);
                }
            })
        },

        _retornaQuantidadeDeCamposComErro() {
            let quantidadeDeErros = 0;
     
            mensagemDeErro.map((mensagem) => {
              if (mensagem !== stringVazia) quantidadeDeErros++;
            });
            return quantidadeDeErros;
          },
     
          _retornaMensagensDeErroDosCamposPreenchidos() {
            return mensagemDeErro.filter((item) => {
                    if (item) return item;
                  });
          },
     
          _criaMensagemDeErro() {
            const mensagemErroCamposVazios = "mensagemPreencherCamposVazios"
            const erroDeCamposVazios = i18n.getText(mensagemErroCamposVazios)
            const errosDeCamposPreenchidos = this._retornaMensagensDeErroDosCamposPreenchidos()
            const quebraDeLinha = "\n";
     
            return Validacoes.verificaCamposVazios(this.getView())
                    ? `${erroDeCamposVazios} ${quebraDeLinha} ${errosDeCamposPreenchidos.join(quebraDeLinha)}`
                    : `${errosDeCamposPreenchidos.join(quebraDeLinha)}`
          },
     
          aoClicarNoBotaoDeSalvar(evento) {
              ProcessarEventos.processarEvento(async () => {
                  const mensagemAoClicarEmSalvar = "mensagemSalvar"
                  const textoDialogoConfirmarCadastro = i18n.getText(mensagemAoClicarEmSalvar)
                 
                  const mensagemDeErroVazia = 0;
                  let quantidadeDeErros = 0;
                //   let errosDeCamposPreenchidos;
                  let verificacaoDeAcao;
     
                  try {
                    const sim = "Sim"
                    const dialogo = await Dialogos._exibirDialogoDeConfirmacao(textoDialogoConfirmarCadastro, i18n)
     
                    if (dialogo === sim) {
                      const camposVazios = Validacoes.verificaCamposVazios(this.getView())
                      quantidadeDeErros = this._retornaQuantidadeDeCamposComErro()
     
                      if (quantidadeDeErros > mensagemDeErroVazia || camposVazios){
                        const erro = this._criaMensagemDeErro()
                        await Dialogos._exibirDialogoDeErro(erro);
                        return;
                      }
     
                      verificacaoDeAcao = this._verificaSeEhCadastroOuAtualizacao()
                      if(!verificacaoDeAcao) this._salvarPokemon(evento);
                      else this._atualizarPokemon(evento)
                    }
                  } catch(e) {
                      console.log(e)
                  }
              })
          },

        aoClicarNoBotaoDeCancelar() {
            ProcessarEventos.processarEvento(async () => {
                const mensagemAoClicarEmCancelarNaAdicao = "mensagemAoClicarEmCancelarNaAdicao"
                const mensagemAoClicarEmCancelarNaAtualizacao = "mensagemAoClicarEmCancelarNaAtualizacao"
                const textoDialogoCancelarAdicao = i18n.getText(mensagemAoClicarEmCancelarNaAdicao)
                const textoDialogoCancelarAtualizacao = i18n.getText(mensagemAoClicarEmCancelarNaAtualizacao)
                const hash = this._retornaRoteador().getHashChanger().getHash();
                const mensagemAoClicarEmCancelar = (hash === nomeRotaCadastro) ?  textoDialogoCancelarAdicao : textoDialogoCancelarAtualizacao;
                const sim = "Sim"

                try {
                    const dialog = await Dialogos._exibirDialogoDeConfirmacao(mensagemAoClicarEmCancelar, i18n)
                    if(dialog === sim) {
                        this.aoClicarNoBotaoDeVoltar();
                        this._limpaOsCampos()
                    }
                } catch(e){
                    console.log(e)
                }
            })
        },

        aoCarregarImagem(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoDoArquivo = 0;
                const idDoDisplayDaFoto = "fotoDoPokemon";
                const parametroDeArquivos = "files";
                const arquivo = evento.getParameters(parametroDeArquivos).files[posicaoDoArquivo];
    
                let leitor = new FileReader();
                leitor.readAsArrayBuffer(arquivo);
    
                leitor.onload = (evt) => {
                    const arrayDeBytes = new Uint8Array(evt.target.result);
                    let stringBinaria = '';
    
                    for (let i = 0; i < arrayDeBytes.byteLength; i++) {
                        stringBinaria += String.fromCharCode(arrayDeBytes[i]);
                    }
    
                    let base64 = window.btoa( stringBinaria );
                    this.getView().byId(idInputFoto).setValue(base64);
                    this.getView().byId(idDoDisplayDaFoto).setSrc(base64);
            
                }
            })
            
        },

        aoMudarCampoNome(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeNome = 0;
                let erroNome = Validacoes.validaCampoNomePreenchido(evento)
                mensagemDeErro[posicaoPropriedadeNome] = (erroNome) ?  erroNome : stringVazia;
            })
        },

        aoDigitarEmCampoNome(evento) {    
            ProcessarEventos.processarEvento(() => {
                Validacoes.validaNomeAoEscrever(evento)
            })
        },

        aoMudarCampoApelido(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeApelido = 1;
                let erroApelido = Validacoes.validaCampoApelidoPreenchido(evento)
                mensagemDeErro[posicaoPropriedadeApelido] = (erroApelido) ?  erroApelido : stringVazia;
            })
        },

        aoMudarCampoNivel(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeNivel = 2;
                let erroNivel = Validacoes.validaCampoNivelPreenchido(evento)
                mensagemDeErro[posicaoPropriedadeNivel] = (erroNivel) ?  erroNivel : stringVazia;
            })
        },

        aoDigitarEmCampoNivel(evento){
            ProcessarEventos.processarEvento(() => {
                Validacoes.validaNivelAoEscrever(evento)
            })
        },

        aoMudarCampoAltura(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeAltura = 3;
                let erroAltura = Validacoes.validaCampoAlturaPreenchido(evento)
                mensagemDeErro[posicaoPropriedadeAltura] = (erroAltura) ?  erroAltura : stringVazia;
            })
        },

        aoMudarCampoDataDeCaptura(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeDataDeCaptura = 4;
                let erroDataDeCaptura = Validacoes.validaCampoDataDeCapturaPreenchido(evento)
                mensagemDeErro[posicaoPropriedadeDataDeCaptura] = (erroDataDeCaptura) ?  erroDataDeCaptura : stringVazia;
            })
        },

        aoMudarCampoTipoPrincipal(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeTipoPrincipal = 5;
                let inputTipoSecundrio = this.byId(idInputTipoSecundario);
                let erroTipoPrincipal = Validacoes.validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundrio)
                mensagemDeErro[posicaoPropriedadeTipoPrincipal] = (erroTipoPrincipal) ?  erroTipoPrincipal : stringVazia;
            })
        },

        aoMudarCampoTipoSecundario(evento) {
            ProcessarEventos.processarEvento(() => {
                const posicaoPropriedadeTipoSecundario = 6;
                let primeiroTipo = this.byId(idInputTipoPrincipal).getSelectedKey();
                let erroTipoSecundario = Validacoes.validaCampoTipoSecundarioPreenchido(evento, primeiroTipo)
                mensagemDeErro[posicaoPropriedadeTipoSecundario] = (erroTipoSecundario) ?  erroTipoSecundario : stringVazia;
            })
        }
    });
})
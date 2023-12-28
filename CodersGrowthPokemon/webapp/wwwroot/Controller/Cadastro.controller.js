sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel", 
    "../Services/Validacoes",
    "sap/ui/core/date/UI5Date"
], (Controller, formatter, History, MessageBox, JSONModel, Validacoes, UI5Date) => {
    "use strict"
    const sim = "Sim";
    const nao = "Não";
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
    const modeloi18n = "i18n"
    const stringVazia = "";
    const mensagemDeErro = []
    let roteador;


    return Controller.extend("webapp.Controller.Cadastro", {
        formatter: formatter,
        Validacoes: Validacoes,
        
        onInit() {
            const nomeRotaCadastro = "cadastro";
            const rota = this.getOwnerComponent().getRouter();


            rota.getRoute(nomeRotaCadastro).attachMatched(this._aoCoincidirRota, this);  
            this.getView().setModel(new JSONModel({}), nomeModeloPokemon);
            this._injetaI18nNaValidcao();
            this._defineDatasLimitesDoCampoDeData()
        },

        _retornai18n() {
            return this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
        },

        _retornaRoteador() {
            return this.getOwnerComponent().getRouter();
        },

        _injetaI18nNaValidcao() {
            const i18n = this._retornai18n()
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

        _salvarPokemon() {
            const urlFetch = "/pokemons/";
            const metodoDoFetch = "POST";

            const novoPokemon = {
                nome: this.getView().getModel(nomeModeloPokemon).getProperty(campoNome),
                apelido: this.getView().getModel(nomeModeloPokemon).getProperty(campoApelido),
                nivel: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoNivel)),
                altura: parseFloat(this.getView().getModel(nomeModeloPokemon).getProperty(campoAltura)),
                dataDeCaptura: this.getView().getModel(nomeModeloPokemon).getProperty(campoDataDeCaptura),
                tipoPrincipal: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoPrincipal)),
                tipoSecundario: (this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoSecundario) === undefined) ? null : parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoSecundario)),
                shiny: (this.getView().getModel(nomeModeloPokemon).getProperty(campoShiny) === undefined) ? true : false,
                foto: (this.getView().getModel(nomeModeloPokemon).getProperty(campoFoto) === undefined) ? null : this.getView().byId(idInputFoto).getValue()
            }

            fetch(urlFetch, {
                method: metodoDoFetch,
                body: JSON.stringify(novoPokemon),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }).then(response => {
                return response.json();
            }).then(data => {
                const nomePaginaDeDetalhes = "detalhes";
                const idPokemon = data.id;
                roteador = this._retornaRoteador();

                roteador.navTo(nomePaginaDeDetalhes, {detalhesPath: idPokemon});
            }).catch(error => {
                console.log(error)
            })
        },

        _aoCoincidirRota(evt) {
            this._limpaOsCampos()
        },

        aoClicarNoBotaoDeVoltar() {
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
        },

        aoClicarNoBotaoDeSalvar(evento) {
            const i18n = this._retornai18n();
            const mensagemDeConfirmacao = "mensagemSalvar";
            const mensagemAoClicarEmSalvar = i18n.getText(mensagemDeConfirmacao);
            const mensagemPreencherCamposVazios = "mensagemPreencherCamposVazios"
            const mensagemErroCamposVazios = i18n.getText(mensagemPreencherCamposVazios)
            const mensagemDeErroVazia = 0;
            const quebraDeLinha = "\n";
            let quantidadeDeErros = 0;
            let mensagemDeErroNaTela;
            
            MessageBox.information(mensagemAoClicarEmSalvar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        if(Validacoes.verificaCamposVazios(this.getView()) === true) {
                            MessageBox.error(mensagemErroCamposVazios);
                            return;
                        };
                        mensagemDeErro.map(mensagem => {
                            if(mensagem !== stringVazia)  quantidadeDeErros++;
                        })
                        const verificacaoDeErros = quantidadeDeErros;
                        if(verificacaoDeErros === mensagemDeErroVazia) {
                            this._salvarPokemon(evento);
                        } else {
                            mensagemDeErroNaTela = mensagemDeErro.filter((item) => {
                                if(item!= undefined) return item;
                            })
                            MessageBox.error(mensagemDeErroNaTela.join(quebraDeLinha))
                        }
                    } 
                }
            });
        },

        aoClicarNoBotaoDeCancelar() {
            const mensagemDeCancelar = "mensagemAoClicarEmCancelar";
            const i18n = this._retornai18n();
            const mensagemAoClicarEmCancelar = i18n.getText(mensagemDeCancelar);

            MessageBox.alert(mensagemAoClicarEmCancelar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        this.aoClicarNoBotaoDeVoltar();
                        this._limpaOsCampos()
                    } 
                }
            });
        },

        aoCarregarImagem(evento) {
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
        },

        aoMudarCampoNome(evento) {
            const posicaoPropriedadeNome = 0;
            let erroNome = Validacoes.validaCampoNomePreenchido(evento)
            mensagemDeErro[posicaoPropriedadeNome] = (erroNome) ?  erroNome : stringVazia;
        },

        aoDigitarEmCampoNome(evento) {    
            Validacoes.validaNomeAoEscrever(evento)
        },

        aoMudarCampoApelido(evento) {
            const posicaoPropriedadeApelido = 1;
            let erroApelido = Validacoes.validaCampoApelidoPreenchido(evento)
            mensagemDeErro[posicaoPropriedadeApelido] = (erroApelido) ?  erroApelido : stringVazia;
        },

        aoMudarCampoNivel(evento) {
            const posicaoPropriedadeNivel = 2;
            let erroNivel = Validacoes.validaCampoNivelPreenchido(evento)
            mensagemDeErro[posicaoPropriedadeNivel] = (erroNivel) ?  erroNivel : stringVazia;
        },

        aoDigitarEmCampoNivel(evento){
            Validacoes.validaNivelAoEscrever(evento)
        },

        aoMudarCampoAltura(evento) {
            const posicaoPropriedadeAltura = 3;
            let erroAltura = Validacoes.validaCampoAlturaPreenchido(evento)
            mensagemDeErro[posicaoPropriedadeAltura] = (erroAltura) ?  erroAltura : stringVazia;
        },

        aoMudarCampoDataDeCaptura(evento) {
            const posicaoPropriedadeDataDeCaptura = 4;
            let erroDataDeCaptura = Validacoes.validaCampoDataDeCapturaPreenchido(evento)
            mensagemDeErro[posicaoPropriedadeDataDeCaptura] = (erroDataDeCaptura) ?  erroDataDeCaptura : stringVazia;
        },

        aoMudarCampoTipoPrincipal(evento) {
            const posicaoPropriedadeTipoPrincipal = 5;
            let inputTipoSecundrio = this.byId(idInputTipoSecundario);
            let erroTipoPrincipal = Validacoes.validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundrio)
            mensagemDeErro[posicaoPropriedadeTipoPrincipal] = (erroTipoPrincipal) ?  erroTipoPrincipal : stringVazia;
        },

        aoMudarCampoTipoSecundario(evento) {
            const posicaoPropriedadeTipoSecundario = 6;
            let primeiroTipo = this.byId(idInputTipoPrincipal).getSelectedKey();
            let erroTipoSecundario = Validacoes.validaCampoTipoSecundarioPreenchido(evento, primeiroTipo)
            mensagemDeErro[posicaoPropriedadeTipoSecundario] = (erroTipoSecundario) ?  erroTipoSecundario : stringVazia;
        }
    });
})
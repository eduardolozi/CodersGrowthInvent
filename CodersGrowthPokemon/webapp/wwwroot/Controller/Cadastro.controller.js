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
    const idInputFoto = "inputFoto";
    const campoNome = "/nome";
    const campoApelido = "/apelido";
    const campoNivel = "/nivel";
    const campoAltura = "/altura";
    const campoDataDeCaptura = "/dataDeCaptura";
    const campoTipoPrincipal = "/tipoPrincipal";
    const campoTipoSecundario = "/tipoSecundario";
    const campoShiny = "/shiny";
    const campoFoto = "/foto";
    let mensagemDeErro = [];
    // const i18n = this.getView().getModel("i18n").getResourceBundle();


    return Controller.extend("webapp.Controller.Cadastro", {
        formatter: formatter,
        Validacoes: Validacoes,

        onInit() {
            this.getView().setModel(new JSONModel({}), nomeModeloPokemon);
            this.byId("inputDataCaptura").setMinDate(UI5Date.getInstance(1996, 1, 27));
			this.byId("inputDataCaptura").setMaxDate(UI5Date.getInstance());
        },

        _salvarPokemon() {
            const urlFetch = "/pokemons/";

            const novoPokemon = {
                nome: this.getView().getModel(nomeModeloPokemon).getProperty(campoNome),
                apelido: this.getView().getModel(nomeModeloPokemon).getProperty(campoApelido),
                nivel: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoNivel)),
                altura: parseFloat(this.getView().getModel(nomeModeloPokemon).getProperty(campoAltura)),
                dataDeCaptura: this.getView().getModel(nomeModeloPokemon).getProperty(campoDataDeCaptura),
                tipoPrincipal: parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoPrincipal)),
                tipoSecundario: (this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoSecundario) === undefined) ? null : parseInt(this.getView().getModel(nomeModeloPokemon).getProperty(campoTipoSecundario)),
                shiny: (this.getView().getModel(nomeModeloPokemon).getProperty(campoShiny) === undefined) ? false : true,
                foto: (this.getView().getModel(nomeModeloPokemon).getProperty(campoFoto) === undefined) ? null : this.getView().byId(idInputFoto).getValue()
            }

            console.log(novoPokemon.tipoPrincipal)

            fetch(urlFetch, {
                method: "POST",
                body: JSON.stringify(novoPokemon),
                headers: {"Content-type": "application/json; charset=UTF-8"}
            }).then(response => {
                return response.json();
            }).then(data => {
                const nomePaginaDeDetalhes = "detalhes";
                const idPokemon = data.id;
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(nomePaginaDeDetalhes, {detalhesPath: idPokemon});
            }).catch(error => {
                console.log(error)
            })
        },

        aoClicarNoBotaoDeVoltar() {
            const paginaDeListagem = "listagem";
            const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();
            const paginaAnteriorNoHistorico = -1;

            if (hashAnterior !== undefined) {
				window.history.go(paginaAnteriorNoHistorico);
			} else {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo(paginaDeListagem, {}, true);
			}
            
        },

        aoClicarNoBotaoDeSalvar(evento) {
            const mensagemAoClicarEmSalvar = "Salvar o Pokémon criado?";
            let mensagemDeValidacao;
            
            MessageBox.information(mensagemAoClicarEmSalvar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        debugger
                        if(mensagemDeErro.length!=0) {
                            this._salvarPokemon(evento);
                        } else {
                            
                        }
                    } 
                }
            });
        },

        aoClicarNoBotaoDeCancelar(evento) {
            const mensagemAoClicarEmCancelar = "Cancelar a criação do Pokémon?"

            MessageBox.alert(mensagemAoClicarEmCancelar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        this.aoClicarNoBotaoDeVoltar();
                    } 
                }
            });
        },

        aoCarregarImagem(evento) {
            const posicaoDoArquivo = 0;
            const idDoDisplayDaFoto = "fotoDoPokemon";
            const parametroDeArquivos = "files";

            var arquivo = evento.getParameters(parametroDeArquivos).files[posicaoDoArquivo];
            var leitor = new FileReader();
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
            let erroNome = Validacoes.validaCampoNomePreenchido(evento)
            mensagemDeErro[0] = erroNome;
        },

        aoDigitarEmCampoNome(evento) {    
            Validacoes.validaNomeAoEscrever(evento)
        },

        aoMudarCampoApelido(evento) {
            let erroApelido = Validacoes.validaCampoApelidoPreenchido(evento)
            mensagemDeErro[1] = erroApelido;
        },

        aoMudarCampoNivel(evento) {
            let erroNivel = Validacoes.validaCampoNivelPreenchido(evento)
            mensagemDeErro[2] = erroNivel;
        },

        aoDigitarEmCampoNivel(evento){
            Validacoes.validaNivelAoEscrever(evento)
        },

        aoMudarCampoAltura(evento) {
            let erroAltura = Validacoes.validaCampoAlturaPreenchido(evento)
            mensagemDeErro[3] = erroAltura;
        },

        aoMudarCampoDataDeCaptura(evento) {
            let erroDataDeCaptura = Validacoes.validaCampoDataDeCapturaPreenchido(evento)
            mensagemDeErro[4] = erroDataDeCaptura;
        },

        aoMudarCampoTipoPrincipal(evento) {
            let inputTipoSecundrio = this.byId("inputTipoSecundario");
            let erroTipoPrincipal = Validacoes.validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundrio)
            mensagemDeErro[5] = erroTipoPrincipal;
        },

        aoMudarCampoTipoSecundario(evento) {
            let primeiroTipo = this.byId("inputTipoPrincipal").getSelectedKey();
            let erroTipoSecundario = Validacoes.validaCampoTipoSecundarioPreenchido(evento, primeiroTipo)
            mensagemDeErro[6] = erroTipoSecundario;
        },

        aoMudarCampoFoto(evento) {
            let erroFoto = Validacoes.validaCampoFotoPreenchido(evento);
            mensagemDeErro[7] = erroFoto;
        }
    });
})
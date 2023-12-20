sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], (Controller, formatter, History, MessageBox, JSONModel) => {
    "use strict"
    const sim = "Sim";
    const nao = "Não";
    const nomeModeloPokemon = "pokemon";
    const idInputFoto = "inputFoto";


    return Controller.extend("webapp.Controller.Cadastro", {
        formatter: formatter,

        onInit() {
            this.getView().setModel(new JSONModel({}), nomeModeloPokemon);
        },

        _salvarPokemon(oEvent) {
            const urlFetch = "/pokemons/";
            const campoNome = "/nome";
            const campoApelido = "/apelido";
            const campoNivel = "/nivel";
            const campoAltura = "/altura";
            const campoDataDeCaptura = "/dataDeCaptura";
            const campoTipoPrincipal = "/tipoPrincipal";
            const campoTipoSecundario = "/tipoSecundario";
            const campoShiny = "/shiny";
            const campoFoto = "/foto";

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

        aoClicarNoBotaoDeVoltar(oEvent) {
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

        aoClicarNoBotaoDeSalvar(oEvent) {
            const mensagemAoClicarEmSalvar = "Salvar o Pokémon criado?";

            MessageBox.information(mensagemAoClicarEmSalvar, {
                actions: [sim, nao],
                emphasizedAction: sim,
                onClose: (acao) => {
                    if (acao === sim) {
                        this._salvarPokemon(oEvent);
                    } 
                }
            });
        },

        aoClicarNoBotaoDeCancelar(oEvent) {
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

        aoCarregarImagem(oEvent) {
            const posicaoDoArquivo = 0;
            const idDoDisplayDaFoto = "fotoDoPokemon";
            const parametroDeArquivos = "files";

            var arquivo = oEvent.getParameters(parametroDeArquivos).files[posicaoDoArquivo];
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
        }
    });
})
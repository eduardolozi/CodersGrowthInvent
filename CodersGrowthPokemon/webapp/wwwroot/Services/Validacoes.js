sap.ui.define([
], () => {
"use strict";
    var _i18n; 
    let idInputNome = "inputNome";
    let idInputApelido = "inputApelido";
    let idInputNivel = "inputNivel";
    let idInputAltura = "inputAltura";
    let idInputDataDeCaptura = "inputDataCaptura";
    let idInputTipoPrincipal = "inputTipoPrincipal";
    const erro = "Error";
    const sucesso = "Success"
    return {
        Validacoes(i18n) {
            _i18n = i18n;
        },

        verificaCamposVazios(view) {
            let camposVazios = [
                view.byId(idInputNome),
                view.byId(idInputApelido),
                view.byId(idInputNivel),
                view.byId(idInputAltura),
                view.byId(idInputDataDeCaptura),
                view.byId(idInputTipoPrincipal)
            ]
            const mensagemCampoVazio = "Este campo não pode ser vazio!"
            let qtdCamposVazios = 0;
            
            camposVazios.map((campo) => {
                if(!campo.getValue()) {
                    qtdCamposVazios++;
                    campo.setValueState("Error");
                    campo.setValueStateText(mensagemCampoVazio);
                }
            });

            if(qtdCamposVazios > 0) return true;
        },

        validaCampoNomePreenchido(evento) {
            const tamanhoMinimo = 3;
            const mensagemDeErro = _i18n.getText("campoNomeTamanhoMinimo");

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue().length < tamanhoMinimo ) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro);
            }
        },

        validaNomeAoEscrever(evento) {
            const regexNaoPermitido = /[\d!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/
            const stringVazia = "";
            let valorDigitado = evento.getParameter('value');
            
            
            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        }, 

        validaCampoApelidoPreenchido(evento) {
            const mensagemDeErro = _i18n.getText("campoApelidoTamanhoMinimo");
            evento.getSource().setValueState("Success");
            if(evento.getSource().getValue().length < 1) {
                evento.getSource().setValueState("Error");
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro);
            }
        },

        validaCampoNivelPreenchido(evento) {
            const nivelMinimo = 1;
            const nivelMaximo = 100;
            const mensagemDeErro = _i18n.getText("campoNivelNumeroInvalido")

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue() < nivelMinimo || evento.getSource().getValue() > nivelMaximo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro)
            }
        },

        validaNivelAoEscrever(evento) {
            const regexNaoPermitido = /[\D!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/;
            const stringVazia = "";
            let valorDigitado = evento.getParameter('value');

            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        },

        validaCampoAlturaPreenchido(evento) {
            const alturaMinima = 0;
            const alturaMaxima = 7;
            const mensagemDeErro = _i18n.getText("campoAlturaNumeroInvalido")
            let valor = parseFloat(evento.getSource().getValue())
            
            evento.getSource().setValueState(sucesso);
            if(valor <= alturaMinima || valor >= alturaMaxima) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro)
            }
        },

        validaCampoDataDeCapturaPreenchido(evento) {
            let valorValido = evento.getParameter("valid");
            const mensagemDeErro = _i18n.getText("campoDataDeCapturaInvalida");

            evento.getSource().setValueState(sucesso);
            if(!valorValido) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return (mensagemDeErro)
            }
        },

        validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundario) {
            let chaveSelecionada = evento.getSource().getSelectedKey();
            let chaveSelecionadaInt = (chaveSelecionada === "") ? 0 : parseInt(chaveSelecionada);
            let segundoTipo = parseInt(inputTipoSecundario.getSelectedKey());
            let primeiraChave = 1
            let ultimaChave = 17;
            const mensagemDeErro = _i18n.getText("campoTipoPrincipalChaveInvalida")
            const mensagemTiposRepetidos = _i18n.getText("mensagemTiposRepetidos")

            evento.getSource().setValueState(sucesso);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro) 
            }

            if(!isNaN(segundoTipo) && chaveSelecionadaInt != segundoTipo) inputTipoSecundario.setValueState(sucesso);
            
            if(!isNaN(segundoTipo) && chaveSelecionadaInt === segundoTipo) {
                inputTipoSecundario.setValueState(erro);
                inputTipoSecundario.setValueStateText(mensagemTiposRepetidos);
            }

        },
        
        validaCampoTipoSecundarioPreenchido(evento, chaveDoTipoPrincipal) {
            let chaveSelecionada = evento.getSource().getSelectedKey()
            let primeiroTipo = parseInt(chaveDoTipoPrincipal)
            let chaveSelecionadaInt = (chaveSelecionada === "") ? 0 : parseInt(chaveSelecionada);
            const mensagemDeErro = _i18n.getText("campoTipoSecundarioChaveInvalida")
            let primeiraChave = 1
            let ultimaChave = 17;
            const mensagemTiposRepetidos = _i18n.getText("campoTipoSecundarioTiposRepetidos")

            evento.getSource().setValueState(sucesso);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {                
                let valorDoCampo = evento.getParameter("value");
                if(valorDoCampo.length != 0) {
                    evento.getSource().setValueState(erro)
                    evento.getSource().setValueStateText(mensagemDeErro);
                    return(mensagemDeErro)
                }
                else evento.getSource().setValueState(sucesso);
            }
            
            if (chaveSelecionadaInt === primeiroTipo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemTiposRepetidos);
                return(mensagemTiposRepetidos);
            }
        },

        validaCampoFotoPreenchido(evento) {
            let arquivo = evento.getSource().getValue();
            console.log(arquivo)
            evento.getSource().setValueState(sucesso);
        }
    }
})

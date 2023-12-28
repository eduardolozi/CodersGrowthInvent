sap.ui.define([
], () => {
"use strict";
    const idInputNome = "inputNome";
    const idInputApelido = "inputApelido";
    const idInputNivel = "inputNivel";
    const idInputAltura = "inputAltura";
    const idInputDataDeCaptura = "inputDataCaptura";
    const idInputTipoPrincipal = "inputTipoPrincipal";
    const erro = "Error";
    const sucesso = "Success"
    const valor = "value"
    const campoSemSelecionar = 0;
    const stringVazia = ""
    let _i18n; 
    
    return {
        Validacoes(i18n) {
            _i18n = i18n;
        },

        verificaCamposVazios(view) {
            const mensagemDeErroCampoVazio = "campoVazio"
            const mensagemCampoVazio = _i18n.getText(mensagemDeErroCampoVazio)
            const maximoDeCamposObrigatoriosVazios = 0;
            let qtdCamposVazios = 0;
            let camposVazios = [
                view.byId(idInputNome),
                view.byId(idInputApelido),
                view.byId(idInputNivel),
                view.byId(idInputAltura),
                view.byId(idInputDataDeCaptura),
                view.byId(idInputTipoPrincipal)
            ]
            
            camposVazios.map((campo) => {
                if(!campo.getValue()) {
                    qtdCamposVazios++;
                    campo.setValueState(erro);
                    campo.setValueStateText(mensagemCampoVazio);
                }
            });

            if(qtdCamposVazios > maximoDeCamposObrigatoriosVazios) return true;
            return false;
        },

        validaCampoNomePreenchido(evento) {
            const mensagemNomeTamanhoMinimo = "campoNomeTamanhoMinimo"
            const tamanhoMinimo = 3;
            const mensagemDeErro = _i18n.getText(mensagemNomeTamanhoMinimo);

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue().length < tamanhoMinimo ) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro);
            }
        },

        validaNomeAoEscrever(evento) {
            const regexNaoPermitido = /[\d!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/
            let valorDigitado = evento.getParameter(valor);
            
            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        }, 

        validaCampoApelidoPreenchido(evento) {
            const mensagemApelidoTamanhoMinimo = "campoApelidoTamanhoMinimo"
            const mensagemDeErro = _i18n.getText(mensagemApelidoTamanhoMinimo);
            const tamanhoDeApelidoMinimo = 1;

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue().length < tamanhoDeApelidoMinimo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro);
            }
        },

        validaCampoNivelPreenchido(evento) {
            const nivelMinimo = 1;
            const nivelMaximo = 100;
            const mensagemNivelNumeroInvalido = "campoNivelNumeroInvalido"
            const mensagemDeErro = _i18n.getText(mensagemNivelNumeroInvalido)

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue() < nivelMinimo || evento.getSource().getValue() > nivelMaximo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro)
            }
        },

        validaNivelAoEscrever(evento) {
            const regexNaoPermitido = /[\D!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/;
            let valorDigitado = evento.getParameter(valor);

            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        },

        validaCampoAlturaPreenchido(evento) {
            const alturaMinima = 0;
            const alturaMaxima = 7;
            const mensagemAlturaNumeroInvalido = "campoAlturaNumeroInvalido";
            const mensagemDeErro = _i18n.getText(mensagemAlturaNumeroInvalido)
            let valor = parseFloat(evento.getSource().getValue())
            
            evento.getSource().setValueState(sucesso);
            if(valor <= alturaMinima || valor >= alturaMaxima) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return(mensagemDeErro)
            }
        },

        validaCampoDataDeCapturaPreenchido(evento) {
            const valido = "valid"
            const valorValido = evento.getParameter(valido);
            const mensagemDataCapturaInvalida = "campoDataDeCapturaInvalida";
            const mensagemDeErro = _i18n.getText(mensagemDataCapturaInvalida);

            evento.getSource().setValueState(sucesso);
            if(!valorValido) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErro);
                return (mensagemDeErro)
            }
        },

        validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundario) {
            const chaveSelecionada = evento.getSource().getSelectedKey();
            const chaveSelecionadaInt = (chaveSelecionada === stringVazia) ? campoSemSelecionar : parseInt(chaveSelecionada);
            const segundoTipo = parseInt(inputTipoSecundario.getSelectedKey());
            const primeiraChave = 1
            const ultimaChave = 17;
            const mensagemTipoPrincipalInvalido = "campoTipoPrincipalChaveInvalida"
            const mensagemErroTiposRepetidos = "mensagemTiposRepetidos"
            const mensagemDeErro = _i18n.getText(mensagemTipoPrincipalInvalido)
            const mensagemTiposRepetidos = _i18n.getText(mensagemErroTiposRepetidos)

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
            const chaveSelecionada = evento.getSource().getSelectedKey()
            const primeiroTipo = parseInt(chaveDoTipoPrincipal)
            const chaveSelecionadaInt = (chaveSelecionada === stringVazia) ? campoSemSelecionar : parseInt(chaveSelecionada);
            const mensagemTipoSecundarioInvalido = "campoTipoSecundarioChaveInvalida"
            const mensagemDeErro = _i18n.getText(mensagemTipoSecundarioInvalido)
            const primeiraChave = 1
            const ultimaChave = 17;
            const mensagemTipoSecundarioIgualAoPrincipal = "campoTipoSecundarioTiposRepetidos"
            const mensagemTiposRepetidos = _i18n.getText(mensagemTipoSecundarioIgualAoPrincipal)
            const valorDoCampo = evento.getParameter(valor);

            evento.getSource().setValueState(sucesso);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {                
                if(valorDoCampo.length != campoSemSelecionar) {
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
        }
    }
})

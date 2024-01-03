sap.ui.define([
    "./Mensagens"
], (Mensagens) => {
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
    let _i18n
    
    return {
        Mensagens: Mensagens,

        Validacoes(i18n) {
            _i18n = i18n;
            this._injetaI18nNaClasseDeMensagens(_i18n)
        },

        _injetaI18nNaClasseDeMensagens(_i18n) {
            Mensagens.Mensagens(_i18n);
        },

        verificaCamposVazios(view) {
            const mensagemDeErroCamposVazios = Mensagens._mensagemErroCamposVazios();
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
                    campo.setValueStateText(mensagemDeErroCamposVazios);
                }
            });

            if(qtdCamposVazios > maximoDeCamposObrigatoriosVazios) return true;
            return false;
        },

        validaCampoNomePreenchido(evento) {
            const mensagemDeErroNome = Mensagens._mensagemDeErroNomeTamanhoMinimo()
            const tamanhoMinimo = 3;

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue().length < tamanhoMinimo ) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroNome);
                return(mensagemDeErroNome);
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
            const mensagemDeErroApelido = Mensagens._mensagemDeErroApelidoTamanhoMinimo()
            const tamanhoDeApelidoMinimo = 1;

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue().length < tamanhoDeApelidoMinimo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroApelido);
                return(mensagemDeErroApelido);
            }
        },

        validaCampoNivelPreenchido(evento) {
            const mensagemDeErroNivel = Mensagens._mensagemDeErroNivelInvalido()
            const nivelMinimo = 1;
            const nivelMaximo = 100;

            evento.getSource().setValueState(sucesso);
            if(evento.getSource().getValue() < nivelMinimo || evento.getSource().getValue() > nivelMaximo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroNivel);
                return(mensagemDeErroNivel)
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
            const mensagemDeErroAltura = Mensagens._mensagemDeErroAlturaNumeroInvalido()
            const alturaMinima = 0;
            const alturaMaxima = 7;
            let valor = parseFloat(evento.getSource().getValue())
            
            evento.getSource().setValueState(sucesso);
            if(valor <= alturaMinima || valor >= alturaMaxima) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroAltura);
                return(mensagemDeErroAltura)
            }
        },

        validaCampoDataDeCapturaPreenchido(evento) {
            const mensagemDeErroDataCaptura = Mensagens._mensagemDeErroDaraCapturaInvalida()
            const valido = "valid"
            const valorValido = evento.getParameter(valido);

            evento.getSource().setValueState(sucesso);
            if(!valorValido) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroDataCaptura);
                return (mensagemDeErroDataCaptura)
            }
        },

        validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundario) {
            const mensagemDeErroTipoPrincipal = Mensagens._mensagemDeErroTipoPrincipalInvalido()
            const mensagemDeErroTiposIguais = Mensagens._mensagemDeErroTiposRepetidos()
            const chaveSelecionada = evento.getSource().getSelectedKey();
            const chaveSelecionadaInt = (chaveSelecionada === stringVazia) ? campoSemSelecionar : parseInt(chaveSelecionada);
            const segundoTipo = parseInt(inputTipoSecundario.getSelectedKey());
            const primeiraChave = 1
            const ultimaChave = 17;

            evento.getSource().setValueState(sucesso);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroTipoPrincipal);
                return(mensagemDeErroTipoPrincipal) 
            }

            if(!isNaN(segundoTipo) && chaveSelecionadaInt != segundoTipo) inputTipoSecundario.setValueState(sucesso);
            
            if(!isNaN(segundoTipo) && chaveSelecionadaInt === segundoTipo) {
                inputTipoSecundario.setValueState(erro);
                inputTipoSecundario.setValueStateText(mensagemDeErroTiposIguais);
            }

        },
        
        validaCampoTipoSecundarioPreenchido(evento, chaveDoTipoPrincipal) {
            const mensagemDeErroTipoSecundario = Mensagens._mensagemDeErroTipoSecundarioInvalido()
            const mensagemDeErroTiposIguais = Mensagens._mensagemDeErroTiposRepetidos()
            const chaveSelecionada = evento.getSource().getSelectedKey()
            const primeiroTipo = parseInt(chaveDoTipoPrincipal)
            const chaveSelecionadaInt = (chaveSelecionada === stringVazia) ? campoSemSelecionar : parseInt(chaveSelecionada);
            const primeiraChave = 1
            const ultimaChave = 17;
            const valorDoCampo = evento.getParameter(valor);

            evento.getSource().setValueState(sucesso);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {                
                if(valorDoCampo.length != campoSemSelecionar) {
                    evento.getSource().setValueState(erro)
                    evento.getSource().setValueStateText(mensagemDeErroTipoSecundario);
                    return(mensagemDeErroTipoSecundario)
                }
                else evento.getSource().setValueState(sucesso);
            }
            
            if (chaveSelecionadaInt === primeiroTipo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroTiposIguais);
                return(mensagemDeErroTiposIguais);
            }
        }
    }
})

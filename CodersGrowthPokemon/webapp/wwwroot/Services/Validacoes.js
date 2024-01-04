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
    let _i18n
    
    return {
        Validacoes(i18n) {
            _i18n = i18n;
        },

        _retornaValorDoCampo(evento) {
            return evento.getSource().getValue();
        },

        verificaCamposVazios(view) {
            const erroCampoVazio = "mensagemPreencherCamposVazios";
            const mensagemDeErroCamposVazios = _i18n.getText(erroCampoVazio)
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
            const erroCampoNome = "campoNomeTamanhoMinimo"
            const mensagemDeErroNome = _i18n.getText(erroCampoNome)
            const tamanhoMinimo = 3;
            let nome = this._retornaValorDoCampo(evento)
            nome = nome.trim()

            evento.getSource().setValueState(sucesso);
            if(nome.length < tamanhoMinimo ) {
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
            const erroCampoApelido = "campoApelidoTamanhoMinimo"
            const mensagemDeErroApelido = _i18n.getText(erroCampoApelido)
            const tamanhoDeApelidoMinimo = 1;
            let apelido = this._retornaValorDoCampo(evento);
            apelido = apelido.trim()

            evento.getSource().setValueState(sucesso);
            if(apelido.length < tamanhoDeApelidoMinimo) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroApelido);
                return(mensagemDeErroApelido);
            }
        },

        validaCampoNivelPreenchido(evento) {
            const erroCampoNivel = "campoNivelNumeroInvalido"
            const mensagemDeErroNivel = _i18n.getText(erroCampoNivel)
            const nivelMinimo = 1;
            const nivelMaximo = 100;
            let nivel = this._retornaValorDoCampo(evento)

            evento.getSource().setValueState(sucesso);
            if(nivel < nivelMinimo || nivel > nivelMaximo) {
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
            const erroCampoAltura = "campoAlturaNumeroInvalido"
            const mensagemDeErroAltura = _i18n.getText(erroCampoAltura)
            const alturaMinima = 0;
            const alturaMaxima = 7;
            let altura = parseFloat(this._retornaValorDoCampo(evento))
            
            evento.getSource().setValueState(sucesso);
            if(altura <= alturaMinima || altura >= alturaMaxima) {
                evento.getSource().setValueState(erro);
                evento.getSource().setValueStateText(mensagemDeErroAltura);
                return(mensagemDeErroAltura)
            }
        },

        validaCampoDataDeCapturaPreenchido(evento) {
            const erroCampoData = "campoDataDeCapturaInvalida"
            const mensagemDeErroDataCaptura = _i18n.getText(erroCampoData)
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
            const erroCampoTipoPrincipal = "campoTipoPrincipalChaveInvalida"
            const erroTiposIguais = "campoTipoSecundarioTiposRepetidos"
            const mensagemDeErroTipoPrincipal = _i18n.getText(erroCampoTipoPrincipal)
            const mensagemDeErroTiposIguais = _i18n.getText(erroTiposIguais)
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
            const erroCampoTipoSecundario = "campoTipoSecundarioChaveInvalida"
            const erroTiposIguais = "campoTipoSecundarioTiposRepetidos"
            const mensagemDeErroTipoSecundario = _i18n.getText(erroCampoTipoSecundario)
            const mensagemDeErroTiposIguais = _i18n.getText(erroTiposIguais)
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

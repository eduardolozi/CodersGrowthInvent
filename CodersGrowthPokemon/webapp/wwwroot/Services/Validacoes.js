sap.ui.define([
], () => {
"use strict";
    return {

        validaCampoNomePreenchido(evento) {
            const tamanhoMinimo = 3;

            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            
            if(evento.getSource().getValue().length < tamanhoMinimo ) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo precisa ter no mínimo 3 letras!");
                return("NOME: Este campo precisa ter no mínimo 3 letras!\n");
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
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(evento.getSource().getValue().length < 1) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo não pode ser vazio!");
                return("APELIDO: Este campo não pode ser vazio!\n");
            }
        },

        validaCampoNivelPreenchido(evento) {
            const nivelMinimo = 1;
            const nivelMaximo = 100;

            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(evento.getSource().getValue() < nivelMinimo || evento.getSource().getValue() > nivelMaximo) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo deve ser um número inteiro entre 1 e 100!");
                return("NÍVEL: Este campo deve ser um número inteiro entre 1 e 100!\n")
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
            let valor = parseFloat(evento.getSource().getValue())
            
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(valor <= alturaMinima || valor >= alturaMaxima) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo deve ser um número entre 0.01 e 6.99!");
                return("ALTURA: Este campo deve ser um número entre 0.01 e 6.99!\n")
            }
        },

        validaCampoDataDeCapturaPreenchido(evento) {
            let valorValido = evento.getParameter("valid");
            let dataAtual = new Date();
            let diaAtual = dataAtual.getUTCDate();
            let mesAtual = dataAtual.getUTCMonth() + 1;
            let anoAtual = dataAtual.getUTCFullYear();

            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(!valorValido) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText(`Este campo deve ter uma data entre 27/02/1996 e ${diaAtual}/${mesAtual}/${anoAtual}!`);
                return (`DATA DE CAPTURA: Este campo deve ter uma data entre 27/02/1996 e ${diaAtual}/${mesAtual}/${anoAtual}!\n`)
            }
        },

        validaCampoTipoPrincipalPreenchido(evento, inputTipoSecundario) {
            let chaveSelecionada = evento.getSource().getSelectedKey();
            let chaveSelecionadaInt = (chaveSelecionada === "") ? 0 : parseInt(chaveSelecionada);
            let segundoTipo = parseInt(inputTipoSecundario.getSelectedKey());
            let primeiraChave = 1;
            let ultimaChave = 17;

            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Selecione um tipo existente!");
                return("TIPO PRINCIPAL: Selecione um tipo existente!\n")
            }

            if(!isNaN(segundoTipo) && chaveSelecionadaInt != segundoTipo) inputTipoSecundario.setValueState(sap.ui.core.ValueState.Success);
            
            if(!isNaN(segundoTipo) && chaveSelecionadaInt === segundoTipo) {
                inputTipoSecundario.setValueState(sap.ui.core.ValueState.Error);
                inputTipoSecundario.setValueStateText("Este campo não aceita tipos repetidos!");
                return("TIPO SECUNDARIO: OS TIPOS NÃO PODEM SER IGUAIS!\n");
            }

        },
        
        validaCampoTipoSecundarioPreenchido(evento, chaveDoTipoPrincipal) {
            let chaveSelecionada = evento.getSource().getSelectedKey()
            let primeiroTipo = parseInt(chaveDoTipoPrincipal)
            let chaveSelecionadaInt = (chaveSelecionada === "") ? 0 : parseInt(chaveSelecionada);
            let primeiraChave = 1;
            let ultimaChave = 17;
            
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(chaveSelecionadaInt < primeiraChave || chaveSelecionadaInt > ultimaChave) {                
                let valorDoCampo = evento.getParameter("value");
                if(valorDoCampo.length != 0) {
                    evento.getSource().setValueState(sap.ui.core.ValueState.Error)
                    evento.getSource().setValueStateText("Selecione um tipo existente");
                    return("TIPO PRINCIPAL: Selecione um tipo existente!\n")
                }
                else evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            }
            
            if (chaveSelecionadaInt === primeiroTipo) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo não aceita tipos repetidos!");
                return("TIPO SECUNDÁRIO: OS TIPOS NÃO PODEM SER IGUAIS!\n");
            }
        },

        validaCampoFotoPreenchido(evento) {
            let arquivo = evento.getSource().getValue();
            console.log(arquivo)
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
        }
    }
})

sap.ui.define([
], () => {
"use strict";
    return {
        validaNome(evento) {
            const regexNaoPermitido = /[\d!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/
            const stringVazia = "";
            const tamanhoMinimo = 3;
            let valorDigitado = evento.getParameter('value');
            
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            
            if(evento.getSource().getValue().length < tamanhoMinimo ) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo precisa ter no mínimo 3 letras!");
            }
            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        }, 

        validaApelido(evento) {
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(evento.getSource().getValue().length < 1) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo não pode ser vazio!");
            }
        }, 

        validaNivel(evento) {
            const regexNaoPermitido = /[\D!@?,"¨|´`<>/\\[\]{};#\$%\^\&*\)\(+=._-]/;
            const stringVazia = "";
            const nivelMinimo = 1;
            const nivelMaximo = 100;
            let valorDigitado = evento.getParameter('value');

            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(evento.getSource().getValue() < nivelMinimo || evento.getSource().getValue() > nivelMaximo) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo deve ser um número inteiro entre 1 e 100!");
            }

            if(regexNaoPermitido.test(valorDigitado)){
                valorDigitado = valorDigitado.replace(regexNaoPermitido, stringVazia);
                evento.getSource().setValue(valorDigitado); 
            }
        },

        validaAltura(evento) {
            const alturaMinima = 0;
            const alturaMaxima = 7;

            let valorDigitado = evento.getParameter('value');
            let valor = parseFloat(valorDigitado.split('_')[0])
            console.log(valor);
            
            evento.getSource().setValueState(sap.ui.core.ValueState.Success);
            if(valor <= alturaMinima || valor >= alturaMaxima) {
                evento.getSource().setValueState(sap.ui.core.ValueState.Error);
                evento.getSource().setValueStateText("Este campo deve ser um número entre 0.01 e 6.99");
            }
        },

        validarDataDeCaptura(evento) {
            
        }
    }
})

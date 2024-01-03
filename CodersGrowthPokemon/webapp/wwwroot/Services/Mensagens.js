sap.ui.define([
], () => {
"use strict";
    let _i18n;
    const sucessoAoSalvar = "sucessoAoSalvar"
    const sucessoAoAtualizar = "sucessoAoAtualizar"
    const mensagemDeConfirmacao = "mensagemSalvar"
    const mensagemPreencherCamposVazios = "mensagemPreencherCamposVazios"
    const aoClicarEmCancelarNaAdicao = "mensagemAoClicarEmCancelarNaAdicao"
    const aoClicarEmCancelarNaAtualizacao = "mensagemAoClicarEmCancelarNaAtualizacao"
    const mensagemNomeTamanhoMinimo = "campoNomeTamanhoMinimo"
    const mensagemCampoVazio = "campoVazio"
    const mensagemApelidoTamanhoMinimo = "campoApelidoTamanhoMinimo"
    const mensagemNivelInvalido = "campoNivelNumeroInvalido"
    const mensagemAlturaNumeroInvalido = "campoAlturaNumeroInvalido"
    const mensagemDataCapturaInvalida = "campoDataDeCapturaInvalida"
    const mensagemTipoPrincipalInvalido = "campoTipoPrincipalChaveInvalida"
    const mensagemTipoSecundarioInvalido = "campoTipoSecundarioChaveInvalida"
    const mensagemTiposIguais = "campoTipoSecundarioTiposRepetidos"
    const sucessoAoRemover = "sucessoAoRemover";
    const mensagemDeConfirmacaoDeRemocao = "Deseja mesmo remover o pokemon?"

    return {
        Mensagens(i18n) {
            _i18n = i18n;
        },

        _sim(){
            return "Sim";
        },

        _nao(){
            return "Não";
        },

        _mensagemSucessoAoSalvar(){
            return _i18n.getText(sucessoAoSalvar)
        },

        _mensagemSucessoAoAtualizar() {
            return _i18n.getText(sucessoAoAtualizar)
        },

        _mensagemAoClicarEmSalvar() {
            return _i18n.getText(mensagemDeConfirmacao)
        },

        _mensagemErroCamposVazios() {
            return _i18n.getText(mensagemPreencherCamposVazios)
        },

        _mensagemAoClicarEmCancelarNaAdicao() {
            return _i18n.getText(aoClicarEmCancelarNaAdicao)
        },

        _mensagemAoClicarEmCancelarNaAtualizacao() {
            return _i18n.getText(aoClicarEmCancelarNaAtualizacao)
        },

        _mensagemDeErroNomeTamanhoMinimo() {
            return _i18n.getText(mensagemNomeTamanhoMinimo)
        },

        _mensagemDeErroCampoVazio() {
            return _i18n.getText(mensagemCampoVazio)
        },

        _mensagemDeErroApelidoTamanhoMinimo() {
            return _i18n.getText(mensagemApelidoTamanhoMinimo)
        },

        _mensagemDeErroNivelInvalido() {
            return _i18n.getText(mensagemNivelInvalido)
        },

        _mensagemDeErroAlturaNumeroInvalido() {
            return _i18n.getText(mensagemAlturaNumeroInvalido)
        },

        _mensagemDeErroDaraCapturaInvalida() {
            return _i18n.getText(mensagemDataCapturaInvalida)
        },

        _mensagemDeErroTipoPrincipalInvalido() {
            return _i18n.getText(mensagemTipoPrincipalInvalido)
        },

        _mensagemDeErroTipoSecundarioInvalido() {
            return _i18n.getText(mensagemTipoSecundarioInvalido)
        },

        _mensagemDeErroTiposRepetidos() {
            return _i18n.getText(mensagemTiposIguais)
        },

        _mensagemDeSucessoAoRemover() {
            return _i18n.getText(sucessoAoRemover)
        },

        _mensagemDeConfirmacaoAoRemover() {
            return _i18n.getText(mensagemDeConfirmacaoDeRemocao)
        }       
    }
});
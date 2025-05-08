/// <reference path="../lib/toastr.js/toastr.min.js" />
/// <reference path="toastr-configuracao.js" />

const Mensagens = {
    Erro(mensagem, titulo)
    {
        toastr.error(mensagem, titulo);
    },
    Sucesso(mensagem, titulo)
    {
        toastr.success(mensagem, titulo);
    },
    Info(mensagem, titulo)
    {
        toastr.info(mensagem, titulo);
    }
};

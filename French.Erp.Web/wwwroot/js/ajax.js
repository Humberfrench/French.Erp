const Ajax = {
    Execute: function (opcoes)
    {
        const url = opcoes.url;
        const dadoEnvio = opcoes.dadoEnvio ? JSON.stringify(opcoes.dadoEnvio) : '';
        const headers = opcoes.headers || {};
        const type = opcoes.type || 'GET';
        const async = opcoes.async !== undefined ? opcoes.async : true; // O padrão deve ser assíncrono

        return $.ajax({
            type: type,
            url: url,
            dataType: 'json',
            data: dadoEnvio,
            headers: headers,
            cache: false,
            contentType: 'application/json; charset=utf-8',
            async: async
        }).done(opcoes.callBackSuccess)
            .fail(function (xhr, msg, e)
            {
                Mensagens.Erro(e, "Erro");
            });
    },

    Get: function (opcoes)
    {
        const url = opcoes.url;
        const dadoEnvio = opcoes.dadoEnvio || {};

        return $.get(url, dadoEnvio)
            .done(opcoes.callBackSuccess)
            .fail(function (jqxhr, textStatus, error)
            {
                Mensagens.Erro(error, "Erro");
            });
    },

    Post: function (opcoes)
    {
        const url = opcoes.url;
        const dadoEnvio = opcoes.dadoEnvio || {};

        return $.post(url, dadoEnvio)
            .done(opcoes.callBackSuccess)
            .fail(function (jqxhr, textStatus, error)
            {
                Mensagens.Erro(error, "Erro");
            });
    }
};

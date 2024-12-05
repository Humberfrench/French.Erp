var Util = new Object;

Util.OnlyNumbers = function(e)
{
    var intKey = e.keyCode || e.which;

    if ((intKey > 47 && intKey < 58)) return true;
    else
    {
        if (intKey == 8 || intKey == 0) return true;
        else return false;
    }
}

Util.ObterLista = function (value, text)
{
    var optionData = "";
    optionData += '<option value="' + value + '">' + text + '</option>';
    return optionData;
};
Util.ValidaEmail = function (strEmail)
{
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

    if (!emailReg.test(strEmail))
    {
        return false;
    }

    return true;
};

Util.FormatarString = function ()
{
    var retornoString = arguments[0];
    for (var i = 1; i < arguments.length; i++)
    {
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        retornoString = retornoString.replace(regEx, arguments[i]);
    }

    return retornoString;
};

Util.SomenteCaracteres = function (e)
{
    var expressao = /[a-zA-Z]/;

    if (expressao.test(String.fromCharCode(e.keyCode)))
    {
        return true;
    }
    return false;
}

Util.SomenteCaracteresENumeros = function (e)
{
    var expressao = /[a-zA-Z0-9]/;

    if (expressao.test(String.fromCharCode(e.keyCode)))
    {
        return true;
    }
    return false;
}

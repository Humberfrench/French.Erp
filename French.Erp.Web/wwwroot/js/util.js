const Util = {
    OnlyNumbers: function (e)
    {
        const intKey = e.keyCode || e.which;
        return (intKey >= 48 && intKey <= 57) || intKey === 8 || intKey === 0;
    },

    ObterLista: function (value, text)
    {
        return `<option value="${value}">${text}</option>`;
    },

    ValidaEmail: function (strEmail)
    {
        const emailReg = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Regex melhorada
        return emailReg.test(strEmail);
    },

    FormatarString: function ()
    {
        let retornoString = arguments[0];
        for (let i = 1; i < arguments.length; i++)
        {
            const regEx = new RegExp(`\\{${i - 1}\\}`, "gm");
            retornoString = retornoString.replace(regEx, arguments[i]);
        }
        return retornoString;
    },

    SomenteCaracteres: function (e)
    {
        const char = String.fromCharCode(e.keyCode);
        return /^[a-zA-Z]$/.test(char);
    },

    SomenteCaracteresENumeros: function (e)
    {
        const char = String.fromCharCode(e.keyCode);
        return /^[a-zA-Z0-9]$/.test(char);
    }
};

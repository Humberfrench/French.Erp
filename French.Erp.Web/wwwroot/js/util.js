const Util = {
    onlyNumbers: function (e)
    {
        const intKey = e.keyCode || e.which;
        return (intKey >= 48 && intKey <= 57) || intKey === 8 || intKey === 0;
    },
    obterLista: function (value, text)
    {
        return `<option value="${value}">${text}</option>`;
    },
    validaEmail: function (strEmail)
    {
        const emailReg = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Regex melhorada
        return emailReg.test(strEmail);
    },
    formatarString: function ()
    {
        let retornoString = arguments[0];
        for (let i = 1; i < arguments.length; i++)
        {
            const regEx = new RegExp(`\\{${i - 1}\\}`, "gm");
            retornoString = retornoString.replace(regEx, arguments[i]);
        }
        return retornoString;
    },
    somenteCaracteres: function (e)
    {
        const char = String.fromCharCode(e.keyCode);
        return /^[a-zA-Z]$/.test(char);
    },
    somenteCaracteresENumeros: function (e)
    {
        const char = String.fromCharCode(e.keyCode);
        return /^[a-zA-Z0-9]$/.test(char);
    },
    onlyValues: function (e)
    {
        const intKey = e.keyCode || e.which;
        const char = String.fromCharCode(intKey);
        return (intKey >= 48 && intKey <= 57) || intKey === 8 || intKey === 0 || char === ',';
    }

};

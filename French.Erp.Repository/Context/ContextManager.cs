using French.Erp.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace French.Erp.Repository.Context
{
    public class ContextManager : IContextManager
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        private readonly IHttpContextAccessor context;
        private readonly IConfiguration configuration;

        public ContextManager(IHttpContextAccessor context,
                              IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string GetConnectionString => configuration.GetConnectionString("FrenchContext");

        public FrenchContext GetContext()
        {
            if (context.HttpContext == null)
                return new FrenchContext();

            if (context.HttpContext.Items[CONTEXT_KEY] == null)
            {
                context.HttpContext.Items[CONTEXT_KEY] = new FrenchContext();
            }

            return context.HttpContext.Items[CONTEXT_KEY] as FrenchContext;
        }
    }
}

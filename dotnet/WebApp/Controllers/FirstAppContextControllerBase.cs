namespace WebApp.Controllers
{
    using Connectors;

    public abstract class FirstAppContextControllerBase : ObservableControllerBase
    {
        protected FirstAppContext Context { get; private set; }

        public FirstAppContextControllerBase(FirstAppContext context)
        {
            this.Context = context;
        }
    }
}

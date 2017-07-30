using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace Webservice
{
    // Generic Base class service that all services will inherit from. 
    // Dependencies will be injected when an instance of the class is created
    public abstract class BaseService<T> :  System.Web.Services.WebService where T:class
    {
        public BaseService()
        {
            InjectDependencies();
        }

        protected virtual void InjectDependencies()
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
                return;

            IContainerAccessor accessor = context.ApplicationInstance as IContainerAccessor;

            if (accessor == null)
                return;

            IUnityContainer container = accessor.Container;

            if (container == null)
                throw new InvalidOperationException("Container on Global Application Class is Null. Cannot perform BuildUp.");

            container.BuildUp(this as T);
        }
    }
}
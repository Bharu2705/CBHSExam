using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Webservice
{
    public class Global : System.Web.HttpApplication, IContainerAccessor
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get
            {
                return Container;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            CreateContainer();
        }
        protected virtual void CreateContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, DebugLogger>();
            Container = container;
        }

    }
}
using Microsoft.Practices.Unity;

namespace Webservice
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}
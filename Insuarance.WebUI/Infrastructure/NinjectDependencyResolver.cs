using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insuarence.Domain.Abstract;
using Insuarence.Domain.Concrete;
using Ninject;
using System.Web.Http.Dependencies;

namespace Insuarance.WebUI.Infrastructure
{
    public interface IDependencyResolver : IDependencyScope, IDisposable
    {
        IDependencyScope BeginScope();
    }
    public interface IDependencyScope : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
      public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }


        private void AddBindings()
        {
            kernel.Bind<IInsuarenceRepository>().To<EFInsuarenceRepository>();
        }



        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
      }
}
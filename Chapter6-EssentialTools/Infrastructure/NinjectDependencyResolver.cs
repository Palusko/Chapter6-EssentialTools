using Chapter6_EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Web.Common;

namespace Chapter6_EssentialTools.Infrastructure
{
  public class NinjectDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;

    public NinjectDependencyResolver(IKernel kernelParam)
    {
      kernel = kernelParam;
      AddBindings();
    }

    public object GetService(Type serviceType)
    {
      return kernel.TryGet(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return kernel.GetAll(serviceType);
    }

    private void AddBindings()
    {
      kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
      //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
      kernel.Bind<IDiscountHelper>().To<DefaultDicountHelper>().WithConstructorArgument("discountParam", 50m);
      kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
    }
  }
}
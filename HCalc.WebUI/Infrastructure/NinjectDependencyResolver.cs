using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HCalc.Domain.Abstract;
using HCalc.Domain.Concrete;
using Ninject;

namespace HCalc.WebUI.Infrastructure
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
            // put bindings here
            kernel.Bind<IBuildingPartRepository>().To<EFBuildingPartRepository>();
            kernel.Bind<IDefectDescriptionRepository>().To<EFDefectDescriptionRepository>();

            kernel.Bind<IDefectExtentRepository>().To<EFDefectExtentRepository>();
            kernel.Bind<IDefectImportanceRepository>().To<EFDefectImportanceRepository>();
            kernel.Bind<IDefectIntencityRepository>().To<EFDefectIntencityRepository>();

            kernel.Bind<IActionRepository>().To<EFActionRepository>();

            kernel.Bind<IMatrixRepository>().To<EFMatrixRepository>();
        }
    }
}
﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
namespace SportsStore.WebUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
        {
        private readonly IKernel kernel;
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
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            }
        }


    
}
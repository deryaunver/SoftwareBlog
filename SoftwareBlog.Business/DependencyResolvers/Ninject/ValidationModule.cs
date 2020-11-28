using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject.Modules;
using SoftwareBlog.Business.ValidationRules.FluentValidation;

namespace SoftwareBlog.Business.DependencyResolvers.Ninject
{
    class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator>().To<ProductValidator>().InSingletonScope();

        }
    }
}

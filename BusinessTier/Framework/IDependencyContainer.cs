using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IDependencyContainer
    {
        IContainer GetContainer();
    }
}

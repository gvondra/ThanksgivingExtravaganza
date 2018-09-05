using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IDependencyContainer
    {
        IContainer GetContainer();
    }
}

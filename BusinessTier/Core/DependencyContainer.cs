using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class DependencyContainer : IDependencyContainer
    {
        private static IContainer m_container;

        static DependencyContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Build(builder);
            m_container = builder.Build();
        }

        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<MenuCommentFactory>().As<IMenuCommentFactory>();
            builder.RegisterType<MenuCommentSaver>().As<IMenuCommentSaver>();
            builder.RegisterType<MenuFactory>().As<IMenuFactory>();
            builder.RegisterType<MenuSaver>().As<IMenuSaver>();
        }

        public IContainer GetContainer()
        {
            return m_container;
        }
    }
}

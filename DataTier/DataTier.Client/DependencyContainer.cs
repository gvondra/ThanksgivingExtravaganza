using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
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
            builder.RegisterType<MenuCommentDataFactory>().As<IMenuCommentDataFactory>();
            builder.RegisterType<MenuCommentDataSaver>().As<IMenuCommentDataSaver>();
            builder.RegisterType<MenuDataFactory>().As<IMenuDataFactory>();
            builder.RegisterType<MenuDataSaver>().As<IMenuDataSaver>();
        }

        public IContainer GetContainer()
        {
            return m_container;
        }
    }
}

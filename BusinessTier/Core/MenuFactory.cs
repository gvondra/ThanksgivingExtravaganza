using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class MenuFactory : IMenuFactory
    {
        private Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContainer;
        private IMenuCommentFactory m_menuCommentFactory;

        public MenuFactory(IMenuCommentFactory menuCommentFactory)
        {
            m_dependencyContainer = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
            m_menuCommentFactory = menuCommentFactory;
        }

        public IMenu Get(ISettings settings, int id)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IMenuDataFactory dataFactory = scope.Resolve<IMenuDataFactory>();
                MenuData data = dataFactory.Get(new Settings(settings), id);
                if (data == null)
                {
                    return new Menu(data, scope.Resolve<IMenuDataSaver>(), m_menuCommentFactory);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<IMenu> GetAll(ISettings settings)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IMenuDataFactory dataFactory = scope.Resolve<IMenuDataFactory>();
                IMenuDataSaver dataSaver = scope.Resolve<IMenuDataSaver>();
                return dataFactory.GetAll(new Settings(settings))
                    .Select<MenuData, IMenu>(d => new Menu(d, dataSaver, m_menuCommentFactory));
            }
        }
    }
}

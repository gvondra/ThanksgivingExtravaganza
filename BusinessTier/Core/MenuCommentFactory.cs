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
    public class MenuCommentFactory : IMenuCommentFactory
    {
        private Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContainer;

        public MenuCommentFactory()
        {
            m_dependencyContainer = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
        }

        public IEnumerable<IMenuComment> GetByMenu(ISettings settings, IMenu menu)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IMenuCommentDataFactory dataFactory = scope.Resolve<IMenuCommentDataFactory>();
                IMenuCommentDataSaver dataSaver = scope.Resolve<IMenuCommentDataSaver>();
                return dataFactory.GetByMenuId(new Settings(settings), menu.MenuId)
                    .Select<MenuCommentData, IMenuComment>(d => new MenuComment(d, menu, dataSaver));
            }
        }
    }
}

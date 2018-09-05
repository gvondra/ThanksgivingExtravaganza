using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class MenuSaver : IMenuSaver
    {
        private Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContainer;

        public MenuSaver()
        {
            m_dependencyContainer = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
        }

        public void Create(ISettings settings, IMenu menu)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), menu.Create);
        }

        public void Delete(ISettings settings, int menuId)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), th => {
                using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
                {
                    IMenuDataSaver dataSaver = scope.Resolve<IMenuDataSaver>();
                    dataSaver.Delete(new TransactionHandlerWrapper(th), menuId);
                }
            });
        }

        public void Update(ISettings settings, IMenu menu)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), menu.Update);
        }
    }
}

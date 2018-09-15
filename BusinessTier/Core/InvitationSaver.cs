using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class InvitationSaver : IInvitationSaver
    {
        Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContaner;

        public InvitationSaver()
        {
            m_dependencyContaner = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
        }

        public void Create(ISettings settings, IInvitation invitation)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), invitation.Create);
        }

        public void Delete(ISettings settings, Guid invitationId)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), th =>
            {
                using (ILifetimeScope scope = m_dependencyContaner.GetContainer().BeginLifetimeScope())
                {
                    IInvitationDataSaver dataSaver = scope.Resolve<IInvitationDataSaver>();
                    dataSaver.Delete(new TransactionHandlerWrapper(th), invitationId);
                }
            });
        }

        public void Update(ISettings settings, IInvitation invitation)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), invitation.Update);
        }
    }
}

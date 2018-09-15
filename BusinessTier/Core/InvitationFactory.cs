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
    public class InvitationFactory : IInvitationFactory
    {
        private IInvitationResponseFactory m_responseFactory;
        private Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContainer;

        public InvitationFactory(IInvitationResponseFactory responseFactory)
        {
            m_dependencyContainer = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
            m_responseFactory = responseFactory;
        }

        public IInvitation Create()
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IInvitationDataSaver dataSaver = scope.Resolve<IInvitationDataSaver>();
                return new Invitation(new InvitationData() { InvitationId = Guid.NewGuid() }, dataSaver, m_responseFactory);
            }            
        }

        public IInvitation Get(ISettings settings, Guid id)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IInvitationDataFactory dataFactory = scope.Resolve<IInvitationDataFactory>();
                InvitationData data = dataFactory.Get(new Settings(settings), id);
                if (data != null)
                {
                    IInvitationDataSaver dataSaver = scope.Resolve<IInvitationDataSaver>();
                    return new Invitation(data, dataSaver, m_responseFactory);
                }
                else
                {
                    return null;
                }                
            }
        }

        public IEnumerable<IInvitation> GetAll(ISettings settings)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IInvitationDataFactory dataFactory = scope.Resolve<IInvitationDataFactory>();
                IInvitationDataSaver dataSaver = scope.Resolve<IInvitationDataSaver>();
                return dataFactory.GetAll(new Settings(settings))
                    .Select<InvitationData, IInvitation>(d => new Invitation(d, dataSaver, m_responseFactory));
            }
        }
    }
}

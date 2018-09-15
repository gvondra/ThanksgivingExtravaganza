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
    public class InvitationResponseFactory: IInvitationResponseFactory
    {
        Vondra.Thanksgiving.Extravaganza.DataTier.Client.IDependencyContainer m_dependencyContainer;

        public InvitationResponseFactory()
        {
            m_dependencyContainer = new Vondra.Thanksgiving.Extravaganza.DataTier.Client.DependencyContainer();
        }

        public IInvitationResponse Create(IInvitation invitation, bool? isAttending, short? attendingCount, string note)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                InvitationResponseData responseData = new InvitationResponseData()
                {
                    IsAttending = isAttending,
                    AttendeeCount = attendingCount,
                    Note = note
                };
                return new InvitationResponse(responseData, scope.Resolve<IInvitationResponseDataSaver>(), invitation);
            }           
        }

        public IEnumerable<IInvitationResponse> GetByInvitation(ISettings settings, IInvitation invitation)
        {
            using (ILifetimeScope scope = m_dependencyContainer.GetContainer().BeginLifetimeScope())
            {
                IInvitationResponseDataFactory dataFactory = scope.Resolve<IInvitationResponseDataFactory>();
                IInvitationResponseDataSaver dataSaver = scope.Resolve<IInvitationResponseDataSaver>();
                return dataFactory.GetByInvitationId(new Settings(settings), invitation.InvitationId)
                    .Select<InvitationResponseData, IInvitationResponse>(d => new InvitationResponse(d, dataSaver, invitation));
            }
        }
    }
}

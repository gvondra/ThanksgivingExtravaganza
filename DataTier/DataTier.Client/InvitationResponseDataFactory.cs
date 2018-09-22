using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class InvitationResponseDataFactory : IInvitationResponseDataFactory
    {
        private IGenericDataFactory<InvitationResponseData> m_genericDataFactory;

        public InvitationResponseDataFactory()
        {
            m_genericDataFactory = new GenericDataFactory<InvitationResponseData>();
        }

        public IEnumerable<InvitationResponseData> GetByInvitationId(ISettings settings, Guid invitationId)
        {
            return GetByInvitationId(settings, new DbProviderFactory(), invitationId);
        }

        public IEnumerable<InvitationResponseData> GetByInvitationId(ISettings settings, IDbProviderFactory providerFactory, Guid invitationId)
        {
            IDataParameter parameter = Util.CreateParameter(providerFactory, "invitationId", DbType.Guid);
            parameter.Value = invitationId;
            IEnumerable<InvitationResponseData> responses = m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_InvitationResponse_by_InvitationId",
                () => new InvitationResponseData(),
                Util.AssignDataStateManager,
                new IDataParameter[] { parameter }
                );
            foreach (InvitationResponseData r in responses)
            {
                r.CreateTimestamp = DateTime.SpecifyKind(r.CreateTimestamp, DateTimeKind.Utc);
            }
            return responses;
        }
    }
}

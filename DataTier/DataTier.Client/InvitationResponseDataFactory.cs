using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class InvitationResponseDataFactory : IInvitationResponseDataFactory
    {
        private IGenericDataFactory<InviationResponseData> m_genericDataFactory;

        public InvitationResponseDataFactory()
        {
            m_genericDataFactory = new GenericDataFactory<InviationResponseData>();
        }

        public IEnumerable<InviationResponseData> GetByInvitationId(ISettings settings, Guid invitationId)
        {
            return GetByInvitationId(settings, new DbProviderFactory(), invitationId);
        }

        public IEnumerable<InviationResponseData> GetByInvitationId(ISettings settings, IDbProviderFactory providerFactory, Guid invitationId)
        {
            IDataParameter parameter = Util.CreateParameter(providerFactory, "invitationId", DbType.Guid);
            parameter.Value = invitationId;
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_InvitationResponse_by_InvitationId",
                () => new InviationResponseData(),
                Util.AssignDataStateManager,
                new IDataParameter[] { parameter }
                );
        }
    }
}

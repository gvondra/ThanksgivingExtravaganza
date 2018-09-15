using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class InvitationDataFactory : IInvitationDataFactory
    {
        private IGenericDataFactory<InvitationData> m_genericDataFactory;

        public InvitationDataFactory()
        {
            m_genericDataFactory = new GenericDataFactory<InvitationData>();
        }

        public InvitationData Get(ISettings settings, Guid id)
        {
            return Get(settings, new DbProviderFactory(), id);
        }

        public InvitationData Get(ISettings settings, IDbProviderFactory providerFactory, Guid id)
        {
            IDataParameter parameter = Util.CreateParameter(providerFactory, "id", DbType.Guid);
            parameter.Value = id;
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_Invitation",
                () => new InvitationData(),
                Util.AssignDataStateManager,
                new IDataParameter[] { parameter }
                ).FirstOrDefault();
        }

        public IEnumerable<InvitationData> GetAll(ISettings settings)
        {
            return GetAll(settings, new DbProviderFactory());
        }

        public IEnumerable<InvitationData> GetAll(ISettings settings, IDbProviderFactory providerFactory)
        {
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_Invitation_All",
                () => new InvitationData(),
                Util.AssignDataStateManager
                );
        }
    }
}

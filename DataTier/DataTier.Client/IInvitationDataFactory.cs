using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IInvitationDataFactory
    {
        IEnumerable<InvitationData> GetAll(ISettings settings);
        InvitationData Get(ISettings settings, Guid id);
    }
}

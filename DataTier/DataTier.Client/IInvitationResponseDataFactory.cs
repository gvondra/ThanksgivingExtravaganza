using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IInvitationResponseDataFactory
    {
        IEnumerable<InviationResponseData> GetByInvitationId(ISettings settings, Guid invitationId);
    }
}

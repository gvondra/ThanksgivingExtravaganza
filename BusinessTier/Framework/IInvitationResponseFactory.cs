using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitationResponseFactory
    {
        IInvitationResponse Create(IInvitation invitation,
            bool? isAttending,
            short? attendingCount,
            string note);
        IEnumerable<IInvitationResponse> GetByInvitation(ISettings settings, IInvitation invitation);
    }
}

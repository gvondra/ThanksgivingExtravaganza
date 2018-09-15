using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitationResponseSaver
    {
        void Create(ISettings settings, IInvitationResponse response);
    }
}

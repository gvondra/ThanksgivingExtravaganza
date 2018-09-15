using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitationSaver
    {
        void Create(ISettings settings, IInvitation invitation);
        void Update(ISettings settings, IInvitation invitation);
        void Delete(ISettings settings, Guid invitationId);
    }
}

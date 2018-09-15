using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IInvitationFactory
    {
        IInvitation Get(ISettings settings, Guid id);
        IInvitation Create();
        IEnumerable<IInvitation> GetAll(ISettings settings);
    }
}

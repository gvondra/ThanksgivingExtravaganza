using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class InvitationResponseSaver : IInvitationResponseSaver
    {
        public void Create(ISettings settings, IInvitationResponse response)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), response.Create);
        }
    }
}

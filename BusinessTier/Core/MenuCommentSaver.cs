using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.Framework;
namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class MenuCommentSaver : IMenuCommentSaver
    {
        public void Create(ISettings settings, IMenuComment comment)
        {
            Saver saver = new Saver();
            saver.Save(new TransactionHandler(settings), comment.Create);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenuComment
    {
        int MenuCommentId { get; }
        string Text { get; set; }
        string CreateUser { get; set; }
        DateTime CreateTimestamp { get; }

        void Create(ITransactionHandler transactionHandler);
    }
}

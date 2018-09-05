using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenu
    {
        int MenuId { get; }
        string Title { get; set; }
        string Description { get; set; }
        int SortOrder { get; set; }
        DateTime CreateTimestamp { get; }
        DateTime UpdateTimestamp { get; }

        IEnumerable<IMenuComment> GetMenuComments(ISettings settings);
        void Create(ITransactionHandler transactionHandler);
        void Update(ITransactionHandler transactionHandler);
    }
}

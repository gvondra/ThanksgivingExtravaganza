using System;
using System.Collections.Generic;
using System.Data;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface ITransactionHandler : ISettings
    {
        IDbConnection DatabaseConnection { get; set; }
        Vondra.DataTier.Common.IDbTransaction DatabaseTransaction { get; set; }
    }
}

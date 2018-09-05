using System;
using System.Collections.Generic;
using System.Data;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface ITransactionHandler
    {
        IDbConnection DatabaseConnection { get; set; }
        IDbTransaction DatabaseTransaction { get; set; }
    }
}

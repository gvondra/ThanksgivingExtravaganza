using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.BusinessTier.Common
{
    public class TransactionHandler : ITransactionHandler
    {
        private ISettings m_settings;

        public TransactionHandler(ISettings settings)
        {
            m_settings = settings;
        }

        public IDbConnection DatabaseConnection { get; set; }
        public Vondra.DataTier.Common.IDbTransaction DatabaseTransaction { get; set; }

        public string ConnectionString
        {
            get
            {
                return m_settings.ConnectionString;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class MenuDataFactory : IMenuDataFactory
    {
        private IGenericDataFactory<MenuData> m_genericDataFactory;

        public MenuDataFactory()
        {
            m_genericDataFactory = new GenericDataFactory<MenuData>();
        }
        public MenuData Get(ISettings settings, int id)
        {
            return Get(settings, new DbProviderFactory(), id);
        }
        public MenuData Get(ISettings settings, IDbProviderFactory providerFactory, int id)
        {
            IDataParameter parameter = Util.CreateParameter(providerFactory, "id", DbType.Int32);
            parameter.Value = id;
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_Menu",
                () => new MenuData(),
                Util.AssignDataStateManager,
                new IDataParameter[] { parameter }
                ).FirstOrDefault();
        }

        public IEnumerable<MenuData> GetAll(ISettings settings)
        {
            return GetAll(settings, new DbProviderFactory());
        }

        public IEnumerable<MenuData> GetAll(ISettings settings, IDbProviderFactory providerFactory)
        {
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_Menu_All",
                () => new MenuData(),
                Util.AssignDataStateManager
                );
        }
    }
}

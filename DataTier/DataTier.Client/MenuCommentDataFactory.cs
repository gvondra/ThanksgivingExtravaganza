using System;
using System.Collections.Generic;
using System.Data;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public class MenuCommentDataFactory : IMenuCommentDataFactory
    {
        private IGenericDataFactory<MenuCommentData> m_genericDataFactory;

        public MenuCommentDataFactory()
        {
            m_genericDataFactory = new GenericDataFactory<MenuCommentData>();
        }

        public IEnumerable<MenuCommentData> GetByMenuId(ISettings settings, int menuId)
        {
            return GetByMenuId(settings, new DbProviderFactory(), menuId);
        }

        public IEnumerable<MenuCommentData> GetByMenuId(ISettings settings, IDbProviderFactory providerFactory, int menuId)
        {
            IDataParameter parameter = Util.CreateParameter(providerFactory, "menuId", DbType.Int32);
            parameter.Value = menuId;
            return m_genericDataFactory.GetData(settings, providerFactory, "vte.SSP_MenuComment_by_MenuId", 
                () => new MenuCommentData(), 
                Util.AssignDataStateManager, 
                new IDataParameter[] { parameter }
                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class Menu : IMenu
    {
        private MenuData m_menuData;
        private IMenuCommentFactory m_menuCommentFactory;
        private IMenuDataSaver m_menuDataSaver;

        public Menu(MenuData menuData,
            IMenuDataSaver menuDataSaver,
            IMenuCommentFactory menuCommentFactory)
        {
            m_menuData = menuData;
            m_menuDataSaver = menuDataSaver;
            m_menuCommentFactory = menuCommentFactory;
        }

        public int MenuId
        {
            get
            {
                return m_menuData.MenuId;
            }
        }

        public string Title
        {
            get
            {
                return m_menuData.Title;
            }
            set
            {
                m_menuData.Title = value;
            }
        }
        public string Description
        {
            get
            {
                return m_menuData.Description;
            }
            set
            {
                m_menuData.Description = value;
            }
        }
        public int SortOrder
        {
            get
            {
                return m_menuData.SortOrder;
            }
            set
            {
                m_menuData.SortOrder = value;
            }
        }

        public DateTime CreateTimestamp
        {
            get
            {
                return m_menuData.CreateTimestamp;
            }
        }

        public DateTime UpdateTimestamp
        {
            get
            {
                return m_menuData.UpdateTimestamp;
            }
        }

        public void Create(ITransactionHandler transactionHandler)
        {
            m_menuDataSaver.Create(new TransactionHandlerWrapper(transactionHandler), m_menuData);
        }

        public void Delete(ITransactionHandler transactionHandler)
        {
            m_menuDataSaver.Delete(new TransactionHandlerWrapper(transactionHandler), MenuId);
        }

        public IEnumerable<IMenuComment> GetMenuComments(ISettings settings)
        {
            if (m_menuData.DataStateManager.GetState(m_menuData) != Vondra.DataTier.Common.DataStateManagerState.New)
            {
                return m_menuCommentFactory.GetByMenu(settings, this);
            }
            else
            {
                return null;
            }
        }

        public void Update(ITransactionHandler transactionHandler)
        {
            m_menuDataSaver.Update(new TransactionHandlerWrapper(transactionHandler), m_menuData);
        }
    }
}

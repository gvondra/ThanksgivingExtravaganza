using System;
using System.Collections.Generic;
using System.Text;
using Vondra.Thanksgiving.Extravaganza.BusinessTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Client;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace Vondra.Thanksgiving.Extravaganza.Core
{
    public class MenuComment : IMenuComment
    {
        private MenuCommentData m_commentData;
        private IMenuCommentDataSaver m_commentDataSaver;
        private IMenu m_menu;
        public MenuComment(MenuCommentData commentData,
            IMenu menu,
            IMenuCommentDataSaver commentDataSaver)
        {
            m_commentData = commentData;
            m_menu = menu;
            m_commentDataSaver = commentDataSaver;
        }

        public int MenuCommentId
        {
            get
            {
                return m_commentData.MenuCommentId;
            }
        }

        public string Text
        {
            get
            {
                return m_commentData.Text; 
            }
            set
            {
                m_commentData.Text = value;
            }
        }
        public string CreateUser
        {
            get
            {
                return m_commentData.CreateUser;
            }
            set
            {
                m_commentData.CreateUser = value;
            }
        }

        public DateTime CreateTimestamp
        {
            get
            {
                return m_commentData.CreateTimestamp;
            }
        }

        public void Create(ITransactionHandler transactionHandler)
        {
            m_commentDataSaver.Create(new TransactionHandlerWrapper(transactionHandler), m_commentData);
        }
    }
}

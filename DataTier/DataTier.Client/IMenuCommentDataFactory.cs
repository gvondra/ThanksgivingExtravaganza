using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IMenuCommentDataFactory
    {
        IEnumerable<MenuCommentData> GetByMenuId(ISettings settings, int menuId);
    }
}

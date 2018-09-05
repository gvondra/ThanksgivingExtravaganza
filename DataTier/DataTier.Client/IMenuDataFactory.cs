using System;
using System.Collections.Generic;
using System.Text;
using Vondra.DataTier.Common;
using Vondra.Thanksgiving.Extravaganza.DataTier.Models;

namespace Vondra.Thanksgiving.Extravaganza.DataTier.Client
{
    public interface IMenuDataFactory
    {
        MenuData Get(ISettings settings, int id);
        IEnumerable<MenuData> GetAll(ISettings settings);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenuFactory
    {
        IMenu Create();
        IEnumerable<IMenu> GetAll(ISettings settings);
        IMenu Get(ISettings settings, int id);
    }
}

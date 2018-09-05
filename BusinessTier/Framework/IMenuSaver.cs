using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenuSaver
    {
        void Create(ISettings settings, IMenu menu);
        void Update(ISettings settings, IMenu menu);
        void Delete(ISettings settings, int menuId);
    }
}

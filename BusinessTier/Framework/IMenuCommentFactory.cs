using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenuCommentFactory
    {
        IEnumerable<IMenuComment> GetByMenu(ISettings settings, IMenu menu);
    }
}

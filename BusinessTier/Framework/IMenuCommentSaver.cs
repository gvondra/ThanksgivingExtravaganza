using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.Framework
{
    public interface IMenuCommentSaver
    {
        void Create(ISettings settings, IMenuComment comment);
    }
}

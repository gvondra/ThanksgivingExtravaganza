using System;
using System.Collections.Generic;
using System.Text;

namespace Vondra.Thanksgiving.Extravaganza.BusinessTier.Common
{
    public class Settings : Vondra.DataTier.Common.ISettings
    {
        private Vondra.Thanksgiving.Extravaganza.Framework.ISettings m_innerSettings;

        public Settings(Framework.ISettings settings)
        {
            m_innerSettings = settings;
        }

        public string ConnectionString
        {
            get
            {
                return m_innerSettings.ConnectionString;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vondra.Thanksgiving.Extravaganza.Framework;

namespace ExtravaganzaAPI
{
    public class Settings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}

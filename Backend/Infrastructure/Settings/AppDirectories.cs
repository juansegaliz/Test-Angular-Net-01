using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public static class AppDirectories
    {
        public static readonly string BaseDirectory = AppContext.BaseDirectory;

        public static readonly string ConfigurationDirectory = Path.Combine(BaseDirectory, "Configuration");
    }
}

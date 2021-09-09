using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Cupboard;
using four_cupboard.Windows.Manifests;

namespace four_cupboard.Catalogs
{
    public sealed class WindowCatalog : Catalog
    {
        public override void Execute(CatalogContext context)
        {
            if (context.Facts.IsWindows())  
            {
                context.UseManifest<Chocolatey>();
            }
        }
    }
}

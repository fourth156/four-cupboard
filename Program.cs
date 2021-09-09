using System;
using Cupboard;
using four_cupboard.Catalogs;

namespace four_cupboard
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return CupboardHost.CreateBuilder()
                .AddCatalog<WindowCatalog>()
                .Build()
                .Run(args);
        }
    }
}

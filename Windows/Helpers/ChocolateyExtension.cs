using Cupboard;

namespace four_cupboard.Windows.Helpers
{
    public static class ChocolateyExtension
    {
        public static void InstallChocolateyPackage(this ManifestContext ctx, string packageName)
        {
            ctx.Resource<ChocolateyPackage>(packageName)
                .Ensure(PackageState.Installed)
                .After<PowerShell>("InstallChocolatey");
        }
    }
}
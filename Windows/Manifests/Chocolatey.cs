using System.Collections.Generic;
using Cupboard;
using four_cupboard.Windows.Helpers;

namespace four_cupboard.Windows.Manifests
{
    public sealed class Chocolatey : Manifest
    {
        public override void Execute(ManifestContext ctx)
        {
            InitializeChocolatey(ctx);
            Packages.ForEach(ctx.InstallChocolateyPackage);
        }

        private static readonly List<string> Packages = new()
        {
            "vscode",
            "docker",
            "docker-desktop",
            "microsoft-windows-terminal",
            "starship",
            "nvm",
            "googlechrome",
            "firefox",
            "brave",
            "deepl",
            "foxitreader",
            "greenshot",
            "insomnia-rest-api-client",
            "vlc",
            "tableplus",
            "7zip",
            "notepadplusplus.install",
            "python",
            "openssh",
            "sql-server-management-studio",
            "telegram",
            "discord",
            "steam"
        };

        private static readonly string ChocolateyPath = "https://chocolatey.org/install.ps1";

        private static void InitializeChocolatey(ManifestContext ctx)
        {
            DownloadChocolatey(ctx);
            SetExecutionPolicy(ctx);
            InstallChocolatey(ctx);
        }

        private static void DownloadChocolatey(ManifestContext ctx)
        {
            ctx.Resource<Download>(ChocolateyPath)
                .ToFile("~/install-chocolatey.ps1");
        }

        private static void SetExecutionPolicy(ManifestContext ctx)
        {
            ctx.Resource<RegistryKey>(nameof(SetExecutionPolicy))
                .Path(@"HKLM:\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell\ExecutionPolicy")
                .Value("Unrestricted", RegistryKeyValueKind.String);
        }

        private static void InstallChocolatey(ManifestContext ctx)
        {
            ctx.Resource<PowerShell>(nameof(InstallChocolatey))
                .Script("~/install-chocolatey.ps1")
                .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
                .After<RegistryKey>(nameof(SetExecutionPolicy))
                .After<Download>(ChocolateyPath);
        }
    }
}
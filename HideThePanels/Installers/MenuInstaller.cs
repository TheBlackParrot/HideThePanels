using HideThePanels.UI;
using JetBrains.Annotations;
using Zenject;

namespace HideThePanels.Installers;

[UsedImplicitly]
internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SettingsMenuManager>().AsSingle();
    }
}
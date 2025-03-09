using System;
using Zenject;
using HideThePanels.Configuration;
using JetBrains.Annotations;

namespace HideThePanels.UI;

[UsedImplicitly]
internal class SettingsMenuManager : IInitializable, IDisposable
{
    private static PluginConfig Config => PluginConfig.Instance;
    
    public void Initialize()
    {
#if V1_40_3
        BeatSaberMarkupLanguage.Settings.BSMLSettings.Instance.AddSettingsMenu("HideThePanels", "HideThePanels.UI.BSML.Settings.bsml", this);
#else
        BeatSaberMarkupLanguage.Settings.BSMLSettings.instance?.AddSettingsMenu("HideThePanels", "HideThePanels.UI.BSML.Settings.bsml", this);
#endif
    }

    public void Dispose()
    {
#if V1_40_3
        BeatSaberMarkupLanguage.Settings.BSMLSettings.Instance?.RemoveSettingsMenu(this);
#else
        BeatSaberMarkupLanguage.Settings.BSMLSettings.instance?.RemoveSettingsMenu(this);
#endif
    }

    protected bool MusicPackPromoBanner
    {
        get => Config.MusicPackPromoBanner;
        set => Config.MusicPackPromoBanner = value;
    }
    protected bool OnlineButton
    {
        get => Config.OnlineButton;
        set => Config.OnlineButton = value;
    }
    protected bool CampaignButton
    {
        get => Config.CampaignButton;
        set => Config.CampaignButton = value;
    }
    protected bool PartyButton
    {
        get => Config.PartyButton;
        set => Config.PartyButton = value;
    }
    protected bool HelpButton
    {
        get => Config.HelpButton;
        set => Config.HelpButton = value;
    }
    protected bool EditorButton
    {
        get => Config.EditorButton;
        set => Config.EditorButton = value;
    }
}
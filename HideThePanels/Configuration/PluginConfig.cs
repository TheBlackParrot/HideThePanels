using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using JetBrains.Annotations;
// ReSharper disable RedundantDefaultMemberInitializer

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace HideThePanels.Configuration;

[UsedImplicitly]
internal class PluginConfig
{
    public static PluginConfig Instance { get; set; } = null!;
    
    public virtual bool MusicPackPromoBanner { get; set; } = false;
    public virtual bool OnlineButton { get; set; } = true;
    public virtual bool CampaignButton { get; set; } = true;
    public virtual bool PartyButton { get; set; } = true;
    public virtual bool HelpButton { get; set; } = true;
    public virtual bool EditorButton { get; set; } = true;
}
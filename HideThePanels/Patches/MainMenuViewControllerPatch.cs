using HarmonyLib;
using HideThePanels.Configuration;

namespace HideThePanels.Patches;

[HarmonyPatch]
internal static class MainMenuViewControllerPatch
{
    private static PluginConfig Config => PluginConfig.Instance;
    
    [HarmonyPatch(typeof(MainMenuViewController), "DidActivate")]
    // ReSharper disable once InconsistentNaming
    internal static void Postfix(MainMenuViewController __instance)
    {
        __instance._musicPackPromoBanner.gameObject.SetActive(Config.MusicPackPromoBanner);
        __instance._multiplayerButton.gameObject.SetActive(Config.OnlineButton);
        __instance._campaignButton.gameObject.SetActive(Config.CampaignButton);
        __instance._partyButton.gameObject.SetActive(Config.PartyButton);
        __instance._howToPlayButton.gameObject.SetActive(Config.HelpButton);
        __instance._beatmapEditorButton.gameObject.SetActive(Config.EditorButton);
    }
}
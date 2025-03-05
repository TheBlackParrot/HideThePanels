using System.Reflection;
using HarmonyLib;
using HideThePanels.Configuration;
using HideThePanels.Installers;
using IPA;
using IPA.Config.Stores;
using JetBrains.Annotations;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using IPAConfig = IPA.Config.Config;

namespace HideThePanels;

[Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
[UsedImplicitly]
internal class Plugin
{
    private static Harmony _harmony = null!;
    private static IPALogger Log { get; set; } = null!;

    [Init]
    public Plugin(IPALogger ipaLogger, IPAConfig ipaConfig, Zenjector zenjector)
    {
        Log = ipaLogger;
        zenjector.UseLogger(Log);
        
        PluginConfig c = ipaConfig.Generated<PluginConfig>();
        PluginConfig.Instance = c;
        
        zenjector.Install<MenuInstaller>(Location.Menu);
        
        Log.Info("Plugin loaded");
    }

    [OnEnable]
    public void OnEnable()
    {
        _harmony = new Harmony("TheBlackParrot.HideThePanels");
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        
        Log.Info("Patches applied");
    }
    
    [OnDisable]
    public void OnDisable()
    {
        _harmony.UnpatchSelf();
    }
}
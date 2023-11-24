using MuseDashDLCUnlock;
using MelonLoader;
using HarmonyLib;
using Il2CppSteamworks;
using Il2Cpp;

[assembly: MelonInfo(typeof(DLCUnlock), "Muse Dash DLC Unlock", "1.1.0", "witherornot")]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]

namespace MuseDashDLCUnlock
{
    [HarmonyPatch(typeof(SteamApps), nameof(SteamApps.BIsDlcInstalled))]
    public class DLCPatch
    {
        static bool Prefix(ref bool __result, AppId_t appID)
        {
#if DEBUG
            Melon<DLCUnlock>.Logger.Msg($"Called IsDlcInstalled for DLC {appID.m_AppId}");
#endif
            __result = true;
            return false;
        }
    }

    [HarmonyPatch(typeof(SteamManager), nameof(SteamManager.DLCVerify))]
    public class DLCVerifyPatch
    {
        static bool Prefix(SteamManager __instance)
        {
#if DEBUG
            Melon<DLCUnlock>.Logger.Msg("Forcing DLCVerify");
#endif
            __instance.m_DoSomething1 = true;
            __instance.m_DoSomething3 = true;
            return true;
        }
    }

    public class DLCUnlock : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Loaded DLC Unlock");
        }
    }
}
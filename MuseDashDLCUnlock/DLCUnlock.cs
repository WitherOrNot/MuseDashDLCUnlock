using MuseDashDLCUnlock;
using MelonLoader;
using HarmonyLib;
using Il2CppSteamworks;

[assembly: MelonInfo(typeof(DLCUnlock), "Muse Dash DLC Unlock", "1.0.0", "witherornot")]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]

namespace MuseDashDLCUnlock
{
    [HarmonyPatch(typeof(Il2CppSteamworks.SteamApps), nameof(Il2CppSteamworks.SteamApps.BIsDlcInstalled))]
    public class DLCPatch
    {
        static bool Prefix(ref bool __result, AppId_t appID)
        {
            __result = true;
            return false;
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
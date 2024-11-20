using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IAmFuture.UserInterface.GameplayMenu;

namespace Fast_Interactions;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private static ManualLogSource _logger;

    [HarmonyPatch(typeof(GUI_QteModalBase))]
    class FasterTools
    {
        [HarmonyPatch(typeof(GUI_QteModalBase),"Initialize")]
        static void Postfix(
            GUI_QteModalBase __instance)
        {
            AccessTools.Method(typeof(GUI_QteModalBase), "Success").Invoke(__instance, null);
        }
    }

    private void Awake()
    {
        _logger = Logger;
        _logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var h = new Harmony("faster_interactions");
        h.PatchAll();
    }
}
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace HaldorOverhaul
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class HaldorOverhaul : BaseUnityPlugin
    {
        public const string PluginGUID = "com.haldor.overhaul";
        public const string PluginName = "Haldor Overhaul";
        public const string PluginVersion = "1.0.6";

        private static Harmony _harmony;
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"{PluginName} v{PluginVersion} loading...");

            ConfigLoader.Initialize();

            var traderUI = gameObject.AddComponent<TraderUI>();
            TraderPatches.SetTraderUI(traderUI);

            _harmony = new Harmony(PluginGUID);
            _harmony.PatchAll(typeof(TraderPatches));

            Log.LogInfo($"{PluginName} loaded successfully!");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
            Log.LogInfo($"{PluginName} unloaded.");
        }
    }
}

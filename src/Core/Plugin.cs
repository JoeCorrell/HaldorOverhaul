using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace HaldorOverhaul
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class HaldorOverhaul : BaseUnityPlugin
    {
        public const string PluginGUID = "com.haldor.overhaul";
        public const string PluginName = "Haldor Overhaul";
        public const string PluginVersion = "1.0.8";

        private static Harmony _harmony;
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"{PluginName} v{PluginVersion} loading...");

            ConfigLoader.Initialize();

            var traderUI = gameObject.AddComponent<TraderUI>();
            TraderPatches.SetTraderUI(traderUI);

            var bankUI = gameObject.AddComponent<BankUI>();
            TraderPatches.SetBankUI(bankUI);

            _harmony = new Harmony(PluginGUID);
            _harmony.PatchAll(typeof(TraderPatches));

            RegisterConsoleCommands();

            Log.LogInfo($"{PluginName} loaded successfully!");
        }

        private static void RegisterConsoleCommands()
        {
            new Terminal.ConsoleCommand("setcoins", "Set your coin amount - Usage: setcoins <amount>",
                (Terminal.ConsoleEventArgs args) =>
                {
                    if (args.Length < 2 || !int.TryParse(args[1], out int amount) || amount < 0)
                    {
                        args.Context.AddString("Usage: setcoins <amount>");
                        return;
                    }

                    var player = Player.m_localPlayer;
                    if (player == null) { args.Context.AddString("No player found."); return; }

                    var inv = ((Humanoid)player).GetInventory();
                    if (inv == null) return;

                    var coinPrefab = ObjectDB.instance?.GetItemPrefab("Coins");
                    var coinDrop = coinPrefab?.GetComponent<ItemDrop>();
                    if (coinDrop == null) { args.Context.AddString("Coins prefab not found."); return; }

                    string coinName = coinDrop.m_itemData.m_shared.m_name;
                    int current = inv.CountItems(coinName);

                    // Remove all existing coins
                    if (current > 0)
                        inv.RemoveItem(coinName, current);

                    // Add desired amount
                    if (amount > 0)
                        inv.AddItem("Coins", amount, coinDrop.m_itemData.m_quality,
                            coinDrop.m_itemData.m_variant, 0L, "");

                    ((Character)player).Message(MessageHud.MessageType.Center, $"Coins set to {amount}");
                    args.Context.AddString($"Coins set to {amount} (was {current})");
                });
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
            Log.LogInfo($"{PluginName} unloaded.");
        }
    }
}
